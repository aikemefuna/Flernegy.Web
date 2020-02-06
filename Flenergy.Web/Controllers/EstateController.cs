using Flenergy.Data.Models;
using Flenergy.Data.Repository.Interface;
using Flenergy.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Flenergy.Web.Controllers
{
    public class EstateController : Controller
    {
        private readonly IEstateRepository _estateRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IBillingRepository _billingRepository;
        private readonly IEstateAdminRepository _estateAdminRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public EstateController(IEstateRepository estateRepository, IHostingEnvironment hostingEnvironment, IBillingRepository billingRepository, IEstateAdminRepository estateAdminRepository, UserManager<ApplicationUser> userManager)

        {
            _estateRepository = estateRepository;
            _hostingEnvironment = hostingEnvironment;
            _billingRepository = billingRepository;
            _estateAdminRepository = estateAdminRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Estate(string s, int id)
        {

            ViewBag.States = new SelectList(await _estateRepository.GetAllStatesAsync(), "StateName", "StateName");

            if (s != null)
            {

                ViewBag.deleted = "Yes";
            }
            ViewBag.PageName = "Estate";
            if (await _estateRepository.Count() > 4)
            {
                var estateList = await _estateRepository.GetAll();
                //var firstEstates = estateList.OrderByDescending(c => c.DateCreated).Take(4);
                var firstEstates = estateList.Take(4);
                foreach (var estate in firstEstates)
                {
                     await _estateRepository.GetCountOfCustomersOfAnEstate(estate.EstateId);

                }
                ViewBag.fiveEstates = firstEstates;
                ViewBag.Estates = estateList;
            }
            var estates = await _estateRepository.GetAll();
            if (id != 0)
            {
                var estateToEdit = await _estateRepository.GetByIdAsync(id);
                var vm = new EstateVM
                {
                    Estates = estates,
                    Estate = estateToEdit
                };
                ViewBag.showEditEstateModal = "Yes";
                return View(vm);
            }
       
          
            
            ViewBag.Estates = estates;
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Create([FromBody]Estate  estate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var files = HttpContext.Request.Form.Files;
                    //foreach (var Image in files)
                    //{
                    //    if (Image != null && Image.Length > 0)
                    //    {

                    //        var file = Image;
                    //        //There is an error here
                    //        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Upload");
                    //        //"/" + Path.GetFileName(pic.FileName)
                    //        if (file.Length > 0)
                    //        {
                    //            //var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                    //            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    //            var extension = Path.GetExtension(file.FileName);
                    //            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    //            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    //            {
                    //                await file.CopyToAsync(fileStream);
                    //            }

                    //            estate.LogoUrl = fileName;
                    //        }
                    //    }
                    //}
                    
                    
                    var estateAdded = await _estateRepository.InsertAsync(estate);
                    var est = await _estateRepository.GetByIdAsync(estateAdded.EstateId);
                    est.EstateCode = est.EstateId;
                    var esttoupdated  = await _estateRepository.Update(est.EstateId,est);
                    if (estateAdded != null)
                    {
                        return Json(estateAdded);
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
        [HttpPost]
        public async Task<JsonResult> CreateEstateAdmin([FromBody]EstateAdmin  estateAdmin, string Password)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var admin = new EstateAdmin
                    {
                         FirstName  = estateAdmin.FirstName,
                         LastName  = estateAdmin.LastName,
                         MiddleName  = estateAdmin.MiddleName,
                         Email  = estateAdmin.Email,
                         PhoneNo  = estateAdmin.PhoneNo,
                         Gender  = estateAdmin.Gender,
                         State  = estateAdmin.State,
                         LGA  = estateAdmin.LGA,
                         Address = estateAdmin.Address,
                        EstateId = estateAdmin.EstateId
                    };

                    var estateAdded = await _estateAdminRepository.InsertAsync(admin);

                    var user = new ApplicationUser
                    {
                        FirstName = estateAdmin.FirstName,
                        LastName = estateAdmin.LastName,
                        PhoneNumber = estateAdmin.PhoneNo,
                        UserName = estateAdmin.Email,
                        Email = estateAdmin.Email,
                      
                        State = estateAdmin.State,
                        LGA = estateAdmin.LGA
                    };
                    var result = await _userManager.CreateAsync(user, estateAdmin.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "EstateAdmin");

                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    if (estateAdded != null)
                    {
                        return Json(true);
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

        public IActionResult Red() => RedirectToAction("Estate", "Estate");
        
        public async Task<IActionResult> EditEstate(int id)
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


        [HttpPost]
        public async Task<JsonResult> EditEstate([FromBody]Estate estate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var files = HttpContext.Request.Form.Files;
                    //foreach (var Image in files)
                    //{
                    //    if (Image != null && Image.Length > 0)
                    //    {

                    //        var file = Image;
                    //        //There is an error here
                    //        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Upload");
                    //        //"/" + Path.GetFileName(pic.FileName)
                    //        if (file.Length > 0)
                    //        {
                    //            //var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                    //            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    //            var extension = Path.GetExtension(file.FileName);
                    //            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    //            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                    //            {
                    //                await file.CopyToAsync(fileStream);
                    //            }

                    //            estate.LogoUrl = fileName;
                    //        }
                    //    }
                    //}
                    var estateToEdit = await _estateRepository.GetByIdAsync(estate.EstateId);
                    estateToEdit.Email = estate.Email;
                    estateToEdit.Address = estate.Address;
                    estateToEdit.PhoneNo = estate.PhoneNo;
                    estateToEdit.LogoUrl = estate.LogoUrl;
                    estateToEdit.EstateName = estate.EstateName;

                    var estateAdded = await _estateRepository.Update(estate.EstateId, estateToEdit);
                    if (estateAdded != null)
                    {
                        return Json(estateAdded);
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
         


        [HttpPost]
        public async Task<IActionResult> DeleteEstate(int id)
        {
            try
            {
                var estatetoDelete = await _estateRepository.GetByIdAsync(id);
                var deleteCount = await _estateRepository.DeleteAsync(estatetoDelete);
                if (deleteCount > 0)
                {
                    return RedirectToAction("Estate");
                }
                else
                {
                    return RedirectToAction("Estate", new { s = "?" });
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }


        [AllowAnonymous]
        public async Task<JsonResult> ExistingEmail(string Id)
        {
            var isExistemail = await  _estateRepository.IsExistEmail(Id);
            if (isExistemail)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
          
        }

        [AllowAnonymous]
        public async Task<JsonResult> ExistingNumber(string Id)
        {
            var isExistnumber = await _estateRepository.IsExistPhoneNumber(Id);
            if (isExistnumber)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }

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


        [HttpPost]
        public async Task<JsonResult> CreateBillingCategory([FromBody]BillingCategory billingCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var estate = await _estateRepository.GetByIdAsync(billingCategory.EstateId);

                    var cat = new BillingCategory
                    {
                        EstateId = estate.EstateId,
                        BillingCategoryName = billingCategory.BillingCategoryName,
                        BillingAmount = billingCategory.BillingAmount
                        
                    };
                    var categoryAdded = await _billingRepository.InsertAsync(cat);
                    if (categoryAdded != null)
                    {
                        return Json(categoryAdded);
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

        [AllowAnonymous]
        public async Task<JsonResult> getLgabyStatesId(string Id)
        {
            List<LocalGovernment> list = new List<LocalGovernment>();
            var lgaUnderAState = await _estateRepository.GetLgaByStatesName(Id);
            list = lgaUnderAState.ToList();
            list.Insert(0, new LocalGovernment { LocalGovernmentId = 0, LocalGovernmentName = "Please Select " });
            return Json(new SelectList(list, "LocalGovernmentName", "LocalGovernmentName"));


        }
    }
}
