using MerkhAli.Data.Contexts;
using MerkhAli.Data.IRepository;
using MerkhAli.Data.Repository;
using MerkhAli.Domain.Entities.Employees;
using MerkhAli.Service.Interfaces;
using MerkhAli.Service.Mappers;
using MerkhAli.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options => 
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<MerkhAliDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ALi")));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepsitory>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IFoodCategoryService, FoodCategoryService>();
builder.Services.AddScoped<IFoodCategoryRepository, FoodCategoryRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();