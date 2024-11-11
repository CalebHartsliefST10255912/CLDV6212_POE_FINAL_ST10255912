using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ABC_Retail_ST10255912_POE.Data;

namespace ABC_Retail_ST10255912_POE.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginModel(
            ApplicationDbContext context,
            ILogger<LoginModel> logger,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public string ReturnUrl { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            if (User.Identity.IsAuthenticated)
            {
                LocalRedirect(ReturnUrl);
            }
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                // Check the Customers table
                var customer = await _context.Customers
                    .SingleOrDefaultAsync(c => c.Email == Input.Email);

                if (customer != null && customer.Password == Input.Password)
                {
                    // Customer authentication
                    var customerClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, customer.Email),
                        new Claim("CustomerID", customer.CustomerID.ToString())
                    };

                    var customerIdentity = new ClaimsIdentity(customerClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var customerPrincipal = new ClaimsPrincipal(customerIdentity);

                    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, customerPrincipal);
                    _logger.LogInformation("Customer logged in.");
                    return LocalRedirect(returnUrl);
                }

                // Check the AspNetUsers table for an admin or Identity user
                var identityUser = await _userManager.FindByEmailAsync(Input.Email);
                if (identityUser != null)
                {
                    var identityResult = await _signInManager.PasswordSignInAsync(identityUser, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                    if (identityResult.Succeeded)
                    {
                        _logger.LogInformation("Admin/Identity user logged in.");
                        return LocalRedirect(returnUrl);
                    }
                }

                // If neither customer nor identity user is found or authentication fails
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
