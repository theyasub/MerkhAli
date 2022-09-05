using MerkhAli.Data.Contexts;
using MerkhAli.Data.IRepository;
using MerkhAli.Domain.Entities.Foods;

namespace MerkhAli.Data.Repository;

public class FoodCategoryRepository : GenericRepository<FoodCategory> , IFoodCategoryRepository
{
    public FoodCategoryRepository(MerkhAliDbContext dbContext) : base(dbContext)
    {
    }
}