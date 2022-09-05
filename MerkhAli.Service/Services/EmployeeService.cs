using System.Linq.Expressions;
using AutoMapper;
using MerkhAli.Data.IRepository;
using MerkhAli.Domain.Commons;
using MerkhAli.Domain.Configuration;
using MerkhAli.Domain.Entities.Employees;
using MerkhAli.Domain.Enums;
using MerkhAli.Service.DTOs;
using MerkhAli.Service.Exceptions;
using MerkhAli.Service.Helpers;
using MerkhAli.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MerkhAli.Service.Services;

public class EmployeeService : IEmployeeService
{
    
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeService(IMapper mapper, IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        this._mapper = mapper;
        _unitOfWork = unitOfWork;
    }


   public async Task<IEnumerable<Employee>> GetAllAsync(PaginationParams @params, Expression<Func<Employee, bool>> expression = null)
    {
        var pagedList = _unitOfWork.EmployeeRepository.GetAll(expression,  isTracking: false).ToPagedList(@params);

        return await pagedList.ToListAsync();
    }
   

    public async Task<Employee> GetAsync(Expression<Func<Employee, bool>> expression = null)
    {
        return await _unitOfWork.EmployeeRepository.GetAsync(expression);
    }

    public async Task<Employee> AddAsync(EmployeeForCreationDto dto)
    {
        // check for exist .. any code
        // ...
        
        // mapping
        var mappedProduct = _mapper.Map<Employee>(dto);
        var product = await _unitOfWork.EmployeeRepository.AddAsync(mappedProduct);

        await _unitOfWork.SaveChangeAsync();

        return product;
    }

    public async Task<Employee> UpdateAsync(long id, EmployeeForCreationDto dto)
    {
        var product = await _unitOfWork.EmployeeRepository.GetAsync(p => p.Id.ToString() == id.ToString());
        if (product is null)
            throw new MerkhAliExceptions(404, "Product not found");

        var mappedProduct = _mapper.Map(dto, product);
        var updatedProduct = await _unitOfWork.EmployeeRepository.UpdateAsync(mappedProduct);
        await _unitOfWork.SaveChangeAsync();

        return updatedProduct;
    }

    public async Task<bool> DeleteAsync(Expression<Func<Employee, bool>> expression)
    {
        var product = await _unitOfWork.EmployeeRepository.GetAsync(expression);
        if (product is null)
            throw new MerkhAliExceptions(404, "Product not found");

        await _unitOfWork.EmployeeRepository.DeleteAsync(expression);
        await _unitOfWork.SaveChangeAsync();

        return true;
    }
}