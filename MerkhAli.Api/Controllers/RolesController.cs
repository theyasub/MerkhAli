using System.Threading.Tasks;
using MerkhAli.Domain.Configuration;
using MerkhAli.Domain.Entities.Employees;
using MerkhAli.Service.DTOs;
using MerkhAli.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MerkhAli.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RolesController : ControllerBase
{
    private readonly IRoleService _roleService;
    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    /// <summary>
    /// Product CRUD
    /// </summary>
    /// <param name="params"></param>
    /// <returns></returns>
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _roleService.GetAllAsync(@params));

    [HttpGet("{Id}")]
    public async ValueTask<IActionResult> GetAsync([FromRoute(Name = "Id")] long id)
        => Ok(await _roleService.GetAsync(p => p.Id == id));

    [HttpPost]
    public async Task<ActionResult<Role>> AddAsync(RoleForCreationsDto dto)
        => Ok(await _roleService.AddAsync(dto));

    [HttpPut("{Id}")]
    public async Task<ActionResult<Role>> UpdateAsync([FromRoute(Name = "Id")] long id, RoleForCreationsDto dto)
        => Ok(await _roleService.UpdateAsync(id, dto));

    [HttpDelete("{Id}")]
    public async Task<ActionResult<bool>> DeleteAsync([FromRoute(Name = "Id")] long id)
        => Ok(await _roleService.DeleteAsync(p => p.Id == id));


}