using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public PersonService(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }
    
    public List<PersonResponseDto> GetAllPersons()
    {
        var persons = _personRepository.GetAllPersons();
        return _mapper.Map<List<PersonResponseDto>>(persons);
    }

    public PersonResponseDto? AddPerson(PersonRequestDto personRequestDto)
    {
        var person = _personRepository.AddPerson(personRequestDto);
        return person != null ? _mapper.Map<PersonResponseDto>(person) : null;
    }

    public bool UpdatePerson(Guid id, PersonRequestDto personRequestDto)
    {
        return _personRepository.UpdatePerson(id, personRequestDto);
    }

    public bool DeletePerson(Guid id)
    {
        return _personRepository.DeletePerson(id);
    }

    public List<PersonResponseDto> FilterPersons(string? name, GenderType? gender, string? birthPlace)
    {
        var persons = _personRepository.GetAllPersons().AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            persons = persons.Where(p => (p.FirstName + " " + p.LastName).Contains(name));
        }

        if (gender.HasValue)
        {
            persons = persons.Where(p => p.Gender == gender.Value);
        }

        if (!string.IsNullOrEmpty(birthPlace))
        {
            persons = persons.Where(p => p.BirthPlace != null && p.BirthPlace.Contains(birthPlace));
        }

        return _mapper.Map<List<PersonResponseDto>>(persons.ToList());
    }
}