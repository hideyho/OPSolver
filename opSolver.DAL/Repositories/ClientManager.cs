using opSolver.DAL.EF;
using opSolver.DAL.Entities;
using opSolver.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opSolver.DAL.Repositories
{
    public class ClientManager: IClientManager
    {
        public opContext Database { get; set; }
        public ClientManager(opContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database._users.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
