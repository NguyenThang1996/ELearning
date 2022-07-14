using AutoMapper;
using ELearningAPI.Infrastructure.Entities;
using ELearningAPI.Infrastructure.Models;
using ELearningAPI.Infrastructure.UnitOfWork;
using ELearningAPI.Common.Helpers;

namespace ELearningAPI.Service.Services
{
    /// <summary>
    ///   <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public interface IUserService
    {
        /// <summary>Checks the login.</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        UserModel CheckLogin(UserLoginModel model);
    }

    /// <summary>
    ///   <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the <see cref="UserService" /> class.</summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>Checks the login.</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
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
