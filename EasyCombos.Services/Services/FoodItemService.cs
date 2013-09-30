using System.Collections.Generic;
using CodeFirstServices.Interfaces;
using EasyCombos.CodeFirstEntities;
using EasyCombos.DAL.DBInteractions;
using EasyCombos.DAL.EntityRepositories;

namespace CodeFirstServices.Services
{
    public class FoodItemService : IFoodItemService
    {
        private readonly IFoodItemRepository _FoodItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FoodItemService()
        {
        }

        public FoodItemService(IFoodItemRepository FoodItemRepository, IUnitOfWork unitOfWork)
        {
            this._FoodItemRepository = FoodItemRepository;
            this._unitOfWork = unitOfWork;
        }
        #region IFoodItemService Members

        public IEnumerable<FoodItem> GetFoodItem()
        {
            var foodCategories = _FoodItemRepository.GetAll();
            return foodCategories;
        }

        public FoodItem GetFoodItemById(int id)
        {
            var FoodItem = _FoodItemRepository.GetById(id);
            return FoodItem;
        }

        public void CreateFoodItem(FoodItem FoodItem)
        {
            _FoodItemRepository.Add(FoodItem);
            _unitOfWork.Commit();
        }

        public void DeleteFoodItem(int id)
        {
            var FoodItem = _FoodItemRepository.GetById(id);
            _FoodItemRepository.Delete(FoodItem);
            _unitOfWork.Commit();
        }

        public void UpdateFoodItem(FoodItem FoodItem)
        {
            _FoodItemRepository.Update(FoodItem);
            _unitOfWork.Commit();
        }

        public void SaveFoodItem()
        {
            _unitOfWork.Commit();
        }

        #endregion
    }
}
