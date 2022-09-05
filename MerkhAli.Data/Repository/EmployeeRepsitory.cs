using MerkhAli.Data.Contexts;
using MerkhAli.Data.IRepository;
using MerkhAli.Domain.Entities.Employees;

namespace MerkhAli.Data.Repository;

public class EmployeeRepsitory : GenericRepository<Employee>,IEmployeeRepository
{
    public EmployeeRepsitory(MerkhAliDbContext dbContext) : base(dbContext)
    {
    }
}