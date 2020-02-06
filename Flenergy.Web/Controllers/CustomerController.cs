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
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEstateRepository _estateRepository;
        private readonly IMeterRepository _meterRepository;
        private readonly IBillingRepository _billingRepository;
        private readonly IEstateAdminRepository _estateAdminRepository;

        public CustomerController(ICustomerRepository customerRepository, IEstateRepository estateRepository, IMeterRepository meterRepository, IBillingRepository billingRepository, IEstateAdminRepository estateAdminRepository)
        {
            _customerRepository = customerRepository;
            _estateRepository = estateRepository;
           _meterRepository = meterRepository;
            _billingRepository = billingRepository;
            _estateAdminRepository = estateAdminRepository;
        }
        public async Task<IActionResult> Customers(string s, string v)
        {
            try
            {
                ViewBag.States = new SelectList(await _estateRepository.GetAllStatesAsync(), "StateName", "StateName");

                if (v != null)
                {
                    ViewBag.added = "Yes";
                }
                var customers = await _customerRepository.GetAll();
                ViewBag.PageName = "Customers";
                if (await _customerRepository.Count() > 4)
                {

                  
                    var firstFourCustomers = customers.Take(4);

                    ViewBag.firstFourCustomers = firstFourCustomers;
                    ViewBag.customers = customers;
                }
                foreach (var cus in customers)
                {
                    var meterCount = await _customerRepository.GetCountOfMetersByCustomer(cus.CustomerId);
                }
                ViewBag.customers = customers;
                ViewBag.Estates = new SelectList(await _estateRepository.GetAll(), "EstateId", "EstateName");
                
                return View();
            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }


        public async Task<IActionResult> EditCUstomer(int id)
        {
            try
            {
                var cus = await _customerRepository.GetByIdAsync(id);
                if (cus != null)
                {
                    return Json(cus);
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
        public async Task<JsonResult> EditMeter([FromBody]Customer customer)
        {
            try
            {
                var cus = await _customerRepository.GetByIdAsync(customer.CustomerId);
                if (cus != null)
                {
                   

                    var cusToUpdate = await _customerRepository.Update(cus.CustomerId, cus);
                    if (cusToUpdate != null)
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
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var cusToDelete = await _customerRepository.GetByIdAsync(id);
                var deleteCount = await _customerRepository.DeleteAsync(cusToDelete);
                if (deleteCount > 0)
                {
                    return RedirectToAction(nameof(Customers));
                }
                else
                {
                    return RedirectToAction("Customers", new { s = "?" });
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
        public async Task<IActionResult> Create(Customer customer)
        {
            try
            {
                var cusAdded = await _customerRepository.InsertAsync(customer);
                var cus = await _customerRepository.GetByIdAsync(cusAdded.CustomerId);
                var account = cus.EstateId.ToString() + cus.CustomerId.ToString();
                cus.AccountNo = account;
                var custTobeUpdated = await _customerRepository.Update(cus.CustomerId, cus);
                if (cusAdded != null)
                {
                    return RedirectToAction(nameof(Customers));
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
        public async Task<JsonResult> getCategoriesForAnEstate(int Id)
        {
            List<BillingCategory> list = new List<BillingCategory>();
            var categoriesByEsateId = await _billingRepository.GetCategoriesbyEstateId(Id);
            list = categoriesByEsateId.ToList();
            list.Insert(0, new BillingCategory { BillingCategoryId = 0, BillingCategoryName = "Please Select" });
            return Json(new SelectList(list, "BillingCategoryId", "BillingCategoryName"));
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


        [AllowAnonymous]
        public async Task<JsonResult> GetLgaByState(string id)
        {
            var lga = await _estateRepository.GetLgaByStatesName(id);
            List<LocalGovernment> list = new List<LocalGovernment>();
           
            list = lga.ToList();
            list.Insert(0, new LocalGovernment { LocalGovernmentId = 0, LocalGovernmentName = "Please Select" });
            return Json(new SelectList(list, "LocalGovernmentName", "LocalGovernmentName"));
        }
    }
}
