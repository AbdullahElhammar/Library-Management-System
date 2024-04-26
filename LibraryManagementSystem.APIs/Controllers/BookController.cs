using LibraryManagementSystem.BL;
using LibraryManagementSystem.DAL;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookManager manager;
        public BookController(IBookManager manager)
        {
            this.manager = manager;
        }
        [HttpGet]
        public ActionResult<List<BookDto>> GetAll()
        {
            return manager.GetAll().ToList();
        }

        [HttpGet("api/Book/{id}")]
        public ActionResult<BookDto> GetById(int id)
        { 
            BookDto? book = manager.GetById(id);
            if (book is null)
            {
                return NotFound();
            }
            return book;
        }
        [HttpGet("api/Book/{id}/details")]
        public ActionResult<BookWithDetailsDto> GetBookWithDetails(int id)
        {
            BookWithDetailsDto? BookWithDetails = manager.GetBookWithDetails(id);
            if (BookWithDetails is null)
            {
                return NotFound();
            }
            return BookWithDetails;
        }
        [HttpPost]
        public ActionResult Add(BookDto book)
        {
            manager.Add(book);
            return Ok("Book Added Successfully");
        }
        [HttpPut]
        public ActionResult Update(BookDto book)
        {
            var IsFound = manager.Update(book);
            if (!IsFound)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var IsFound = manager.Delete(id);
            if (!IsFound) { return NotFound(); }
            return Ok("Book Deleted Successfully");
        }



    }
}
