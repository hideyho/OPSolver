using opSolver.WEB.Infrastructure;
using opSolver.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace opSolver.WEB.Interfaces
{
    public interface IUserService:IDisposable
    {
        Task<OperationDetails> Create(User user);
        Task<ClaimsIdentity> Authenticate(User user);
        Task SetInitialData(User admin, List<string> roles);
    }
}
