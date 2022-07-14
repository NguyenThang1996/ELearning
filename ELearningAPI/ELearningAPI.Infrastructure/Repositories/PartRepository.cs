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
    public interface IPartRepository
    {
        DataContext _dataContext { get; }
        IList<PartEntity> GetAll();
        PartEntity Find(int id);
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
                return _dataContext.Parts.ToList();
            }
            catch (Exception ex)
            {
                throw;
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
        public PartEntity Find(int id)
        {
            try
            {
                return _dataContext.Parts.Find(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
