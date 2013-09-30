using System.Collections.Generic;
using EasyCombos.CodeFirstEntities;

namespace CodeFirstServices.Interfaces
{
    public interface IOfferTypeService
    {
        IEnumerable<OfferType> GetOfferType();

        OfferType GetOfferTypeById(int id);

        void CreateOfferType(OfferType OfferType);

        void UpdateOfferType(OfferType OfferType);

        void DeleteOfferType(int id);

        void SaveOfferType();
    }
}
