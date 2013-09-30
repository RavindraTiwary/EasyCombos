using System.Collections.Generic;
using EasyCombos.CodeFirstEntities;

namespace EasyCombos.UI.Models
{
    public class OfferTypeModel
    {
        public OfferTypeModel()
        {
            this.FoodItems = new List<FoodItemModel>();
        }
        public int OfferTypeId { get; set; }
        public string Name { get; set; }
        public  IList<FoodItemModel> FoodItems { get; set; }

        #region conversion methods

        public OfferType GetEntity(OfferTypeModel model)
        {
            return new OfferType
            {
                OfferTypeId = model.OfferTypeId,
                Name = model.Name
            };
        }
        public List<OfferType> GetEntity(List<OfferTypeModel> models)
        {
            return models.ConvertAll(x => GetEntity(x));
        }
        public OfferTypeModel GetModel(OfferType offerType)
        {
            return new OfferTypeModel()
            {
                OfferTypeId = offerType.OfferTypeId,
                Name = offerType.Name
            };
        }

        public List<OfferTypeModel> GetModel(List<OfferType> offerTypes)
        {
            return offerTypes.ConvertAll(x => GetModel(x));
        }
        #endregion
    }
}
