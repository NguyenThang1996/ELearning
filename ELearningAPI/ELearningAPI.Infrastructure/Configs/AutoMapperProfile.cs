using AutoMapper;
using ELearningAPI.Infrastructure.Entities;
using ELearningAPI.Infrastructure.Models;

namespace ELearningAPI.Infrastructure.Configs
{
    /// <summary>
    ///   <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class AutoMapperProfile : Profile
    {
        /// <summary>Initializes a new instance of the <see cref="AutoMapperProfile" /> class.</summary>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public AutoMapperProfile()
        {
            CreateMap<StaffModel, StaffEntity>();
            CreateMap<StaffEntity, StaffModel>();
            CreateMap<UserEntity, UserModel>();
            CreateMap<PartEntity, PartModel>();
        }
    }
}
