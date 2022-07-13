using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ELearningAPI.Infrastructure.Models;
using ELearningAPI.Infrastructure.Entities;
using ELearningAPI.Infrastructure.Configs;

namespace ELearningAPI.Infrastructure.Repositories
{
	public interface IStaffRepository
    {
        DataContext _dataContext { get; }
        IList<StaffEntity> GetAll();
        StaffEntity Find(int id);
        void Insert(StaffEntity entity);
        void Update(StaffEntity entity);
        void Delete(StaffEntity entity);
    }
	public class StaffRepository : IStaffRepository
	{
		public DataContext _dataContext { get; private set; }

        public StaffRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public void Delete(StaffEntity entity)
		{
            try
            {
                _dataContext.Staffs.Update(entity);
            }
            catch (Exception ex) { throw; }
		}

		public IList<StaffEntity> GetAll()
		{
            try
            {
                return _dataContext.Staffs.ToList();
            }
            catch (Exception ex) { 
                throw; 
            }
        }
		public StaffEntity Find(int id)
		{
            try
            {
                return _dataContext.Staffs.AsNoTracking().FirstOrDefault(n => n.PK_Id == id);
            }
            catch (Exception ex) {
                throw;
            }
        }

		public void Insert(StaffEntity entity)
		{
            try {
                _dataContext.Staffs.Add(entity);
            }
            catch (Exception ex) {
                throw;
            }           
		}
        public void Update(StaffEntity entity)
        {
            try {
                _dataContext.Staffs.Update(entity);
            }
            catch (Exception ex) {
                throw;
            }
           
        }
    }
}
