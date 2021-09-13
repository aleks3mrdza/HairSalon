using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HairSalon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DefaultController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;

        public DefaultController(ILogger<DefaultController> logger)
        {
            _logger = logger;
        }
    }
}
