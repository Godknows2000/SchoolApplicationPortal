using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SAP.Web.Pages;
using SAP.Data;
using SAP.Models;
using SAP.Data.Data;

namespace SAP.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    [IgnoreAntiforgeryToken(Order = 2000)]
    public class LogoutModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly ApplicationDbContext _context;

        public LogoutModel(SignInManager<User> signInManager, ILogger<LogoutModel> logger, ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            await LogoutUser();
            return LocalRedirect("/");
        }

        public async Task<IActionResult> OnPost()
        {
            await LogoutUser();
            return LocalRedirect("/");
        }

        async Task LogoutUser()
        {
            try
            {
                //var curUserSession = Db.UserSession.Where(c => c.UserId == CurrentUser.Id).OrderByDescending(c => c.LoginDate).FirstOrDefault();
                //if (curUserSession != null)
                //{
                //    curUserSession.LogoutDate = DateTime.Now;
                //    await Db.SaveChangesAsync().ConfigureAwait(false);
                //}
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while logging out of user session");
            }
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
        }
    }
}