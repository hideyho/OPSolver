using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using opSolver.DAL.Entities;

namespace opSolver.DAL.EF
{
    class opContext:DbContext
    {
        public DbSet<User> _users { get; set; }
        public DbSet<Statistic> _statistics { get; set; }
        public opContext(string connectionString) : base(connectionString) { }
    }
}
