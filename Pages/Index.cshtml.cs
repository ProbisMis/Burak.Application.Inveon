using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Burak.Application.Inveon.Models.Request;
using Burak.Application.Inveon.Business.Services;
using Burak.Application.Inveon.Utilities.Helper;
using Burak.Application.Inveon.Models.CustomExceptions;
using Burak.Application.Inveon.Controllers;

namespace Burak.Application.Inveon.Pages
{
    /// <summary>  
    /// Index page model class.  
    /// </summary>  
    public class IndexModel : PageModel
    {
        private readonly IUserApiController _userApiController;

        /// <summary>  
        /// Initializes a new instance of the <see cref="IndexModel"/> class.  
        /// </summary>  
        /// <param name="databaseManagerContext">Database manager context parameter</param>  
        public IndexModel(IUserApiController userApiController)
        {
            _userApiController = userApiController;
        }

        ///// <summary>  
        ///// Gets or sets login model property.  
        ///// </summary>  
        [BindProperty]
        public LoginRequest LoginModel { get; set; }


        /// <summary>  
        /// GET: /Index  
        /// </summary>  
        /// <returns>Returns - Appropriate page </returns>  
        public IActionResult OnGet()
        {
            try
            {
                if (this.User.Identity.IsAuthenticated)
                    return this.RedirectToPage("/Home/Index");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return this.Page();
        }

        /// <summary>  
        /// POST: /Index/LogIn  
        /// </summary>  
        /// <returns>Returns - Appropriate page </returns>  
        public async Task<IActionResult> OnPostLogIn()
        {


            var user = _userApiController.Authenticate(LoginModel);
            if (ControlHelper.isEmpty(user))
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return this.Page();
            }

            if (user.Result.Role.Equals("admin"))
                return this.RedirectToPage("/Admin/Products/Index");

            return this.RedirectToPage("/Products/Index");
        }
    }
}
