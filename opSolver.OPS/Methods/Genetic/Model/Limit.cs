using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;

namespace opSolver.OPS.Methods.Genetic.Model
{
    public class Limit
    {
        public string function { get; set; }
        public string sign { get; set; }
        public int limitResult { get; set; }

        public bool Check(int x1, int x2, int x3, int x4)
        {
            Function limit = new Function("limit(x1,x2,x3,x4) = " + function);
            Expression le = new Expression("limit(" + x1 + ',' + x2 + ',' + x3 + ',' + x4 + ')', limit);
            if (sign == ">=" && le.calculate() >= limitResult)
                return true;
            else if (sign == "<=" && le.calculate() <= limitResult)
                return true;
            else if (sign == "==" && le.calculate() == limitResult)
                return true;
            else
                return false;
        }

    }
}
