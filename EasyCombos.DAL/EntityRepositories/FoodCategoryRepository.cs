using EasyCombos.CodeFirstEntities;
using EasyCombos.DAL.DBInteractions;

namespace EasyCombos.DAL.EntityRepositories
{
    public class FoodCategoryRepository : EntityRepositoryBase<FoodCategory>, IFoodCategoryRepository
    {
        public FoodCategoryRepository(IDBFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

}