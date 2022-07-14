using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ELearningAPI.Infrastructure.Models;
using ELearningAPI.Infrastructure.Entities;
using ELearningAPI.Infrastructure.Configs;

namespace ELearningAPI.Infrastructure.Repositories
{
    /// <summary>
    ///   <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public interface IStaffRepository
    {
        DataContext _dataContext { get; }

        /// <summary>Gets all.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        IList<StaffEntity> GetAll();

        /// <summary>Finds the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        StaffEntity Find(int id);

        /// <summary>Inserts the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        void Insert(StaffEntity entity);

        /// <summary>Updates the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        void Update(StaffEntity entity);

        /// <summary>Deletes the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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
