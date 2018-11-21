using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using opSolver.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace opSolver.DAL.EF
{
   public class opContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<ClientProfile> _users { get; set; }
        public DbSet<Statistic> _statistics { get; set; }
        public opContext(string connectionString) : base(connectionString) { }
    }
}
