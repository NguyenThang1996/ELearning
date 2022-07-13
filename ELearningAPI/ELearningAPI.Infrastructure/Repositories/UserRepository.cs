using ELearningAPI.Infrastructure.Configs;
using ELearningAPI.Infrastructure.Entities;

namespace ELearningAPI.Infrastructure.Repositories
{
	public interface IUserRepository
    {
		IList<UserEntity> GetAll();
    }
	public class UserRepository : IUserRepository
	{
		public DataContext _dataContext { get; private set; }

        public UserRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public IList<UserEntity> GetAll()
		{
			try
			{
				return _dataContext.Users.ToList();
			}
			catch (Exception ex) {
				throw;
			}
		}		
    }
}
