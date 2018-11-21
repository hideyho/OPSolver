using Microsoft.AspNet.Identity;
using opSolver.DAL.Entities;
using opSolver.DAL.Interfaces;
using opSolver.WEB.Infrastructure;
using opSolver.WEB.Interfaces;
using opSolver.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace opSolver.WEB.Services
{
    public class UserService : IUserService
    {
        IUntiOfWork Database { get; set; }
        public UserService(IUntiOfWork uow)
        {
            Database = uow;
        }
        public async Task<OperationDetails> Create(User userView)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userView.Email);
            if(user == null)
            {
                user = new ApplicationUser { Email = userView.Email, UserName = userView.Email };
                var result = await Database.UserManager.CreateAsync(user, userView.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                await Database.UserManager.AddToRoleAsync(user.Id, userView.Role);
                ClientProfile clientProfile = new ClientProfile { Id = user.Id, Address = userView.Address, Name = userView.Name };
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "reg success", "");
            }
            else
            {
                return new OperationDetails(false, "login has", "Email");
            }

           
        }

        public async Task<ClaimsIdentity> Authenticate(User userView)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await Database.UserManager.FindAsync(userView.Email, userView.Password);
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task SetInitialData(User adminView, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if(role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
                await Create(adminView);
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}