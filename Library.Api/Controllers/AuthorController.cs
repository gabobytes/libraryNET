using AutoMapper;
using Library.Api.Responses;
using Library.Core.DTOs;
using Library.Core.Entities;
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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorService.GetAuthors();
            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);
            var response = new ApiResponse<IEnumerable<AuthorDto>>(authorsDto);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var author = await _authorService.GetAuthor(id);
            var authorDto = _mapper.Map<AuthorDto>(author);
            var response = new ApiResponse<AuthorDto>(authorDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AuthorDto authorDto)
        {
            var author = _mapper.Map<Authors>(authorDto);

            await _authorService.InsertAuthor(author);

            authorDto = _mapper.Map<AuthorDto>(author);
            var response = new ApiResponse<AuthorDto>(authorDto);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AuthorDto authorDto)
        {
            var author = _mapper.Map<Authors>(authorDto);
            author.Id = id;

            var result = await _authorService.UpdateAuthor(author);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _authorService.DeleteAuthor(id);
            var response = new ApiResponse<bool>(result);
            
            return Ok(response);
        }

    }
}
