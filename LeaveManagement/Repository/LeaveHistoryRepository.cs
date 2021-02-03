using LeaveManagement.Contracts;
using LeaveManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext db;

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool Create(LeaveHistory entity)
        {
            db.LeaveHistories.Add(entity);

            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            db.LeaveHistories.Remove(entity);

            return Save();
        }

        public bool Exists(int id)
        {
            return db.LeaveHistories.Any(x => x.Id == id);
        }

        public ICollection<LeaveHistory> FindAll()
        {
            return db.LeaveHistories.ToList();
        }

        public LeaveHistory FindById(int id)
        {
            return db.LeaveHistories.FirstOrDefault(x => x.Id == id);
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

        public bool Update(LeaveHistory entity)
        {
            db.LeaveHistories.Update(entity);

            return Save();
        }
    }
}
