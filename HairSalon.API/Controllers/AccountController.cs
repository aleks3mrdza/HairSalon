using HairSalon.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        [HttpPost]
        [Route("login")]
        public bool Login([FromBody]User loginuser)
        {
            return true;
        }

        [HttpPost]
        [Route("logout")]
        public bool Logout([FromBody]User user)
        {
            return true;
        }
    }
}