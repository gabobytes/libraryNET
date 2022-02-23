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
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genrerepository;

        public GenreController(IGenreRepository genrerepository)
        {
            _genrerepository = genrerepository;
        }

        public async Task<IActionResult> GetGenres()
        {
            var genres = await _genrerepository.GetGenres();
            return Ok(genres);
        }

    }
}
