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
        private readonly IEditorialRepository _editorialrepository;

        public EditorialController(IEditorialRepository editorialrepository)
        {
            _editorialrepository = editorialrepository;
        }

        public async Task<IActionResult> GetEditorials()
        {
            var editorials = await _editorialrepository.GetEditorials();
            return Ok(editorials);
        }
    }
}
