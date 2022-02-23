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
        private readonly IAuthorRepository _authorrepository;

        public AuthorController(IAuthorRepository authorrepository)
        {
            _authorrepository = authorrepository;
        }

        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorrepository.GetAuthors();
            return Ok(authors);
        }
    }
}
