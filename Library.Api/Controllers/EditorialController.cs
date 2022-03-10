using AutoMapper;
using Library.Api.Responses;
using Library.Core.DTOs;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EditorialController : ControllerBase
    {
        private readonly IEditorialService _editorialService;
        private readonly IMapper _mapper;

        public EditorialController(IEditorialService editorialservice, IMapper mapper)
        {
            _editorialService = editorialservice;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetEditorials()
        {
            var editorials = _editorialService.GetEditorials();
            var editorialsDto = _mapper.Map<IEnumerable <EditorialDto>> (editorials);
            var response = new ApiResponse<IEnumerable<EditorialDto>>(editorialsDto);

            return Ok(response);


        }
    }
}
