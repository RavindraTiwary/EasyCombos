using System.Collections.Generic;
using CodeFirstServices.Interfaces;
using EasyCombos.CodeFirstEntities;
using EasyCombos.DAL.DBInteractions;
using EasyCombos.DAL.EntityRepositories;

namespace CodeFirstServices.Services
{
    public class OfferTypeService : IOfferTypeService
    {
        private readonly IOfferTypeRepository _OfferTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OfferTypeService()
        {
        }

        public OfferTypeService(IOfferTypeRepository OfferTypeRepository, IUnitOfWork unitOfWork)
        {
            this._OfferTypeRepository = OfferTypeRepository;
            this._unitOfWork = unitOfWork;
        }
        #region IOfferTypeService Members

        public IEnumerable<OfferType> GetOfferType()
        {
            var foodCategories = _OfferTypeRepository.GetAll();
            return foodCategories;
        }

        public OfferType GetOfferTypeById(int id)
        {
            var OfferType = _OfferTypeRepository.GetById(id);
            return OfferType;
        }

        public void CreateOfferType(OfferType OfferType)
        {
            _OfferTypeRepository.Add(OfferType);
            _unitOfWork.Commit();
        }

        public void DeleteOfferType(int id)
        {
            var OfferType = _OfferTypeRepository.GetById(id);
            _OfferTypeRepository.Delete(OfferType);
            _unitOfWork.Commit();
        }

        public void UpdateOfferType(OfferType OfferType)
        {
            _OfferTypeRepository.Update(OfferType);
            _unitOfWork.Commit();
        }

        public void SaveOfferType()
        {
            _unitOfWork.Commit();
        }

        #endregion
    }
}
