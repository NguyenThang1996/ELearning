using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ELearningAPI.Infrastructure.Models;
using ELearningAPI.Infrastructure.Entities;
using ELearningAPI.Infrastructure.Configs;

namespace ELearningAPI.Infrastructure.Repositories
{
	public interface IPartRepository
    {
        DataContext _dataContext { get; }
        IList<PartEntity> GetAll();
        PartEntity Find(int id);
    }
	public class PartRepository : IPartRepository
    {
		public DataContext _dataContext { get; private set; }

        public PartRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
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
