using System.Threading.Tasks;
using MerkhAli.Domain.Configuration;
using MerkhAli.Domain.Entities.Employees;
using MerkhAli.Service.DTOs;
using MerkhAli.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MerkhAli.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FoodsController : ControllerBase
{
    private readonly IFoodService _foodService;
    
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _foodService.GetAllAsync(@params));

    [HttpGet("{Id}")]
    public async ValueTask<IActionResult> GetAsync([FromRoute(Name = "Id")] long id)
        => Ok(await _foodService.GetAsync(p => p.Id == id));

    [HttpPost]
    public async Task<ActionResult<Role>> AddAsync(FoodForCreationDto dto)
        => Ok(await _foodService.AddAsync(dto));

    [HttpPut("{Id}")]
    public async Task<ActionResult<Role>> UpdateAsync([FromRoute(Name = "Id")] long id, FoodForCreationDto dto)
        => Ok(await _foodService.UpdateAsync(id, dto));

    [HttpDelete("{Id}")]
    public async Task<ActionResult<bool>> DeleteAsync([FromRoute(Name = "Id")] long id)
        => Ok(await _foodService.DeleteAsync(p => p.Id == id));


}