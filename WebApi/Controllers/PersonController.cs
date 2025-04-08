using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/v1/person")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PersonResponseDto>))]
    public IActionResult GetAllPersons()
    {
        var persons = _personService.GetAllPersons();
        return Ok(persons);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PersonResponseDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddPerson([FromBody] PersonRequestDto personRequestDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var person = _personService.AddPerson(personRequestDto);
        if (person == null)
        {
            return BadRequest("Failed to add person");
        }

        return CreatedAtAction(nameof(GetAllPersons), new { id = person.Id }, person);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdatePerson(Guid id, [FromBody] PersonRequestDto personRequestDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var success = _personService.UpdatePerson(id, personRequestDto);
        if (!success)
        {
            return NotFound();
        }

        return Ok("Update success!");
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeletePerson(Guid id)
    {
        var success = _personService.DeletePerson(id);
        if (!success)
        {
            return NotFound("Failed to delete person");
        }
        return Ok("Delete success!");
    }

    [HttpGet("filter")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PersonResponseDto>))]
    public IActionResult FilterPersons(
        [FromQuery] string? name = null,
        [FromQuery] GenderType? gender = null,
        [FromQuery] string? birthPlace = null)
    {
        var persons = _personService.FilterPersons(name, gender, birthPlace);
        return Ok(persons);
    }
}