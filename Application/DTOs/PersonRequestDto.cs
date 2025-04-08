using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.DTOs;

public class PersonRequestDto
{
    [Required(ErrorMessage = "First name is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
    public string? FirstName { get; set; }
    
    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters")]
    public string? LastName { get; set; }
    
    [Required(ErrorMessage = "Date of birth is required")]
    [DataType(DataType.Date)]
    public DateOnly BirthDate { get; set; }
    
    [Required(ErrorMessage = "Gender is required")]
    public GenderType Gender { get; set; }
    
    [Required(ErrorMessage = "Birth place is required")]
    [StringLength(100, ErrorMessage = "First cant exceed 100 characters")]
    public string? BirthPlace { get; set; }
}