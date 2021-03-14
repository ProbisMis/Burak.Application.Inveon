using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Burak.Application.Inveon.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("health-check")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            return StatusCode((int)HttpStatusCode.OK, Environment.MachineName);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("")]
        public RedirectResult Home()
        {
            return Redirect($"{Request.Scheme}://{Request.Host.ToUriComponent()}/swagger");
        }

    }
}