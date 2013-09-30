using System.Collections.Generic;
using EasyCombos.CodeFirstEntities;

namespace CodeFirstServices.Interfaces
{
    public interface IFoodCategoryService
    {
        IEnumerable<FoodCategory> GetFoodCategory();

        FoodCategory GetFoodCategoryById(int id);

        void CreateFoodCategory(FoodCategory foodCategory);

        void UpdateFoodCategory(FoodCategory foodCategory);

        void DeleteFoodCategory(int id);

        void SaveFoodCategory();
    }
}
