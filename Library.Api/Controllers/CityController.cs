using AutoMapper;
using Library.Api.Responses;
using Library.Core.DTOs;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CityController : ControllerBase
    {
        private readonly ICityService _postService;
        private readonly IMapper _mapper;

        public CityController(ICityService cityService , IMapper mapper)
        {
            _postService = cityService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            var cities =  _postService.GetCities();
            var citiesDto = _mapper.Map<IEnumerable<CityDto>>(cities);
            var response = new ApiResponse<IEnumerable<CityDto>>(citiesDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
       public async Task<IActionResult> GetCity(int id)
        {
            var city = await _postService.GetCity(id);
            var cityDto = _mapper.Map<CityDto>(city);
            var response = new ApiResponse<CityDto>(cityDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CityDto cityDto)
        {
            var city = _mapper.Map<Cities>(cityDto);

            await _postService.InsertCity(city);
            
            cityDto = _mapper.Map<CityDto> (city );            
            var response = new ApiResponse<CityDto>(cityDto);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CityDto cityDto)
        {
            var city = _mapper.Map<Cities>(cityDto);
            city.Id = id;

            var result = await _postService.UpdateCity(city);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {            
            var result = await _postService.DeleteCity(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
