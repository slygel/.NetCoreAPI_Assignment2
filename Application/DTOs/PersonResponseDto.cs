using Domain.Entities;

namespace Application.DTOs;

public class PersonResponseDto
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public GenderType Gender { get; set; }
    public string? BirthPlace { get; set; }
}