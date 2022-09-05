using System.Linq.Expressions;
using MerkhAli.Domain.Commons;
using MerkhAli.Domain.Configuration;
using MerkhAli.Domain.Entities.Employees;
using MerkhAli.Domain.Entities.Foods;
using MerkhAli.Service.DTOs;

namespace MerkhAli.Service.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAllAsync(PaginationParams @params, Expression<Func<Employee, bool>> expression = null);
    Task<Employee> GetAsync(Expression<Func<Employee, bool>> expression = null);
    Task<Employee> AddAsync(EmployeeForCreationDto dto);
    Task<Employee> UpdateAsync(long id, EmployeeForCreationDto dto);
    Task<bool> DeleteAsync(Expression<Func<Employee, bool>> expression);
    
}