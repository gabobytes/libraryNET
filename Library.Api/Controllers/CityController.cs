using AutoMapper;
using Library.Core.DTOs;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityrepository;
        private readonly IMapper _mapper;

        public CityController(ICityRepository cityrepository , IMapper mapper)
        {
            _cityrepository = cityrepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _cityrepository.GetCities();
            var citiesDto = _mapper.Map<IEnumerable<CityDto>>(cities);
            return Ok(citiesDto);
        }

        [HttpGet("{id}")]
       public async Task<IActionResult> GetCity(int id)
        {
            var city = await _cityrepository.GetCity(id);
            var cityDto = _mapper.Map<CityDto>(city);

            return Ok(cityDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CityDto cityDto)
        {
            var city = _mapper.Map<Cities>(cityDto);

            await _cityrepository.InsertCity(city);
            return Ok(city);

        }
    }
}
