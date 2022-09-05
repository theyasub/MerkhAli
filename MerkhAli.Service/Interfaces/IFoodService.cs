using System.Linq.Expressions;
using MerkhAli.Domain.Commons;
using MerkhAli.Domain.Configuration;
using MerkhAli.Domain.Entities.Foods;
using MerkhAli.Service.DTOs;

namespace MerkhAli.Service.Interfaces;

public interface IFoodService
{
    Task<IEnumerable<Food>> GetAllAsync(PaginationParams @params, Expression<Func<Food, bool>> expression = null);
    Task<Food> GetAsync(Expression<Func<Food, bool>> expression = null);
    Task<Food> AddAsync(FoodForCreationDto dto);
    Task<Food> UpdateAsync(long id, FoodForCreationDto dto);
    Task<bool> DeleteAsync(Expression<Func<Food, bool>> expression);
    
}