using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairSalon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DefaultController : ControllerBase
    {
        private List<Hairdresser> hairdresseres = new List<Hairdresser>();

        private readonly ILogger<DefaultController> _logger;

        public DefaultController(ILogger<DefaultController> logger)
        {
            _logger = logger;

            var hairdresser1 = new Hairdresser();
            hairdresser1.FirstName = "Ilija";
            hairdresser1.LastName = "Sekulic";
            hairdresser1.NickName = "Ike";
            hairdresser1.MobilePhone = "064 555 777";
            hairdresser1.LandlinePhone = "013 456 789";
            hairdresser1.Address = "Ivana Kosancica 50";

            var hairdresser2 = new Hairdresser();
            hairdresser2.FirstName = "Marko";
            hairdresser2.LastName = "Nikolic";
            hairdresser1.NickName = "Ike";
            hairdresser2.MobilePhone = "064 555 777";
            hairdresser2.LandlinePhone = "013 456 789";
            hairdresser2.Address = "Ivana Kosancica 54";

            var hairdresser3 = new Hairdresser();
            hairdresser3.FirstName = "Janko";
            hairdresser3.LastName = "Peric";
            hairdresser3.NickName = "Perke";
            hairdresser3.MobilePhone = "064 555 777";
            hairdresser3.LandlinePhone = "013 456 789";
            hairdresser3.Address = "Save Knezevica 74";

            hairdresseres.Add(hairdresser1);
            hairdresseres.Add(hairdresser2);
            hairdresseres.Add(hairdresser3);
        }

        [HttpGet]
        public async Task<IActionResult> GetHairdressers()
        {
            using (var connection = new MySqlConnection("Server=localhost;Port=3306;User ID=root;Password=11111"))
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT * FROM world.city;", connection))
                using (var reader = await command.ExecuteReaderAsync())
                    while (await reader.ReadAsync())
                    {
                        var value = reader.GetValue(0);
                    }
            }

            return Ok(hairdresseres);
        }

        [HttpGet]
        [Route("wait")]

        public async Task<IActionResult> Wait()
        {
            await Task.Delay(7000);

            return Ok();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult PostHairdresser(Hairdresser hairdresser)
        {
            hairdresseres.Add(hairdresser);

            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateHairdresser(Hairdresser hairdresser)
        {
            var hairdresserToupdate = hairdresseres.FirstOrDefault(h => h.FirstName == hairdresser.FirstName);

            hairdresserToupdate.FirstName = hairdresser.FirstName;
            hairdresserToupdate.LastName = hairdresser.LastName;
            hairdresserToupdate.NickName = hairdresser.NickName;
            hairdresserToupdate.MobilePhone = hairdresser.MobilePhone;
            hairdresserToupdate.LandlinePhone = hairdresser.LandlinePhone;
            hairdresserToupdate.Address = hairdresser.Address;

            return Ok(new List<Hairdresser>() { hairdresserToupdate });
        }
        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteHairdresser(Hairdresser hairdresser)
        {
            var hairdresserToDelete = hairdresseres.FirstOrDefault(h => h.FirstName == hairdresser.FirstName);
            hairdresseres.Remove(hairdresserToDelete);


            return Ok(new List<Hairdresser>() { hairdresserToDelete });
        }
    }
}
