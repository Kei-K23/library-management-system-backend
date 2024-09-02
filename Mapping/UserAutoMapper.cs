using AutoMapper;
using LibraryManagementSystemBackend.Dto;
using LibraryManagementSystemBackend.Models;

namespace LibraryManagementSystemBackend.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserResponseDto>();
            CreateMap<UserRequestDto, User>();
            CreateMap<UserUpdateRequestDto, User>();
            CreateMap<Book, BookResponseDto>();
            CreateMap<BookRequestDto, Book>();
            CreateMap<BookUpdateRequestDto, Book>();
        }
    }
}