using MerkhAli.Domain.Commons;
using MerkhAli.Domain.Enums;

namespace MerkhAli.Domain.Entities.Foods;

#pragma warning disable
public class FoodCategory : IAuditable
{
    
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    private IEnumerable<Food> Foods { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public State State { get; set; }
}