using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces;

public interface IPersonRepository
{
    List<Person> GetAllPersons();
    Person? AddPerson(PersonRequestDto personRequestDto);
    bool UpdatePerson(Guid id, PersonRequestDto taskDto);
    bool DeletePerson(Guid id);
}