using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using opSolver.OPS.Methods.Genetic.Model;

namespace opSolver.OPS.Methods.Genetic.Services
{
    public class Solver
    {
        List<Child> currentPopulation;
        public List<List<Child>> Solve(int population, int iterations, Limit limit1, Limit limit2,int minValue, int maxValue, string function, bool isMax)
        {
            List<List<Child>> childs = new List<List<Child>>();
            currentPopulation = initializePopulation(population, limit1, limit2, function, minValue, maxValue);
            childs.Add(currentPopulation);
            for(int i = 0; i < iterations; i++)
            {
                currentPopulation = cross(currentPopulation, limit1, limit2, function, minValue, maxValue, population);
                if (isMax)
                    currentPopulation = currentPopulation.OrderByDescending(m => m.result).ToList();
                else
                    currentPopulation = currentPopulation.OrderBy(m => m.result).ToList();
                currentPopulation = currentPopulation.Take(population).ToList();
                childs.Add(currentPopulation);
            }

            return childs;
        }

        List<Child> initializePopulation(int population, Limit limit1, Limit limit2, string function, int minValue, int maxValue)
        {
            List<Child> firstChilds = new List<Child>();
            Random random = new Random();
            for(int i = 0; i < population; i++)
            {
                int x1=0,
                    x2=0,
                    x3=0,
                    x4=0;
                bool isLimited = false;
                while (!isLimited)
                {
                    x1 = random.Next(minValue, maxValue);
                    x2 = random.Next(minValue, maxValue);
                    x3 = random.Next(minValue, maxValue);
                    x4 = random.Next(minValue, maxValue);
                    isLimited = (limit1.Check(x1, x2, x3, x4) && limit2.Check(x1, x2, x3, x4)) ? true : false;    
                }
                firstChilds.Add(new Child(x1, x2, x3, x4, function));
            }
            return firstChilds;
        }

        List<Child> cross(List<Child> childs, Limit limit1, Limit limit2, string function, int minValue, int maxValue, int population)
        {
            List<Child> newChilds = new List<Child>();
            Random random = new Random();
            for(int i = 0; i < population * 2; i++)
            {
                Child tempChild = new Child(0,0,0,0,function);
                bool isLimited = false;
                while (!isLimited)
                {
                    int firstChild = random.Next(childs.Count);
                    int secondChild = random.Next(childs.Count);
                    tempChild = new Child
                        (
                        childs[firstChild].x1,
                        childs[firstChild].x2,
                        childs[secondChild].x3,
                        childs[secondChild].x4,
                        function
                        );
                    isLimited = (limit1.Check(tempChild.x1, tempChild.x2, tempChild.x3, tempChild.x4) && limit2.Check(tempChild.x1, tempChild.x2, tempChild.x3, tempChild.x4)) ? true : false;
                }
                if (random.Next(1, 3) == 3)
                    tempChild = mutation(tempChild, minValue, maxValue, limit1, limit2);
                newChilds.Add(tempChild);
            }
            return newChilds;
        }

        Child mutation(Child child, int minValue, int maxValue, Limit limit1, Limit limit2)
        {
            Random random = new Random();
            int genom = random.Next(1, 2);
            bool isLimited = false;
            while (!isLimited)
            {
                if (genom == 1)
                {
                    child.x1 = random.Next(minValue, maxValue);
                    child.x2 = random.Next(minValue, maxValue);
                }
                else if (genom == 2)
                {
                    child.x3 = random.Next(minValue, maxValue);
                    child.x4 = random.Next(minValue, maxValue);
                }

                isLimited = (limit1.Check(child.x1, child.x2, child.x3, child.x4) && limit2.Check(child.x1, child.x2, child.x3, child.x4)) ? true : false;
            }
            return child;
        }
    }
}
