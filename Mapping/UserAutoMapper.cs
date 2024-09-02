using AutoMapper;
using LibraryManagementSystemBackend.Dto;
using LibraryManagementSystemBackend.Models;

namespace SocialMediaAPI.Mapping
{
    public class UserAutoMapper : Profile
    {
        public UserAutoMapper()
        {
            CreateMap<User, UserResponseDto>();
            CreateMap<UserRequestDto, User>();
            CreateMap<UserUpdateRequestDto, User>();
        }
    }
}