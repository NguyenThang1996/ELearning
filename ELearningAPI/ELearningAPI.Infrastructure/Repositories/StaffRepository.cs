using Microsoft.EntityFrameworkCore;
using ELearningAPI.Common.Helpers;
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
        StaffEntity Find(int? id);

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

    /// <summary>
    ///   <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comment
    /// Nguyen Huy Thang 19/07/2022 created
    /// </Modified>
    public class StaffRepository : IStaffRepository
    {
        public DataContext _dataContext { get; private set; }

        /// <summary>Initializes a new instance of the <see cref="StaffRepository" /> class.</summary>
        /// <param name="dataContext">The data context.</param>
        /// <Modified>
        /// Name Date Comment
        /// Nguyen Huy Thang 19/07/2022 created
        /// </Modified>
        public StaffRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>Deletes the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <Modified>
        /// Name Date Comment
        /// Nguyen Huy Thang 19/07/2022 created
        /// </Modified>
        public void Delete(StaffEntity entity)
        {
            try
            {
                _dataContext.Staffs.Update(entity);
            }
            catch (Exception ex)
            {
                ExceptionLog.GetException(ex, "StaffRepository", "Delete");
            }
        }

        /// <summary>Gets all.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comment
        /// Nguyen Huy Thang 19/07/2022 created
        /// </Modified>
        public IList<StaffEntity> GetAll()
        {
            try
            {
                var staffs = _dataContext.Staffs.ToList();
                if (staffs != null)
                {
                    return staffs;
                }
                return null;
            }
            catch (Exception ex)
            {
                ExceptionLog.GetException(ex, "StaffRepository", "GetAll");
                return null;
            }
        }

        /// <summary>Finds the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comment
        /// Nguyen Huy Thang 19/07/2022 created
        /// </Modified>
        public StaffEntity Find(int? id)
        {
            try
            {
                var staffs = _dataContext.Staffs;
                if (staffs != null)
                {
                    var staff = staffs.AsNoTracking().FirstOrDefault(n => n.PK_Id == id);
                    if (staff != null)
                    {
                        return staff;
                    }
                    return null;
                }
                return null;
 ;            }
            catch (Exception ex)
            {
                ExceptionLog.GetException(ex, "StaffRepository", "Find");
                return null;
            }
        }

        /// <summary>Inserts the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <Modified>
        /// Name Date Comment
        /// Nguyen Huy Thang 19/07/2022 created
        public void Insert(StaffEntity entity)
        {
            try
            {
                _dataContext.Staffs.Add(entity);
            }
            catch (Exception ex)
            {
                ExceptionLog.GetException(ex, "StaffRepository", "Insert");
            }
        }

        /// <summary>Updates the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <Modified>
        /// Name Date Comment
        /// Nguyen Huy Thang 19/07/2022 created
        /// </Modified>
        public void Update(StaffEntity entity)
        {
            try
            {
                _dataContext.Staffs.Update(entity);
            }
            catch (Exception ex)
            {
                ExceptionLog.GetException(ex, "StaffRepository", "Update");
            }

        }
    }
}
