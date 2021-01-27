using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Something.Security;
using System;

namespace Something.API.Controllers
{
    [Authorize]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ISomethingUserManager userManager;
        private readonly ILogger<HomeController> logger;

        public HomeController(ISomethingUserManager userManager, ILogger<HomeController> logger)
        {
            this.userManager = userManager;
            this.logger = logger;
        }

        [AllowAnonymous]
        [Route("home/authenticate")]
        public ActionResult Authenticate()
        {
            try
            {
                var token = userManager.GetUserToken();
                return Ok(new { access_token = token });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }            
        }
    }
}
