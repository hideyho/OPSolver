using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using opSolver.OPS.Methods.Genetic.Model;

namespace opSolver.OPS.Methods.Genetic.Services
{
    public class Solver
    {
        public string function { get; set; }
        public int StartSize { get; set; }
        public int whatProblem { get; set; }
        public List<Child> stPop = new List<Child>();
        public List<Child> ChildPop = new List<Child>();
        public List<List<double>> kf { get; set; }
        private bool bounds(int x1, int x2, int x3, int x4)
        {
                        if ((kf[1][0]*x1 + kf[1][1]*x2 + kf[1][2]*x3 + kf[1][3]*x4) >= kf[1][4] &&
                            (kf[2][0] * x1 + kf[2][1] * x2 + kf[2][2] * x3 + kf[2][3] * x4) <= kf[2][4])
                        return true;
                        else return false;
        }

        public void InitPop()
        {
            Random rnd = new Random();
            for (int i = 0; i < StartSize; i++)
            {
                Child obj = new Child();
                obj.x1 = rnd.Next(0, 30000);
                obj.x2 = rnd.Next(0, 30000);
                obj.x3 = rnd.Next(0, 30000);
                obj.x4 = rnd.Next(0, 30000);
                obj.result = obj.Result(kf[0]);
                if (bounds(obj.x1, obj.x2, obj.x3, obj.x4) == true)
                    stPop.Add(obj);
                else i -= 1;
            }

        }
        public void Cross(List<Child> start)
        {
            Random rnd = new Random();


            for (int i = 0; i < StartSize * 4; i++)
            {
                ArrayList arr = new ArrayList();
                for (int j = 0; j <= 3; j++)
                {
                    int temp = rnd.Next(1, 4);
                    arr.Add(temp);
                }
                int parent1 = rnd.Next(0, StartSize);
                int parent2 = rnd.Next(0, StartSize);
                Child child = new Child();
                if (parent1 != parent2)
                {
                    if ((int)arr[0] == 1) { child.x1 = start[parent1].x1; }
                    else child.x1 = start[parent2].x1;
                    if ((int)arr[1] == 1) { child.x2 = start[parent1].x2; }
                    else child.x2 = start[parent2].x2;
                    if ((int)arr[2] == 1) { child.x3 = start[parent1].x3; }
                    else child.x3 = start[parent2].x3;
                    if ((int)arr[3] == 1) { child.x4 = start[parent1].x4; }
                    else child.x4 = start[parent2].x4;


                }
                else i = i - 1; if (bounds(child.x1, child.x2, child.x3, child.x4) == true)
                { child.result = child.Result(kf[0]); ChildPop.Add(child); }
                else i -= 1;
            }


        }
        public void Mutation(List<Child> mas)
        {
            Random rnd = new Random();
            for (int i = 0; i < mas.Count / 2; i++)
            {
                Child mut = new Child();
                int mutInd = rnd.Next(0, mas.Count);
                int mutX = rnd.Next(1, 4);
                if (mutX == 1)
                {

                    mut.x1 = rnd.Next(0, 30000);
                    mut.x2 = rnd.Next(0, 30000);
                    mut.x3 = mas[mutInd].x3;
                    mut.x4 = rnd.Next(0, 30000);
                    mut.result = mut.Result(kf[0]);
                }

                if (mutX == 2)
                {
                    mut.x3 = rnd.Next(0, 30000);
                    mut.x2 = rnd.Next(0, 30000);
                    mut.x1 = mas[mutInd].x1;
                    mut.x4 = rnd.Next(0, 30000);
                    mut.result = mut.Result(kf[0]);
                }
                if (mutX == 3)
                {
                    mut.x1 = rnd.Next(0, 30000);
                    mut.x3 = rnd.Next(0, 30000);
                    mut.x2 = mas[mutInd].x2;
                    mut.x4 = rnd.Next(0, 30000);
                    mut.result = mut.Result(kf[0]);
                }
                if (mutX == 4)
                {
                    mut.x1 = rnd.Next(0, 30000);
                    mut.x2 = rnd.Next(0, 30000);
                    mut.x4 = mas[mutInd].x4;
                    mut.x3 = rnd.Next(0, 30000);
                    mut.result = mut.Result(kf[0]);
                }
                if (bounds(mut.x1, mut.x2, mut.x3, mut.x4) == true) { mas[mutInd] = mut; }
                else i -= 1;
            }

            ChildPop = ChildPop.OrderByDescending(m => m.result).ToList();
            stPop = ChildPop.Take(StartSize).ToList();



        }

    }
}
