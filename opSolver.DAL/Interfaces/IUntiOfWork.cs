using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using opSolver.DAL.Entities;
using opSolver.DAL.Identity;

namespace opSolver.DAL.Interfaces
{
    public interface IUntiOfWork:IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IRepository<Statistic> Statistics { get; }
        Task SaveAsync();
        void Save();
    }
}
