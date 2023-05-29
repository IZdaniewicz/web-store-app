using AutoMapper;
using Backend.DTOs;
using Backend.Models;

namespace Backend
{
    public class Serializers : Profile
    {
        public Serializers()
        {
            CreateMap<User, UserGetDTO>()
                .ForMember(m => m.Balance, c => c.MapFrom(s => s.Account.Balance));

            CreateMap<UserPostDTO, User>()
                .ForMember(r => r.Account, c => c.MapFrom(dto => new Account()
                {
                    Balance = dto.Balance,
                }));
        }
    }
}
