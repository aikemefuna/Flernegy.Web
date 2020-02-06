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
    public class AdminController : Controller
    {
        private readonly IEstateAdminRepository _estateAdminRepository;
        private readonly IEstateRepository _estateRepository;

        public AdminController(IEstateAdminRepository estateAdminRepository, IEstateRepository estateRepository)
        {
            _estateAdminRepository = estateAdminRepository;
            _estateRepository = estateRepository;
        }
        public async Task<IActionResult> EstateAdmin(string s, string v)
        {
            try
            {
                ViewBag.States = new SelectList(await _estateRepository.GetAllStatesAsync(), "StateName", "StateName");
                if (v != null)
                {
                    ViewBag.added = "Yes";
                }
                var admList = await _estateAdminRepository.GetAll();
                ViewBag.PageName = "EstateAdmins";
                if (await _estateAdminRepository.Count() > 4)
                {

                    //var firstEstates = estateList.OrderByDescending(c => c.DateCreated).Take(4);
                    var firstFourAdmins = admList.Take(4);
                   
                    ViewBag.fiveCategory = firstFourAdmins;
                    ViewBag.Categories = admList;
                }
              
                ViewBag.EstateAmins = admList;
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
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            try
            {
                var adminDelete = await _estateAdminRepository.GetByIdAsync(id);
                var deleteCount = await _estateAdminRepository.DeleteAsync(adminDelete);
                if (deleteCount > 0)
                {
                    return RedirectToAction(nameof(EstateAdmin));
                }
                else
                {
                    return RedirectToAction("EstateAdmin", new { s = "?" });
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateAdmin(EstateAdmin admin)
        {
            try
            {
                var admintobeAdded = await _estateAdminRepository.InsertAsync(admin);
                if (admintobeAdded != null)
                {
                    return RedirectToAction(nameof(EstateAdmin));
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
        [AllowAnonymous]
        public async Task<JsonResult> GetStates(string id)
        {
            var state = await _estateAdminRepository.GetStateByNameAsync(id);
            List<AdmStates> list = new List<AdmStates>();
            var states = await _estateAdminRepository.GetAllState();
            list = states.ToList();
            list.Insert(0, new AdmStates { StateId = state.StateId, StateName = state.StateName });
            return Json(new SelectList(list, "StateName", "StateName"));
        }
        [AllowAnonymous]
        public async Task<JsonResult> GetLga(string id)
        {
            var lga = await _estateAdminRepository.GetLgaByNameAsync(id);
            List<LocalGovernment> list = new List<LocalGovernment>();
            var lgs = await _estateAdminRepository.GetAllLga();
            list = lgs.ToList();
            list.Insert(0, new LocalGovernment { LocalGovernmentId = lga.LocalGovernmentId, LocalGovernmentName = lga.LocalGovernmentName });
            return Json(new SelectList(list, "LocalGovernmentName", "LocalGovernmentName"));
        }


        public async Task<IActionResult> EditAdmin(int id)
        {
            try
            {
                var admin = await _estateAdminRepository.GetByIdAsync(id);
                if (admin != null)
                {
                    return Json(admin);
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
        public async Task<JsonResult> EditAdmin([FromBody]EstateAdmin estateAdmin)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var admintoEdit = await _estateAdminRepository.GetByIdAsync(estateAdmin.EstateAdminId);
                    admintoEdit.FirstName = estateAdmin.FirstName;
                    admintoEdit.MiddleName = estateAdmin.MiddleName;
                    admintoEdit.LastName = estateAdmin.LastName;
                    admintoEdit.Gender = estateAdmin.Gender;
                    admintoEdit.State = estateAdmin.State;
                    admintoEdit.LGA = estateAdmin.LGA;



                    var adminAdded = await _estateAdminRepository.Update(estateAdmin.EstateAdminId, admintoEdit);
                    if (adminAdded != null)
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
    }
}
