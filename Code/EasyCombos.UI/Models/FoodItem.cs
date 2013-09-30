using System.Collections.Generic;
using EasyCombos.CodeFirstEntities;

namespace EasyCombos.UI.Models
{
    public partial class FoodItemModel
    {
        public int FoodItemId { get; set; }
        public string Name { get; set; }
        public int FoodCategoryId { get; set; }
        public double PricePerUnit { get; set; }
        public int QunatityOnHand { get; set; }
        public string Description { get; set; }
        public double OfferedDiscount { get; set; }
        public int OfferTypeId { get; set; }
        public virtual FoodCategoryModel FoodCategory { get; set; }
        public virtual OfferTypeModel OfferType { get; set; }
        public virtual List<OrderModel> Orders { get; set; }

        #region conversion methods
        public FoodItem GetEntity(FoodItemModel model)
        {
            return new FoodItem()
            {
                FoodItemId = model.FoodItemId,
                Name = model.Name,
                FoodCategoryId = model.FoodCategoryId,
                PricePerUnit = model.PricePerUnit,
                QunatityOnHand = model.QunatityOnHand,
                Description = model.Description,
                OfferedDiscount = model.OfferedDiscount,
                OfferTypeId = model.OfferTypeId,
            };
        }
        public List<FoodItem> GetEntity(List<FoodItemModel> models)
        {
            return models.ConvertAll(x => GetEntity(x));
        }
        public FoodItemModel GetModel(FoodItem entity)
        {
            return new FoodItemModel()
            {
                FoodItemId = entity.FoodItemId,
                Name = entity.Name,
                FoodCategoryId = entity.FoodCategoryId,
                PricePerUnit = entity.PricePerUnit,
                QunatityOnHand = entity.QunatityOnHand,
                Description = entity.Description,
                OfferedDiscount = entity.OfferedDiscount,
                OfferTypeId = entity.OfferTypeId,
            };
        }

        public List<FoodItemModel> GetModel(List<FoodItem> entity)
        {
            return entity.ConvertAll(x => GetModel(x));

        }
        #endregion
    }
}
