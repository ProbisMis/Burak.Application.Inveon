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

namespace Burak.Application.Inveon.Pages
{
    /// <summary>  
    /// Index page model class.  
    /// </summary>  
    public class IndexModel : PageModel
    {
        /// <summary>  
        /// Initializes a new instance of the <see cref="IndexModel"/> class.  
        /// </summary>  
        /// <param name="databaseManagerContext">Database manager context parameter</param>  
        public IndexModel( )
        {
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
            catch (Exception ex) {
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
            try
            {

                
                //// Verification.  
                //if (ModelState.IsValid)
                //{
                //    // Initialization.  

                //    // Verification.  
                //    if (loginInfo != null && loginInfo.Count() > 0)
                //    {
                //        // Initialization.  
                //        var logindetails = loginInfo.First();

                //        // Login In.  
                //        await this.SignInUser(logindetails.Username, false);

                //        // Info.  
                //        return this.RedirectToPage("/Home/Index");
                //    }
                //    else
                //    {
                //        // Setting.  
                //        ModelState.AddModelError(string.Empty, "Invalid username or password.");
                //    }
                //}
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Info.  
            return this.Page();
        }


        /// <summary>  
        ///
        /// </summary>  
        /// <param name="username">Username parameter.</param>  
        /// <param name="isPersistent">Is persistent parameter.</param>  
        /// <returns>Returns - await task</returns>  
        private async Task SignInUser(string username, bool isPersistent)
        {
            // Initialization.  
            var claims = new List<Claim>();

            try
            {
                // Setting  
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                var authenticationManager = Request.HttpContext;

                // Sign In.  
                await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties() { IsPersistent = isPersistent });
            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }
        }
    }
}
