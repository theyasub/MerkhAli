using System.ComponentModel.DataAnnotations;
using MerkhAli.Domain.Commons;
using MerkhAli.Domain.Enums;

namespace MerkhAli.Domain.Entities.Employees;

public class Role : IAuditable
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public State State { get; set; }

    [Required]
    public string Name { get; set; }

    private IEnumerable<Employee> Employees { get; set; }
}