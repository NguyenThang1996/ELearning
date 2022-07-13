using ELearningAPI.Entities;
using ELearningAPI.Helpers;

namespace ELearningAPI.Services
{
    public interface IPartService
    {
        List<PartEntity> GetAll();
    }
    public class PartService : IPartService
    {
        private DataContext _context;
        public PartService(
            DataContext context)
        {
            _context = context;
        }

        public List<PartEntity> GetAll()
        {
            return _context.Parts.ToList();
        }
    }
}
