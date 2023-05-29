using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Request;

namespace Backend
{
    public class Serializers : Profile
    {
        public Serializers()
        {
            CreateMap<User, UserGetDTO>()
                .ForMember(m => m.Balance, c => c.MapFrom(s => s.Account.Balance));

            CreateMap<UserRegisterDTO, User>()
                .ForMember(r => r.Account, c => c.MapFrom(dto => new Account()
                {
                    Balance = dto.Balance,
                }));

            CreateMap<StoreItem, StoreItemGetDTO>();
            CreateMap<StoreItemPostDTO, StoreItem>();
            CreateMap<StoreItemPutDTO, StoreItem>();

            CreateMap<Account,AccountGetDTO>();
            CreateMap<AccountModifyDto, Account>();
        }
    }
}
