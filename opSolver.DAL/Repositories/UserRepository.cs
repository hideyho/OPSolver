using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using opSolver.DAL.EF;
using opSolver.DAL.Entities;
using opSolver.DAL.Interfaces;

namespace opSolver.DAL.Repositories
{
    class UserRepository:IRepository<User>
    {
        private opContext db;
        public UserRepository(opContext context)
        {
            db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db._users;
        }
        public User Get(int id)
        {
            return db._users.Find(id);
        }
        public IEnumerable<User> Find(Func<User,bool> predicate)
        {
            return db._users.Where(predicate).ToList();
        }
        public void Create(User item)
        {
            db._users.Add(item);
        }
        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            User item = Get(id);
            if (item != null)
                db._users.Remove(item);
        }

    }
}
