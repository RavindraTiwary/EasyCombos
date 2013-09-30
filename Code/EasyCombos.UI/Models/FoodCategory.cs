using System.Collections.Generic;
using EasyCombos.CodeFirstEntities;

namespace EasyCombos.UI.Models
{
    public class FoodCategoryModel
    {
        public int FoodCategoryId { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        public virtual List<FoodItemModel> FoodItems { get; set; }

        #region conversion methods
        public FoodCategory GetEntity(FoodCategoryModel model)
        {
            return new FoodCategory()
            {
                FoodCategoryId = model.FoodCategoryId,
                Name = model.Name,
                Unit = model.Unit,
                Description = model.Description,
            };
        }
        public List<FoodCategory> GetEntity(List<FoodCategoryModel> models)
        {
            return models.ConvertAll(x => GetEntity(x));
        }
        public FoodCategoryModel GetModel(FoodCategory entity)
        {
            return new FoodCategoryModel
            {
                FoodCategoryId = entity.FoodCategoryId,
                Name = entity.Name,
                Unit = entity.Unit,
                Description = entity.Description,
            };
        }

        public List<FoodCategoryModel> GetModel(List<FoodCategory> entity)
        {
            return entity.ConvertAll(x => GetModel(x));
        }
        #endregion
    }
}
