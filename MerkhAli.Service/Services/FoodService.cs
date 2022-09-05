using System.Linq.Expressions;
using AutoMapper;
using MerkhAli.Data.IRepository;
using MerkhAli.Domain.Configuration;
using MerkhAli.Domain.Entities.Employees;
using MerkhAli.Domain.Entities.Foods;
using MerkhAli.Service.DTOs;
using MerkhAli.Service.Exceptions;
using MerkhAli.Service.Helpers;
using MerkhAli.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MerkhAli.Service.Services;

public class FoodService : IFoodService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FoodService(IFoodRepository foodRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Food>> GetAllAsync(PaginationParams @params, Expression<Func<Food, bool>> expression = null)
    {
        var pagedList = _unitOfWork.FoodRepository.GetAll(expression,  isTracking: false).ToPagedList(@params);

        return await pagedList.ToListAsync();
    }

    public async Task<Food> GetAsync(Expression<Func<Food, bool>> expression = null)
    {
        var res  = await _unitOfWork.FoodRepository.GetAsync(expression);
        if (res is null)
            throw new MerkhAliExceptions(404, "Product not found");
        await _unitOfWork.SaveChangeAsync();
        return res;
    }

  

    public async Task<Food> AddAsync(FoodForCreationDto dto)
    {
        // check for exist .. any code
        // ...
        
        // mapping
        var mappedProduct = _mapper.Map<Food>(dto);
        var product = await _unitOfWork.FoodRepository.AddAsync(mappedProduct);

        await _unitOfWork.SaveChangeAsync();

        return product;
    }

    public async Task<Food> UpdateAsync(long id, FoodForCreationDto dto)
    {
        var product = await _unitOfWork.FoodRepository.GetAsync(p => p.Id.ToString() == id.ToString());
        if (product is null)
            throw new MerkhAliExceptions(404, "Product not found");

        var mappedProduct = _mapper.Map(dto, product);
        mappedProduct.UpdatedAt = DateTime.Now;
        var updatedProduct = await _unitOfWork.FoodRepository.UpdateAsync(mappedProduct);
        await _unitOfWork.SaveChangeAsync();

        return updatedProduct;
    }

    public async Task<bool> DeleteAsync(Expression<Func<Food, bool>> expression)
    {
        var product = await _unitOfWork.FoodRepository.GetAsync(expression);
        if (product is null)
            throw new MerkhAliExceptions(404, "Product not found");

        await _unitOfWork.FoodRepository.DeleteAsync(expression);
        await _unitOfWork.SaveChangeAsync();

        return true;
    }
}