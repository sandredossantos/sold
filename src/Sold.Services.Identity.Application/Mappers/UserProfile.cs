using AutoMapper;
using Sold.Services.Identity.Application.DTOs;
using Sold.Services.Identity.Domain.Entities;

namespace Sold.Services.Identity.Application.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}