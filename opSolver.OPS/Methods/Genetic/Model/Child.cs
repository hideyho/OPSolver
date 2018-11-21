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
        public int result { get; set; }

        public Child(int x1, int x2, int x3, int x4, string function)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;

            Function func = new Function("F(x1,x2,x3,x4) = " + function);
            Expression ef = new Expression("F(" + x1 + ',' + x2 + ',' + x3 + ',' + x4 + ')', func);
            result = (int)ef.calculate();
        }

    }
}
