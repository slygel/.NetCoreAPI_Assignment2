using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers;

public class PersonMapper : Profile
{
    public PersonMapper()
    {
        CreateMap<Person, PersonResponseDto>(); 
        CreateMap<PersonRequestDto, Person>();
    }
}