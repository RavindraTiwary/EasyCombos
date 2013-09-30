using System.Collections.Generic;
using EasyCombos.CodeFirstEntities;
using EasyCombos.DAL.DBInteractions;
using EasyCombos.DAL.EntityRepositories;
using EasyCombos.WCF.Interfaces;

namespace EasyCombos.WCF.Services
{
    public class FoodCategoryService : IFoodCategoryService
    {
        private readonly IFoodCategoryRepository _foodCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FoodCategoryService()
        {
        }

        public FoodCategoryService(IFoodCategoryRepository foodCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._foodCategoryRepository = foodCategoryRepository;
            this._unitOfWork = unitOfWork;
        }
        #region IFoodCategoryService Members

        public IEnumerable<FoodCategory> GetFoodCategory()
        {
            var foodCategories = _foodCategoryRepository.GetAll();
            return foodCategories;
        }

        public FoodCategory GetFoodCategoryById(int id)
        {
            var foodCategory = _foodCategoryRepository.GetById(id);
            return foodCategory;
        }

        public void CreateFoodCategory(FoodCategory foodCategory)
        {
            _foodCategoryRepository.Add(foodCategory);
            _unitOfWork.Commit();
        }

        public void DeleteFoodCategory(int id)
        {
            var foodCategory = _foodCategoryRepository.GetById(id);
            _foodCategoryRepository.Delete(foodCategory);
            _unitOfWork.Commit();
        }

        public void UpdateFoodCategory(FoodCategory foodCategory)
        {
            _foodCategoryRepository.Update(foodCategory);
            _unitOfWork.Commit();
        }

        public void SaveFoodCategory()
        {
            _unitOfWork.Commit();
        }

        #endregion
    }
}
