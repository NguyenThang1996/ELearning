using AutoMapper;
using ELearningAPI.Infrastructure.Entities;
using ELearningAPI.Infrastructure.Models;
using ELearningAPI.Infrastructure.UnitOfWork;
using ELearningAPI.Common.Helpers;

namespace ELearningAPI.Service.Services
{
    public interface IUserService
    {
        UserModel CheckLogin(UserLoginModel model);
    }

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
       
        public UserModel CheckLogin(UserLoginModel model)
        {
            try {
                var users = _unitOfWork.UserRepository().GetAll();
                var user = users.Where(n => n.Username == model.Username && n.Password.ToUpper() == Encryptor.MD5Hash(model.Password).ToUpper()).FirstOrDefault();
                return _mapper.Map<UserModel>(user); ;
            }
            catch (Exception ex) {
                throw;
            }
         
        }
    }
}
