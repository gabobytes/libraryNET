using Library.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityrepository;

        public CityController(ICityRepository cityrepository)
        {
            _cityrepository = cityrepository;
        }

        public async Task<IActionResult> GetCities()
        {
            var cities = await _cityrepository.GetCities();
            return Ok(cities);

        }
    }
}
