using System.Linq.Expressions;
using MerkhAli.Domain.Commons;
using MerkhAli.Domain.Configuration;
using MerkhAli.Domain.Entities.Foods;
using MerkhAli.Service.DTOs;

namespace MerkhAli.Service.Interfaces;

public interface IFoodCategoryService
{

    Task<IEnumerable<FoodCategory>> GetAllAsync(PaginationParams @params, Expression<Func<FoodCategory, bool>> expression = null);
    Task<FoodCategory> GetAsync(Expression<Func<FoodCategory, bool>> expression = null);
    Task<FoodCategory> AddAsync(FoodCategoryForCreationDto dto);
    Task<FoodCategory> UpdateAsync(long id, FoodCategoryForCreationDto dto);
    Task<bool> DeleteAsync(Expression<Func<FoodCategory, bool>> expression);
}