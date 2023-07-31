using AutoMapper;
using FunChat.Application.DTOs.Account;
using FunChat.Application.Generators;
using FunChat.Domain.Entities.Account;

namespace FunChat.Infrastructure.MappingProfile
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterUserDTO,User>()
            .ForMember(u=>u.UserName,u=>u.MapFrom(c=>c.Email))
            .ForMember(u=>u.UserAvatar,u=>u.MapFrom(c=>"Default.jpg"))
            .ForMember(u=>u.EmailActiveCode,u=>u.MapFrom(c=>Generators.GetEmailActivationCode()));


            CreateMap<User,EmailActivationDTO>();
        }
    }
}
