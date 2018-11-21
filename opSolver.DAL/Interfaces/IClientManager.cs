using opSolver.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opSolver.DAL.Interfaces
{
    public interface IClientManager:IDisposable
    {
        void Create(ClientProfile item);
    }
}
