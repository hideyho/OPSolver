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
    public class EFUnitOfWork:IUntiOfWork
    {
        private opContext db;
        private UserRepository userRepository;
        private StatisticRepository statisticRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new opContext(connectionString);
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }
        public IRepository<Statistic> Statistics
        {
            get
            {
                if (statisticRepository == null)
                    statisticRepository = new StatisticRepository(db);
                return statisticRepository;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
