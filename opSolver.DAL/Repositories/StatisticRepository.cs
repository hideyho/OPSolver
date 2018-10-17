using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using opSolver.DAL.Entities;
using opSolver.DAL.Interfaces;
using opSolver.DAL.EF;

namespace opSolver.DAL.Repositories
{
    class StatisticRepository:IRepository<Statistic>
    {
        private opContext db;
        public StatisticRepository(opContext context)
        {
            db = context;
        }

        public IEnumerable<Statistic> GetAll()
        {
            return db._statistics;
        }
        public Statistic Get(int id)
        {
            return db._statistics.Find(id);
        }
        public IEnumerable<Statistic> Find(Func<Statistic, bool> predicate)
        {
            return db._statistics.Where(predicate).ToList();
        }
        public void Create(Statistic item)
        {
            db._statistics.Add(item);
        }
        public void Update(Statistic item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Statistic item = Get(id);
            if (item != null)
                db._statistics.Remove(item);
        }


    }
}
