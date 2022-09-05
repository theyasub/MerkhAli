using System;
using System.Threading.Tasks;
using MerkhAli.Domain.Configuration;
using MerkhAli.Domain.Entities.Employees;
using MerkhAli.Service.DTOs;
using MerkhAli.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MerkhAli.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    
    
    
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _employeeService.GetAllAsync(@params));

    [HttpGet("{Id}")]
    public async ValueTask<IActionResult> GetAsync([FromRoute(Name = "Id")] long id)
        => Ok(await _employeeService.GetAsync(p => p.Id == id));

    [HttpPost]
    public async Task<ActionResult<Role>> AddAsync(EmployeeForCreationDto dto)
        => Ok(await _employeeService.AddAsync(dto));

    [HttpPut("{Id}")]
    public async Task<ActionResult<Role>> UpdateAsync([FromRoute(Name = "Id")] long id, EmployeeForCreationDto dto)
        => Ok(await _employeeService.UpdateAsync(id, dto));

    [HttpDelete("{Id}")]
    public async Task<ActionResult<bool>> DeleteAsync([FromRoute(Name = "Id")] long id)
        => Ok(await _employeeService.DeleteAsync(p => p.Id == id));

}