using Flenergy.Data.Models;
using Flenergy.Data.Repository.Interface;
using Flenergy.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flenergy.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;



        private readonly IEstateRepository _estateRepository;

        public AuthController(IEstateRepository estateRepository, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _estateRepository = estateRepository;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Signin()
        {
            var estates = await _estateRepository.GetAll();
            ViewBag.InstitutionList = new SelectList(estates.ToList(), "EstateId", "EstateName");

            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Signin(SigninViewModel signinViewModel, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var user = await _userManager.FindByEmailAsync(signinViewModel.Email);
                    //var userEmail = await _userManager.FindByEmailAsync(viewModel.Username);
                    if (user == null)
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                        return View(signinViewModel);
                    }
                    var result = await _signInManager.PasswordSignInAsync(user, signinViewModel.Password, signinViewModel.RememberMe, false);
                    if (result.Succeeded)
                    {
                        HttpContext.Session.SetString("currentUser", signinViewModel.Email);
                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {

                            return Redirect(returnUrl);
                        }
                        else
                        {
                            if (await _userManager.IsInRoleAsync(user, "GlobalAdmin"))
                            {
                                return RedirectToAction("Global", "Dashboard");
                            }
                            else if (await _userManager.IsInRoleAsync(user, "EstateAdmin"))
                            {
                                return RedirectToAction("Admin", "Dashboard");
                            }
                            else if (await _userManager.IsInRoleAsync(user, "Customer"))
                            {
                                return RedirectToAction("Customer", "Dashboard");
                            }

                        }
                    }
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

                }
                return View(signinViewModel);
            }
            catch (Exception)
            {

                throw;
            }
        
        }

    }

}
   