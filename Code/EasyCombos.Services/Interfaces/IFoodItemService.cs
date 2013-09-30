using System.Collections.Generic;
using EasyCombos.CodeFirstEntities;

namespace CodeFirstServices.Interfaces
{
    public interface IFoodItemService
    {
        IEnumerable<FoodItem> GetFoodItem();

        FoodItem GetFoodItemById(int id);

        void CreateFoodItem(FoodItem FoodItem);

        void UpdateFoodItem(FoodItem FoodItem);

        void DeleteFoodItem(int id);

        void SaveFoodItem();
    }
}
