using System.Collections.Generic;
using System.ServiceModel;
using EasyCombos.CodeFirstEntities;

namespace EasyCombos.WCF.Interfaces
{
    [ServiceContract]
    public interface IFoodCategoryService
    {
        [OperationContract]
        IEnumerable<FoodCategory> GetFoodCategory();

        [OperationContract]

        FoodCategory GetFoodCategoryById(int id);

        [OperationContract]
        void CreateFoodCategory(FoodCategory foodCategory);

        [OperationContract]
        void UpdateFoodCategory(FoodCategory foodCategory);

        [OperationContract]
        void DeleteFoodCategory(int id);

        [OperationContract]
        void SaveFoodCategory();
    }
}
