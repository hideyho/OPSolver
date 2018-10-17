using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using opSolver.DAL.Interfaces;
using opSolver.DAL.Repositories;

namespace opSolver.WEB.Utils
{
    public class opModule : NinjectModule
    {
        private string connectionString;
        public opModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUntiOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}