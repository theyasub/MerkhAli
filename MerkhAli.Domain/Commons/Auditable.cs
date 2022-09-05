using MerkhAli.Domain.Enums;

namespace MerkhAli.Domain.Commons;

public interface IAuditable
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; } 
    public State State { get; set; }
}