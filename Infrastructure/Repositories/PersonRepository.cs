using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly AppDbContext _context;

    public PersonRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Person> GetAllPersons()
    {
        return _context.Person.ToList();
    }

    public Person? AddPerson(PersonRequestDto personRequestDto)
    {
        var person = new Person
        {
            Id = Guid.NewGuid(),
            FirstName = personRequestDto.FirstName,
            LastName = personRequestDto.LastName,
            BirthDate = personRequestDto.BirthDate,
            Gender = personRequestDto.Gender,
            BirthPlace = personRequestDto.BirthPlace
        };

        _context.Person.Add(person);
        _context.SaveChanges();
        return person;
    }

    public bool UpdatePerson(Guid id, PersonRequestDto personRequestDto)
    {
        var person = _context.Person.Find(id);
        if (person == null)
        {
            return false;
        }

        person.FirstName = personRequestDto.FirstName;
        person.LastName = personRequestDto.LastName;
        person.BirthDate = personRequestDto.BirthDate;
        person.Gender = personRequestDto.Gender;
        person.BirthPlace = personRequestDto.BirthPlace;

        _context.SaveChanges();
        return true;
    }

    public bool DeletePerson(Guid id)
    {
        var person = _context.Person.Find(id);
        if (person == null)
        {
            return false;
        }

        _context.Person.Remove(person);
        _context.SaveChanges();
        return true;
    }
}