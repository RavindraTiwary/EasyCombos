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
    public class FoodCategoryController : Controller
    {
        private readonly IFoodCategoryService _foodCategoryService;
        private FoodCategoryModel _foodCategoryModel = new FoodCategoryModel();

        public FoodCategoryController(IFoodCategoryService foodCategoryService)
        {
            _foodCategoryService = foodCategoryService;
        }


        public ViewResult Index()
        {
            ViewBag.Message = "Index";
            var foodCategories = _foodCategoryService.GetFoodCategory().ToList();
            return View(_foodCategoryModel.GetModel(foodCategories));
        }


        public ViewResult Details(int id)
        {
            FoodCategory foodcategory = _foodCategoryService.GetFoodCategoryById(id);
            return View(_foodCategoryModel.GetModel(foodcategory));
        }


        public ActionResult Create()
        {
            return View();
        } 


        [HttpPost]
        public ActionResult Create(FoodCategory foodcategory)
        {
            if (ModelState.IsValid)
            {
                _foodCategoryService.CreateFoodCategory(foodcategory);
                return RedirectToAction("Index");  
            }

            return View(_foodCategoryModel.GetModel(foodcategory));
        }
        
 
        public ActionResult Edit(int id)
        {
            FoodCategory foodcategory = _foodCategoryService.GetFoodCategoryById(id);
            return View(_foodCategoryModel.GetModel(foodcategory));
        }

        [HttpPost]
        public ActionResult Edit(FoodCategory foodcategory)
        {
            if (ModelState.IsValid)
            {
                _foodCategoryService.UpdateFoodCategory(foodcategory);
                return RedirectToAction("Index");
            }
            return View(_foodCategoryModel.GetModel(foodcategory));
        }
 
        public ActionResult Delete(int id)
        {
            FoodCategory foodcategory = _foodCategoryService.GetFoodCategoryById(id);
            return View(_foodCategoryModel.GetModel(foodcategory));
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            _foodCategoryService.DeleteFoodCategory(id);
            return RedirectToAction("Index");
        }
    }
}