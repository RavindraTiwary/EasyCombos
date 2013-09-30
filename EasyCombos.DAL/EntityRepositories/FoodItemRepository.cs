using EasyCombos.CodeFirstEntities;
using EasyCombos.DAL.DBInteractions;

namespace EasyCombos.DAL.EntityRepositories
{
    public class FoodItemRepository : EntityRepositoryBase<FoodItem>, IFoodItemRepository
    {
        public FoodItemRepository(IDBFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

}