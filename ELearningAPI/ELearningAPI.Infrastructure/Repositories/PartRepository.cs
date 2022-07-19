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
    public interface IPartRepository
    {
        DataContext _dataContext { get; }
        /// <summary>Gets all.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comment
        /// Nguyen Huy Thang 19/07/2022 created
        /// </Modified>
        IList<PartEntity> GetAll();

        /// <summary>Finds the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comment
        /// Nguyen Huy Thang 19/07/2022 created
        /// </Modified>
        PartEntity Find(int? id);
    }
    /// <summary>
    ///   <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class PartRepository : IPartRepository
    {
		public DataContext _dataContext { get; private set; }

        /// <summary>Initializes a new instance of the <see cref="PartRepository" /> class.</summary>
        /// <param name="dataContext">The data context.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public PartRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

        /// <summary>Gets all.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public IList<PartEntity> GetAll()
		{
            try
            {
                var parts = _dataContext.Parts.ToList();
                if (parts != null)
                {
                    return parts;
                }
                return null;
            }
            catch (Exception ex)
            {
                ExceptionLog.GetException(ex, "PartRepository", "GetAll");
                return null;
            }
        }

        /// <summary>Finds the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public PartEntity Find(int? id)
        {
            try
            {
                var parts = _dataContext.Parts;
                if (parts != null)
                {
                    var part = parts.Find(id);
                    if (part != null)
                    {
                        return part;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                ExceptionLog.GetException(ex, "PartRepository", "Find");
                return null;
            }
        }
    }
}
