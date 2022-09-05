using MerkhAli.Data.Contexts;
using MerkhAli.Data.IRepository;
using MerkhAli.Domain.Entities.Foods;

namespace MerkhAli.Data.Repository;

public class FoodRepository : GenericRepository<Food> , IFoodRepository
{
    public FoodRepository(MerkhAliDbContext dbContext) : base(dbContext)
    {
    }
}