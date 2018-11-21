using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using opSolver.OPS.Methods.Genetic.Model;
using opSolver.OPS.Methods.Genetic.Services;

namespace opSolver.OPS.Methods.Genetic
{
    public class GData
    {
        public int population { get; set; }
        public int iterations { get; set; }
        public string function { get; set; }
        public Limit limit1 { get; set; }
        public Limit limit2 { get; set; }
        public int minValue { get; set; }
        public int maxValue { get; set; }
        public bool isMax { get; set; }
        public List<List<Child>> childs { get; set; }
        public List<Child> tempChilds { get; set; }
        
        public void Solve()
        {
            Solver solver = new Solver();
            childs = solver.Solve(population, iterations, limit1, limit2, minValue, maxValue, function, isMax);
        }

    }
}
