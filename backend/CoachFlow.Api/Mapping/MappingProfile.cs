using AutoMapper;
using CoachFlow.Api.DTOs;
using CoachFlow.Api.Models;

namespace CoachFlow.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Client, ClientDto>();
        CreateMap<CreateClientDto, Client>();
    }
}
