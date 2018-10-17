using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using opSolver.DAL.Entities;

namespace opSolver.DAL.Interfaces
{
    public interface IUntiOfWork:IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Statistic> Statistics { get; }
        void Save();
    }
}
