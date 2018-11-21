using opSolver.DAL.Repositories;
using opSolver.WEB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace opSolver.WEB.Services
{
    public class ServiceCreator:IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new EFUnitOfWork(connection));
        }
    }
}