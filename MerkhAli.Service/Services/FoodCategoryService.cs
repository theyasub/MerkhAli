using System.Linq.Expressions;
using AutoMapper;
using MerkhAli.Data.IRepository;
using MerkhAli.Domain.Configuration;
using MerkhAli.Domain.Entities.Foods;
using MerkhAli.Service.DTOs;
using MerkhAli.Service.Exceptions;
using MerkhAli.Service.Helpers;
using MerkhAli.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MerkhAli.Service.Services;

public class FoodCategoryService : IFoodCategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public FoodCategoryService(IFoodCategoryRepository foodCategoryRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
       
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public  async Task<IEnumerable<FoodCategory>> GetAllAsync(PaginationParams @params, Expression<Func<FoodCategory, bool>> expression = null)
    {
        var pagedList = _unitOfWork.FoodCategoryRepository.GetAll(expression,  isTracking: false).ToPagedList(@params);

        return await pagedList.ToListAsync();
    }

    public async Task<FoodCategory> GetAsync(Expression<Func<FoodCategory, bool>> expression = null)
    {
        var res  = await _unitOfWork.FoodCategoryRepository.GetAsync(expression);
        if (res is null)
            throw new MerkhAliExceptions(404, "Product not found");
        await _unitOfWork.FoodCategoryRepository.SaveChangesAsync();
        return res;
    }

  

    public async Task<FoodCategory> AddAsync(FoodCategoryForCreationDto dto)
    {
        var mappedProduct = _mapper.Map<FoodCategory>(dto);
        var product = await _unitOfWork.FoodCategoryRepository.AddAsync(mappedProduct);

        await _unitOfWork.SaveChangeAsync();

        return product;
    }


    public async Task<FoodCategory> UpdateAsync(long id, FoodCategoryForCreationDto dto)
    {
        var product = await _unitOfWork.FoodCategoryRepository.GetAsync(p => p.Id.ToString() == id.ToString());
        if (product is null)
            throw new MerkhAliExceptions(404, "Product category not found");

        var mappedProduct = _mapper.Map(dto, product);
        mappedProduct.UpdatedAt = DateTime.Now;
        var updatedProduct = await _unitOfWork.FoodCategoryRepository.UpdateAsync(mappedProduct);
        await _unitOfWork.SaveChangeAsync();

        return updatedProduct;
    }

    public async Task<bool> DeleteAsync(Expression<Func<FoodCategory, bool>> expression)
    {
        var product = await _unitOfWork.FoodCategoryRepository.GetAsync(expression);
        if (product is null)
            throw new MerkhAliExceptions(404, "Product category not found");

        await _unitOfWork.FoodCategoryRepository.DeleteAsync(expression);
        await _unitOfWork.SaveChangeAsync();

        return true;
    }
}