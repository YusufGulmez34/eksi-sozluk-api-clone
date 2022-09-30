using AutoMapper;
using EksiSozlukAPI.Application.Features.Commands.Entry.CreateEntry;
using EksiSozlukAPI.Application.Features.Commands.Title.CreateTitle;
using EksiSozlukAPI.Application.Features.Commands.User.CreateUser;
using EksiSozlukAPI.Domain.Entities;

namespace EksiSozlukAPI.Persistence.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommandRequest, User>().ReverseMap();
            CreateMap<CreateTitleCommandRequest, Title>().ReverseMap();
            CreateMap<CreateEntryCommandRequest, Entry>().ReverseMap();
        }
    }
}
