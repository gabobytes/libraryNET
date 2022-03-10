using AutoMapper;
using Library.Api.Responses;
using Library.Core.DTOs;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService,IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public  IActionResult GetBooks()
        {
            var books = _bookService.GetBooks();
            var booksDto = _mapper.Map<IEnumerable<BookDto>> (books);
            var response = new ApiResponse<IEnumerable<BookDto>>(booksDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BookDto bookDto)
        {
            var book = _mapper.Map<Books>(bookDto);

            await _bookService.InsertBook(book);

            bookDto = _mapper.Map<BookDto>(book);
            var response = new ApiResponse<BookDto>(bookDto);

            return Ok(response);
        }
    }
}
