using HairSalon.Constant;
using HairSalon.Database;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetHairdressers()
        {
            var hairdresseres = new List<Hairdresser>();

            var connection = Connection.Instance.DbConnection;

            using (var command = new MySqlCommand($"Select * from {Constants.DatabaseName}.Hairdressers;", connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                    while (await reader.ReadAsync())
                    {
                        var hairdresser = new Hairdresser();

                        hairdresser.FirstName = reader.GetString(0);
                        hairdresser.LastName = reader.GetString(1);
                        hairdresser.NickName = reader.GetString(2);
                        hairdresser.MobilePhone = reader.GetString(3);
                        hairdresser.LandlinePhone = reader.GetString(4);
                        hairdresser.Address = reader.GetString(5);
                        hairdresser.Id = reader.GetInt32(6);

                        hairdresseres.Add(hairdresser);
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
        public async Task<IActionResult> PostHairdresser(Hairdresser hairdresser)
        {
            var connection = Connection.Instance.DbConnection;

            using (var command = new MySqlCommand($"Insert into {Constants.DatabaseName}Hairdressers(" +
                "FirstName," +
                "LastName," +
                "NickName," +
                "MobilePhone," +
                "LandlinePhone," +
                "Address" +
                ") values (" +
                $"{hairdresser.FirstName}," +
                $" {hairdresser.LastName}," +
                $" {hairdresser.NickName}," +
                $" {hairdresser.MobilePhone}," +
                $" {hairdresser.LandlinePhone}, " +
                $"{hairdresser.Address})" +
                ";"
                , connection))
            {
                var reader = await command.ExecuteReaderAsync();
            }

            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateHairdresser(Hairdresser hairdresser)
        {
            return Ok(new List<Hairdresser>() { });
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteHairdresser(Hairdresser hairdresser)
        {
            return Ok(new List<Hairdresser>() { });
        }
    }
}
