using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opSolver.DAL.Entities
{
    public class Statistic
    {
        public int Id { get; set; }
        public string Method { get; set; }
        public double x1 { get; set; }
        public double x2 { get; set; }
        public double x3 { get; set; }
        public double x4 { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
