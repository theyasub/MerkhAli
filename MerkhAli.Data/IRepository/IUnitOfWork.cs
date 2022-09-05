using MerkhAli.Data.Contexts;

namespace MerkhAli.Data.IRepository;

public interface IUnitOfWork : IDisposable
{
   IEmployeeRepository EmployeeRepository { get; }
   IFoodRepository FoodRepository { get; }
   IFoodCategoryRepository FoodCategoryRepository { get; }
   IRoleRepository RoleRepository { get; }
   Task SaveChangeAsync();

  
}