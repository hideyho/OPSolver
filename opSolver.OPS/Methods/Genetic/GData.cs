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
        public int iterations { get; set; }
        public int population { get; set; }
        public List<List<double>> kf { get; set; }
        public List<List<Child>> childs { get; set; }
        
        public void Solve()
        {
            Solver solver = new Solver();
            solver.kf = kf;
            solver.StartSize = population;
            solver.InitPop();
            childs = new List<List<Child>>();
            for(int i = 0; i < iterations; i++)
            {
                solver.Cross(solver.stPop);
                solver.Mutation(solver.ChildPop);
                var temp = new List<Child>();
                foreach(var m in solver.stPop)
                {
                    temp.Add(m);
                }
                childs.Add(temp);
            }
        }

    }
}
