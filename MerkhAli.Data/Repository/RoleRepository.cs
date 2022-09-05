using MerkhAli.Data.Contexts;
using MerkhAli.Data.IRepository;
using MerkhAli.Domain.Entities.Employees;

namespace MerkhAli.Data.Repository;

public class RoleRepository : GenericRepository<Role>,IRoleRepository
{
    public RoleRepository(MerkhAliDbContext dbContext) : base(dbContext)
    {
    }
}