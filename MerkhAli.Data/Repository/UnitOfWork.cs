using MerkhAli.Data.Contexts;
using MerkhAli.Data.IRepository;

namespace MerkhAli.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(MerkhAliDbContext dbContext, IEmployeeRepository employeeRepository, IFoodRepository foodRepository, IFoodCategoryRepository foodCategoryRepository, IRoleRepository roleRepository)
    {
        DbContext = dbContext;
        EmployeeRepository = employeeRepository;
        FoodRepository = foodRepository;
        FoodCategoryRepository = foodCategoryRepository;
        RoleRepository = roleRepository;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public MerkhAliDbContext DbContext;
    public IEmployeeRepository EmployeeRepository { get; }
    public IFoodRepository FoodRepository { get; }
    public IFoodCategoryRepository FoodCategoryRepository { get; }
    public IRoleRepository RoleRepository { get; }
    public async Task SaveChangeAsync()
    {
        await DbContext.SaveChangesAsync();
    }
}