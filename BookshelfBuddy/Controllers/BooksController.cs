using BookshelfBuddy.Data.Entities;
using BookshelfBuddy.Services;
using BookshelfBuddy.Services.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookshelfBuddy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            List<Book> books = _bookService.GetAll();
            return Ok(books);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBook(Guid id)
        {
            var book = _bookService.GetById(id);

            if (book == null)
            {
                return NotFound("Book not found");
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult InsertBook([FromBody] BookDto book)
        {
            if (book == null)
            {
                return BadRequest("Book cannot be null");
            }

            if (!_bookService.Insert(book))
            {
                return BadRequest("Book cannot be created");
            }

            return Ok(book);
        }

        [HttpPut]
        public IActionResult UpdateBook([FromBody] BookDto book)
        {
            if (book == null)
            {
                return BadRequest("Book cannot be null");
            }

            if (!_bookService.Update(book.Id, book))
            {
                return NotFound("Book not found");
            }

            return Ok(book);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult RemoveBook(Guid id)
        {
            if (!_bookService.Remove(id))
            {
                return NotFound("Book not found");
            }

            return Ok("Book deleted");
        }
    }
}
