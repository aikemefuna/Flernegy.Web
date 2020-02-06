using Flenergy.Data.Models;
using Flenergy.Data.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flenergy.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IEstateRepository _estateRepository;

        public CategoryController(IBillingRepository billingRepository, IEstateRepository estateRepository)
        {
            _billingRepository = billingRepository;
            _estateRepository = estateRepository;
        }
        public async Task<IActionResult> Categories(string s )
        {
            try
            {
                if (s != null)
                {
                    ViewBag.Deleted = "Yes";
                }
                var catList = await _billingRepository.GetAll();
                ViewBag.PageName = "Categories";
                if (await _billingRepository.Count() > 4)
                {

                    //var firstEstates = estateList.OrderByDescending(c => c.DateCreated).Take(4);
                    var firstFourCategories = catList.Take(4);
                    foreach (var cat in firstFourCategories)
                    {
                        await _billingRepository.GetCountOfCustomersForACategory(cat.BillingCategoryId);

                    }
                    ViewBag.fiveCategory = firstFourCategories;
                    ViewBag.Categories = catList;
                }
                foreach (var cat in catList)
                {
                    await _billingRepository.GetCountOfCustomersForACategory(cat.BillingCategoryId);
                }
                ViewBag.Categories = catList;
                ViewBag.Estates = new SelectList(await _estateRepository.GetAll(), "EstateId", "EstateName");
                return View();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Create(BillingCategory billingCategory)
        {
            try
            {
                var cattobeAdded = await _billingRepository.InsertAsync(billingCategory);
                if (cattobeAdded != null)
                {
                    return RedirectToAction(nameof(Categories));
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }


        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var categorytoDelete = await _billingRepository.GetByIdAsync(id);
                var deleteCount = await _billingRepository.DeleteAsync(categorytoDelete);
                if (deleteCount > 0)
                {
                    return RedirectToAction(nameof(Categories));
                }
                else
                {
                    return RedirectToAction("Categories", new { s = "?" });
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        [AllowAnonymous]
        public async Task<JsonResult> GetEstates(int id)
        {
            var esate = await _estateRepository.GetByIdAsync(id);
            List<Estate> list = new List<Estate>();
            var estates = await _estateRepository.GetAll();
            list = estates.ToList();
            list.Insert(0, new Estate { EstateId = id, EstateName = esate.EstateName });
            return Json(new SelectList(list, "EstateId", "EstateName"));
        }


        public async Task<IActionResult> EditCategory(int id)
        {
            try
            {
                var category = await _billingRepository.GetByIdAsync(id);
                if (category != null)
                {
                    return Json(category);
                    //return RedirectToAction("Estate", new { id = estate.EstateId });
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<JsonResult> EditCategory(BillingCategory billingCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    var cattoEdit = await _billingRepository.GetByIdAsync(billingCategory.BillingCategoryId);
                    cattoEdit.EstateId = billingCategory.EstateId;
                    cattoEdit.BillingAmount = billingCategory.BillingAmount;
                    cattoEdit.BillingAmount = billingCategory.BillingAmount;
                   

                    var catAdded = await _billingRepository.Update(billingCategory.BillingCategoryId, cattoEdit);
                    if (catAdded != null)
                    {
                        return Json(catAdded);
                    }

                }
                catch (Exception)
                {
                    return Json(false);
                    throw;
                }
            }
            return Json(false);
        }
       
        public async Task<IActionResult> EstateBillingCategory(int id)
        {
            try
            {
                var estate = await _estateRepository.GetByIdAsync(id);
                if (estate != null)
                {
                    return Json(estate);
                    //return RedirectToAction("Estate", new { id = estate.EstateId });
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
