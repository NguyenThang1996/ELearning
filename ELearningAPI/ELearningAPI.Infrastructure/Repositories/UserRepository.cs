using ELearningAPI.Common.Helpers;
using ELearningAPI.Infrastructure.Configs;
using ELearningAPI.Infrastructure.Entities;

namespace ELearningAPI.Infrastructure.Repositories
{
    /// <summary>
    ///   <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public interface IUserRepository
    {
        /// <summary>Gets all.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        IList<UserEntity> GetAll();
    }

    /// <summary>
    ///   <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class UserRepository : IUserRepository
	{
		public DataContext _dataContext { get; private set; }

        /// <summary>Initializes a new instance of the <see cref="UserRepository" /> class.</summary>
        /// <param name="dataContext">The data context.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public UserRepository(DataContext dataContext)
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
        public IList<UserEntity> GetAll()
		{
			try
			{
                var users = _dataContext.Users.ToList();
                if (users != null)
                {
                    return users;
                }
                return null;
     ;		}
			catch (Exception ex) {
                ExceptionLog.GetException(ex, "UserRepository", "GetAll");
                return null;
            }
		}		
    }
}
