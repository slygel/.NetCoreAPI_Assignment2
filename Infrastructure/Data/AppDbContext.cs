using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Person> Person { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasData(
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Tai",
                LastName = "Tue",
                BirthDate = DateOnly.FromDateTime(new DateTime(2003, 04, 15)),
                Gender = GenderType.Male,
                BirthPlace = "Ba Vi"
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Thanh",
                LastName = "Tu",
                BirthDate = DateOnly.FromDateTime(new DateTime(2003, 03, 06)),
                Gender = GenderType.Female,
                BirthPlace = "Ba Vi"
            }
        );
    }
}