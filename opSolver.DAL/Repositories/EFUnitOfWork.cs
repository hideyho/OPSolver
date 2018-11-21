using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using opSolver.DAL.Entities;
using opSolver.DAL.Interfaces;
using opSolver.DAL.EF;
using opSolver.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace opSolver.DAL.Repositories
{
    public class EFUnitOfWork:IUntiOfWork
    {
        private opContext db;
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;
        private StatisticRepository statisticRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new opContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            clientManager = new ClientManager(db);
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }
        public IClientManager ClientManager
        {
            get { return clientManager; }
        }
        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }


        public IRepository<Statistic> Statistics
        {
            get
            {
                if (statisticRepository == null)
                    statisticRepository = new StatisticRepository(db);
                return statisticRepository;
            }
        }

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public void Save()
        {
            db.SaveChanges();
           
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
