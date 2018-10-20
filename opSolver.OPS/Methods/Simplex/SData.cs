using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplexMethod;

namespace opSolver.OPS.Methods.Simplex
{
    public class SData
    {
        public int constraintCount = 2;
        public int variablesCount = 3;
        public bool isMax { get; set; }
        Constraint[] constraints;
        Function function;
        SimplexMethod.Simplex simplex;
        public Tuple<List<SimplexSnap>, SimplexResult> result { get; set; }


        //transfer
        public List<List<double>> dtVariables { get; set; }
        public List<double> dtFunctionVariables { get; set; }
        public List<double> dtB { get; set; }
        public List<string> dtSign { get; set; }


        public SData()
        {
            constraints = new Constraint[constraintCount];
            dtVariables = new List<List<double>>();
            dtFunctionVariables = new List<double>();
            dtB = new List<double>();
            dtSign = new List<string>();
        }

        public double[] DataTransfer(List<double> dto)
        {
            double[] item = new double[dto.Count];
            for(int i = 0; i < dto.Count; i++)
            {
                item[i] = dto[i];
            }
            return item;
        }

        public void Solve()
        {
            for(int i = 0; i < constraintCount; i++)
            {
                double[] variables = new double[variablesCount];
                variables = DataTransfer(dtVariables[i]);
                double b = dtB[i];
                string sign = dtSign[i];
                constraints[i] = new Constraint(variables, b, sign);
            }
            double[] functionVariables = DataTransfer(dtFunctionVariables);
            function = new Function(functionVariables, 0, isMax);
            simplex = new SimplexMethod.Simplex(function, constraints);
            result = simplex.GetResult();
        }

    }
}
