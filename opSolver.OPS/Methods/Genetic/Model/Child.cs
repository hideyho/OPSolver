using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;

namespace opSolver.OPS.Methods.Genetic.Model
{
    public class Child
    {
        public int x1 { get; set; }
        public int x2 { get; set; }
        public int x3 { get; set; }
        public int x4 { get; set; }
        public double result { get; set; }

        public double Result(List<double> fkf)
        {
        
             return fkf[0] * x1 + fkf[1] * x2 + fkf[2] * x3 + fkf[3] * x4;
            
        }

    }
}
