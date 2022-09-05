namespace MerkhAli.Service.DTOs;

public class FoodForCreationDto
{
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public string Description { get; set; }
    public Guid FoodCategoryId { get; set; }
}