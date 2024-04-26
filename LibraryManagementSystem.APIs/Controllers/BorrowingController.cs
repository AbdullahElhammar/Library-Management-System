using LibraryManagementSystem.BL;
using LibraryManagementSystem.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        private readonly IBorrowingRecordManager manager;
        public BorrowingController(IBorrowingRecordManager manager)
        {
            this.manager = manager;
        }
        [HttpPost("api/Borrowing/{id}")]
        public ActionResult Borrow(BorrowingRecordDto BorrowData, int id)
        {
           manager.Borrow(BorrowData, id);
            return Ok(BorrowData + "\n Success Borrow Process");
        }
        [HttpGet("api/Borrowing/{PatronId}")]
        public ActionResult GetBorrowingProcess(int BookId,int PatronId)
        {
            manager.GetBorrowingProcess(BookId, PatronId);
            return NoContent();
        }

    }
}
