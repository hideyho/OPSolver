using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opSolver.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Statistic> Statistics { get; set; }
        public User()
        {
            Statistics = new List<Statistic>();
        }
    }
}
