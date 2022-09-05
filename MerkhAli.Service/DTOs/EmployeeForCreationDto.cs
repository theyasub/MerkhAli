using System.ComponentModel.DataAnnotations;

namespace MerkhAli.Service.DTOs;
#pragma warning disable
public class EmployeeForCreationDto
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public DateTime Birthday { get; set; }
    
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }
    
    [DataType(DataType.EmailAddress)]
    public string Gmail { get; set; }
    
    public Guid JobTypeId { get; set; }
}