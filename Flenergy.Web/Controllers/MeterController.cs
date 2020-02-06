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
    public class MeterController : Controller 
    {
        private readonly IMeterRepository _meterRepository;
        private readonly IEstateRepository _estateRepository;

        public MeterController(IMeterRepository meterRepository, IEstateRepository estateRepository)
        {
           _meterRepository = meterRepository;
           _estateRepository = estateRepository;
        }
        public async Task<IActionResult> GetMeters(string s, string v)
        {
            try
            {
                if (v != null)
                {
                    ViewBag.added = "Yes";
                }
                var meters = await _meterRepository.GetAll();
                ViewBag.PageName = "Meters";
                if (await _meterRepository.Count() > 4)
                {

                   
                    var firstFourAdmins = meters.Take(4);

                    ViewBag.FourMeters = firstFourAdmins;
                    ViewBag.meters = meters;
                }

                ViewBag.Meters = meters;
                ViewBag.Estates = new SelectList(await _estateRepository.GetAll(), "EstateId", "EstateName");
                return View();
            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }


        public async Task<IActionResult> EditMeter(int id)
        {
            try
            {
                var meter = await _meterRepository.GetByIdAsync(id);
                if (meter != null)
                {
                    return Json(meter);
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
        public async Task<JsonResult> EditMeter([FromBody]Adm_Meter adm_Meter)
        {
            try
            {
                var meter = await _meterRepository.GetByIdAsync(adm_Meter.Adm_MeterId);
                if (meter != null)
                {
                    meter.Meterno = adm_Meter.Meterno;
                    meter.MeterType = adm_Meter.MeterType;
                    meter.EstateId = adm_Meter.EstateId;

                   var meterToUpdate = await _meterRepository.Update(meter.Adm_MeterId,meter);
                    if (meterToUpdate != null)
                    {
                        return Json(true);
                    }
                    else
                    {
                        return Json(false);
                    }
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
        public async Task<IActionResult> DeleteMeter(int id)
        {
            try
            {
                var meterToDelete = await _meterRepository.GetByIdAsync(id);
                var deleteCount = await _meterRepository.DeleteAsync(meterToDelete);
                if (deleteCount > 0)
                {
                    return RedirectToAction(nameof(GetMeters));
                }
                else
                {
                    return RedirectToAction("GetMeters", new { s = "?" });
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

        [HttpPost]
        public async Task<IActionResult> Create(Adm_Meter meter)
        {
            try
            {
                var metTobeAdded = await _meterRepository.InsertAsync(meter);
                if (metTobeAdded != null)
                {
                    return RedirectToAction(nameof(GetMeters));
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
        public async Task<JsonResult> getCustomerForAnEstate(int Id)
        {
            List<Customer> list = new List<Customer>();
            var customer = await _estateRepository.GetCustomerOfAnEstate(Id);
            list = customer.ToList();
            list.Insert(0, new Customer { CustomerId = 0, AccountNo = "Please Select" });
            return Json(new SelectList(list, "CustomerId", "AccountNo"));
        }
    }
}
