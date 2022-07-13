using AutoMapper;
using ELearningAPI.Infrastructure.Entities;
using ELearningAPI.Infrastructure.Models;

namespace ELearningAPI.Infrastructure.Configs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StaffModel, StaffEntity>();
            CreateMap<StaffEntity, StaffModel>();
            CreateMap<UserEntity, UserModel>();
            CreateMap<PartEntity, PartModel>();
        }
    }
}
