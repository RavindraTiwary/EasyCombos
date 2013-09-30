using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstServices.Interfaces;
using CodeFirstServices.Services;
using EasyCombos.CodeFirstEntities;
using EasyCombos.DAL;
using EasyCombos.UI.Models;

namespace EasyCombos.UI.Controllers
{ 
    public class OfferTypeController : Controller
    {
        private readonly IOfferTypeService _OfferTypeService;
        private OfferTypeModel offerTypeModel = new OfferTypeModel();

        public OfferTypeController(IOfferTypeService OfferTypeService)
        {
            _OfferTypeService = OfferTypeService;
        }


        public ViewResult Index()
        {
            var OfferTypes = _OfferTypeService.GetOfferType().ToList();
            var offerTypeModels = offerTypeModel.GetModel(OfferTypes);
            return View(offerTypeModels);
        }


        public ViewResult Details(int id)
        {
            var OfferType = _OfferTypeService.GetOfferTypeById(id);
            var offerTypeModels = offerTypeModel.GetModel(OfferType);
            return View(offerTypeModels);
        }


        public ActionResult Create()
        {
            return View();
        } 


        [HttpPost]
        public ActionResult Create(OfferTypeModel OfferType)
        {
            if (ModelState.IsValid)
            {
                _OfferTypeService.CreateOfferType(offerTypeModel.GetEntity(OfferType));
                return RedirectToAction("Index");  
            }

            return View(OfferType);
        }
        
 
        public ActionResult Edit(int id)
        {
            OfferType OfferType = _OfferTypeService.GetOfferTypeById(id);
            return View(offerTypeModel.GetModel(OfferType));
        }


        [HttpPost]
        public ActionResult Edit(OfferTypeModel OfferType)
        {
            if (ModelState.IsValid)
            {
                _OfferTypeService.UpdateOfferType(offerTypeModel.GetEntity(OfferType));
                return RedirectToAction("Index");
            }
            return View(OfferType);
        }

 
        public ActionResult Delete(int id)
        {
            OfferType OfferType = _OfferTypeService.GetOfferTypeById(id);
            return View(offerTypeModel.GetModel(OfferType));
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            _OfferTypeService.DeleteOfferType(id);
            return RedirectToAction("Index");
        }
    }
}