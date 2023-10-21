using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.ViewModel;
using System.Text.RegularExpressions;

namespace ProductCatalog.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(IMapper mapper,UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register(string ReturnUrl = "/account/Login")
        {
            ViewData["page"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterAcountVm registerAccountVM, string ReturnUrl = "/account/Login")
        {
            if (ModelState.IsValid)
            {
                //Mapping 
                IdentityUser applicationIdentity =
                    mapper.Map<IdentityUser>(registerAccountVM);
                IdentityResult result =
                    await userManager.CreateAsync(applicationIdentity, registerAccountVM.PasswordHash);
                if (result.Succeeded)
                {

                    //cookie -token ...
                    await signInManager.SignInAsync(applicationIdentity, false);
                    return LocalRedirect(ReturnUrl);
                }
                foreach (var item in result.Errors)
                    ModelState.AddModelError("", item.Description);
            }
            return View(registerAccountVM);
        }
        public IActionResult Login(string ReturnUrl = "/productuser/index")
        {
           
            ViewData["page"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM accountVM, string ReturnUrl = "/productuser/index")
        {
            if (ModelState.IsValid)
            {
                IdentityUser applicationIdentity =
                    await userManager.FindByEmailAsync(accountVM.Email);
                if (applicationIdentity != null)
                {
                    var result =
                        await signInManager.PasswordSignInAsync(applicationIdentity, accountVM.PasswordHash, accountVM.Remmberme, false);
                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(applicationIdentity, accountVM.Remmberme);
                        return LocalRedirect(ReturnUrl);

                    }
                    ModelState.AddModelError("", "Email or password is invalid");
                }
                else
                {
                    ModelState.AddModelError("", "Email or password is invalid");
                }
            }
            return View();
        }
        public IActionResult SignOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        // For Validation
        public async Task<bool> CheckEmial(string Email)
        {
            IdentityUser applicationIdentity =
                await userManager.FindByEmailAsync(Email);
            if (applicationIdentity == null)
                return false;
            return true;
        }
        public bool CheckPassword(string PasswordHash)
        {
            Regex pattern = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$%^&+=!]).+$");
            return pattern.IsMatch(PasswordHash);
        }

    }
}
