using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces;

public interface IPersonService
{
    List<PersonResponseDto> GetAllPersons();
    PersonResponseDto? AddPerson(PersonRequestDto personRequestDto);
    bool UpdatePerson(Guid id, PersonRequestDto personRequestDto);
    bool DeletePerson(Guid id);
    List<PersonResponseDto> FilterPersons(string? name, GenderType? gender, string? birthPlace);
}