using System.Linq.Expressions;
using MerkhAli.Domain.Commons;
using MerkhAli.Domain.Configuration;
using MerkhAli.Domain.Entities.Employees;
using MerkhAli.Service.DTOs;

namespace MerkhAli.Service.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetAllAsync(PaginationParams @params, Expression<Func<Role, bool>> expression = null);
    Task<Role> GetAsync(Expression<Func<Role, bool>> expression = null);
    Task<Role> AddAsync(RoleForCreationsDto dto);
    Task<Role> UpdateAsync(long id, RoleForCreationsDto dto);
    Task<bool> DeleteAsync(Expression<Func<Role, bool>> expression);
}