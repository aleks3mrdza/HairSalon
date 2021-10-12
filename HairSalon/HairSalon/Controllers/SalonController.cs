using System;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace HairSalon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalonController : ControllerBase
    {
        private readonly ILogger<SalonController> _logger;

        public SalonController(ILogger<SalonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetSalon()
        {

            var salons = new List<Salon>();

            var salon = new Salon();
            salon.Name = "MuhiStil";
            salon.Address = "Kosancic Ivana 50";
            salon.Place = "Vrsac";

            return Ok(salon);

        }
    }
}