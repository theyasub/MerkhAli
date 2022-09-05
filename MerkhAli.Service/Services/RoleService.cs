using System.Linq.Expressions;
using AutoMapper;
using MerkhAli.Data.IRepository;
using MerkhAli.Domain.Configuration;
using MerkhAli.Domain.Entities.Employees;
using MerkhAli.Service.DTOs;
using MerkhAli.Service.Exceptions;
using MerkhAli.Service.Helpers;
using MerkhAli.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MerkhAli.Service.Services;

public class RoleService : IRoleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RoleService(IMapper mapper, IRoleRepository roleRepository, IUnitOfWork unitOfWork)
    {
        this._mapper = mapper;
        _unitOfWork = unitOfWork;
    }


   public async Task<IEnumerable<Role>> GetAllAsync(PaginationParams @params, Expression<Func<Role, bool>> expression = null)
    {
        var pagedList = _unitOfWork.RoleRepository.GetAll(expression,  isTracking: false).ToPagedList(@params);

        return await pagedList.ToListAsync();
    }

  
    public async Task<Role> GetAsync(Expression<Func<Role, bool>> expression = null)
    {
        return await _unitOfWork.RoleRepository.GetAsync(expression);
    }
    
    public async Task<Role> AddAsync(RoleForCreationsDto dto)
    {
        // check for exist .. any code
        // ...
        
        // mapping
        var mappedProduct = _mapper.Map<Role>(dto);
        var product = await _unitOfWork.RoleRepository.AddAsync(mappedProduct);

        await _unitOfWork.SaveChangeAsync();

        return product;
    }

    public async Task<Role> UpdateAsync(long id, RoleForCreationsDto dto)
    {
        var product = await _unitOfWork.RoleRepository.GetAsync(p => p.Id.ToString() == id.ToString());
        if (product is null)
            throw new MerkhAliExceptions(404, "Product not found");

        var mappedProduct = _mapper.Map(dto, product);
        mappedProduct.UpdatedAt = DateTime.Now;
        var updatedProduct = await _unitOfWork.RoleRepository.UpdateAsync(mappedProduct);
        await _unitOfWork.SaveChangeAsync();

        return updatedProduct;
    }

    public async Task<bool> DeleteAsync(Expression<Func<Role, bool>> expression)
    {
        var product = await _unitOfWork.RoleRepository.GetAsync(expression);
        if (product is null)
            throw new MerkhAliExceptions(404, "Product not found");

        await _unitOfWork.RoleRepository.DeleteAsync(expression);
        await _unitOfWork.SaveChangeAsync();

        return true;
    }
}