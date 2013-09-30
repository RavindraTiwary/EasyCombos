using System.Collections.Generic;
using System.ServiceModel;
using EasyCombos.CodeFirstEntities;

namespace EasyCombos.WCF.Interfaces
{
    [ServiceContract]
    public interface IFoodItemService
    {
        [OperationContract]
        IEnumerable<FoodItem> GetFoodItem();

        [OperationContract]
        FoodItem GetFoodItemById(int id);

        [OperationContract]
        void CreateFoodItem(FoodItem foodItemoodItem);

        [OperationContract]
        void UpdateFoodItem(FoodItem foodItem);

        [OperationContract]
        void DeleteFoodItem(int id);

        [OperationContract]
        void SaveFoodItem();
    }
}
