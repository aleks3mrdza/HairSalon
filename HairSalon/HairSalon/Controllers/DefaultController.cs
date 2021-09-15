using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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

        [HttpGet]
        public IActionResult GetHairdressers()
        {
            var hairdresseres = new List<Hairdresser>();

            var hairdresser1 = new Hairdresser();
            hairdresser1.FirstName = "Ilija";
            hairdresser1.LastName = "Sekulic";
            hairdresser1.MobilePhone = "064 555 777";
            hairdresser1.LandlinePhone = "013 456 789";
            hairdresser1.Address = "Ivana Kosancica 50";

            var hairdresser2 = new Hairdresser();
            hairdresser2.FirstName = "Marko";
            hairdresser2.LastName = "Nikolic";
            hairdresser2.MobilePhone = "064 555 777";
            hairdresser2.LandlinePhone = "013 456 789";
            hairdresser2.Address = "Ivana Kosancica 54";

            var hairdresser3 = new Hairdresser();
            hairdresser3.FirstName = "Janko";
            hairdresser3.LastName = "Peric";
            hairdresser3.MobilePhone = "064 555 777";
            hairdresser3.LandlinePhone = "013 456 789";
            hairdresser3.Address = "Save Knezevica 74";

            hairdresseres.Add(hairdresser1);
            hairdresseres.Add(hairdresser2);
            hairdresseres.Add(hairdresser3);

            return Ok(hairdresseres);
        }
    }
}
