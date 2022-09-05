using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MerkhAli.Domain.Commons;
using MerkhAli.Domain.Enums;

namespace MerkhAli.Domain.Entities.Foods;


#pragma warning disable
public class Food : IAuditable
{
    
    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public string Description { get; set; }

    public string FoodCategoryName => FoodCategory?.Name;
    public long FoodCategoryId { get; set; }
    
    [NotMapped,JsonIgnore]
    [ForeignKey(nameof(FoodCategoryId))]
    public FoodCategory FoodCategory { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public State State { get; set; }
}