using MerkhAli.Domain.Entities.Employees;
using MerkhAli.Domain.Entities.Foods;
using Microsoft.EntityFrameworkCore;

namespace MerkhAli.Data.Contexts;

public class MerkhAliDbContext : DbContext
{
    public MerkhAliDbContext(DbContextOptions<MerkhAliDbContext> options) : base(options)
    {
        
    }

    public DbSet<Food> Foods { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<FoodCategory> FoodCategories { get; set; }

}