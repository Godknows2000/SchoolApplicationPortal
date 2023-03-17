using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SAP.Models;
using SAP.Data;
using SAP.Web.Areas.Identity.Pages.Account;
using SAP.Data.Data;

namespace SAP.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ActivateModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly ApplicationDbContext _context;

        public ActivateModel( UserManager<User> userManager, ILogger<LoginModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }
        public bool IsActivated { get; private set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string code)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
            var Uid = new Guid(Convert.FromBase64String(code));
            var user = await _context.Users.FindAsync(Uid);
            IsActivated = user.ActivationDate.HasValue;
            Input = new InputModel { Email = user.Email };

        }

        #region snippet
        public async Task<IActionResult> OnPostAsync(string code)
        {
            var Uid = new Guid(Convert.FromBase64String(code));
            var user = await _context.Users.FindAsync(Uid);
            if (user.ActivationDate.HasValue)
            {
                //Title = PageTitle = "Activate login account";
                //return Page();
            }
            user.ActivationDate = DateTime.Now;
            user.EmailConfirmed = true;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, Input.Password);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Login", new { code });
        }
        #endregion
    }
}
