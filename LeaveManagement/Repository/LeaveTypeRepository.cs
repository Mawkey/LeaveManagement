using LeaveManagement.Contracts;
using LeaveManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {

        private readonly ApplicationDbContext db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool Create(LeaveType entity)
        {
            db.LeaveTypes.Add(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            db.LeaveTypes.Remove(entity);
            return Save();
        }

        public bool Exists(int id)
        {
            return db.LeaveTypes.Any(x => x.Id == id);
        }

        public ICollection<LeaveType> FindAll()
        {
            return db.LeaveTypes.ToList();
        }

        public LeaveType FindById(int id)
        {
            return db.LeaveTypes.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }

        public bool Update(LeaveType entity)
        {
            db.LeaveTypes.Update(entity);
            return Save();
        }
    }
}
