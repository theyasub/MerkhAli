using System.Threading.Tasks;
using MerkhAli.Domain.Configuration;
using MerkhAli.Domain.Entities.Employees;
using MerkhAli.Service.DTOs;
using MerkhAli.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MerkhAli.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FoodCategories : ControllerBase
{
    private readonly IFoodCategoryService _categoryService;
    
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _categoryService.GetAllAsync(@params));

    [HttpGet("{Id}")]
    public async ValueTask<IActionResult> GetAsync([FromRoute(Name = "Id")] long id)
        => Ok(await _categoryService.GetAsync(p => p.Id == id));

    [HttpPost]
    public async Task<ActionResult<Role>> AddAsync(FoodCategoryForCreationDto dto)
        => Ok(await _categoryService.AddAsync(dto));

    [HttpPut("{Id}")]
    public async Task<ActionResult<Role>> UpdateAsync([FromRoute(Name = "Id")] long id, FoodCategoryForCreationDto dto)
        => Ok(await _categoryService.UpdateAsync(id, dto));

    [HttpDelete("{Id}")]
    public async Task<ActionResult<bool>> DeleteAsync([FromRoute(Name = "Id")] long id)
        => Ok(await _categoryService.DeleteAsync(p => p.Id == id));


}