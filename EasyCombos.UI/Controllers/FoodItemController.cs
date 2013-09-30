using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstServices.Interfaces;
using EasyCombos.CodeFirstEntities;
using EasyCombos.DAL;
using EasyCombos.UI.Models;

namespace EasyCombos.UI.Controllers
{ 
    public class FoodItemController : Controller
    {
        private readonly IFoodItemService _foodItemService;
        private readonly IOfferTypeService _offerTypeService;
        private FoodItemModel _foodItemModel = new FoodItemModel();

        public FoodItemController(IFoodItemService foodItemService, IOfferTypeService offerTypeService)
        {
            _foodItemService = foodItemService;
            _offerTypeService = offerTypeService;
        }


        public ViewResult Index()
        {
            var fooditems = _foodItemService.GetFoodItem().ToList();
            return View(_foodItemModel.GetModel(fooditems));
        }

        public ViewResult Details(int id)
        {
            FoodItem fooditem = _foodItemService.GetFoodItemById(id);
            return View(_foodItemModel.GetModel(fooditem));
        }

        public ActionResult Create()
        {
            ViewBag.FoodCategoryId = new SelectList(_foodItemService.GetFoodItem().ToList(), "FoodCategoryId", "Name");
            ViewBag.OfferTypeId = new SelectList(_offerTypeService.GetOfferType(), "OfferTypeId", "Name");
            return View();
        } 


        [HttpPost]
        public ActionResult Create(FoodItem fooditem)
        {
            if (ModelState.IsValid)
            {
                _foodItemService.CreateFoodItem(fooditem);
                return RedirectToAction("Index");
            }

            ViewBag.FoodCategoryId = new SelectList(_foodItemService.GetFoodItem().ToList(), "FoodCategoryId", "Name", fooditem.FoodCategoryId);
            ViewBag.OfferTypeId = new SelectList(_offerTypeService.GetOfferType(), "OfferTypeId", "Name", fooditem.OfferTypeId);
            return View(_foodItemModel.GetModel(fooditem));
        }
        
 
        public ActionResult Edit(int id)
        {
            FoodItem fooditem = _foodItemService.GetFoodItemById(id);
            ViewBag.FoodCategoryId = new SelectList(_foodItemService.GetFoodItem().ToList(), "FoodCategoryId", "Name", fooditem.FoodCategoryId);
            ViewBag.OfferTypeId = new SelectList(_offerTypeService.GetOfferType(), "OfferTypeId", "Name", fooditem.OfferTypeId);
            return View(_foodItemModel.GetModel(fooditem));
        }

        [HttpPost]
        public ActionResult Edit(FoodItem fooditem)
        {
            if (ModelState.IsValid)
            {
               _foodItemService.UpdateFoodItem(fooditem);
                return RedirectToAction("Index");
            }
            ViewBag.FoodCategoryId = new SelectList(_foodItemService.GetFoodItem().ToList(), "FoodCategoryId", "Name", fooditem.FoodCategoryId);
            ViewBag.OfferTypeId = new SelectList(_offerTypeService.GetOfferType(), "OfferTypeId", "Name", fooditem.OfferTypeId);
            return View(_foodItemModel.GetModel(fooditem));
        }

        public ActionResult Delete(int id)
        {
            FoodItem fooditem = _foodItemService.GetFoodItemById(id);
            return View(_foodItemModel.GetModel(fooditem));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            _foodItemService.DeleteFoodItem(id);
            return RedirectToAction("Index");
        }
    }
}