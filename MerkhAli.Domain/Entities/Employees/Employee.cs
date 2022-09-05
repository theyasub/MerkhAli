using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MerkhAli.Domain.Commons;
using MerkhAli.Domain.Enums;

namespace MerkhAli.Domain.Entities.Employees;
#pragma warning disable
public class Employee : IAuditable
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public State State { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime Birthday { get; set; }
    
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }
    
    [DataType(DataType.EmailAddress)]
    public string Gmail { get; set; }
    
    public long JobTypeId { get; set; }
    [NotMapped,JsonIgnore]
    [ForeignKey(nameof(JobTypeId))]
    public Role JobType { get; set; }
}