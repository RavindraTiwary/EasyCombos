using System.Collections.Generic;
using System.ServiceModel;
using EasyCombos.CodeFirstEntities;

namespace EasyCombos.WCF.Interfaces
{
     [ServiceContract]
    public interface IOfferTypeService
    {
        [OperationContract]
        IEnumerable<OfferType> GetOfferType();

        [OperationContract]
        OfferType GetOfferTypeById(int id);

        [OperationContract]
        void CreateOfferType(OfferType offerType);

        [OperationContract]
        void UpdateOfferType(OfferType offerType);

        [OperationContract]
        void DeleteOfferType(int id);

        [OperationContract]
        void SaveOfferType();
    }
}
