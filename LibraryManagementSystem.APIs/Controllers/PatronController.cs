using LibraryManagementSystem.BL;
using LibraryManagementSystem.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatronController : ControllerBase
    {
        private readonly IPatronManager manager;    
        public PatronController(IPatronManager manager)
        {
            this.manager = manager;
        }
        [HttpGet]
        public ActionResult<List<PatronDto>> GetAll()
        {
            return manager.GetAll().ToList();
        }
        [HttpGet("api/patron/{id}")]
        public ActionResult<PatronDto> GetById(int id)
        {
            PatronDto? patron= manager.GetById(id);
            if (patron is null)
            {
                return NotFound();
            }
            return Ok(patron);
        }
        [HttpGet("api/patron/{id}/details")]
        public ActionResult<PatronWithDetailsDto> GetPatronWithDetails(int id)
        {
            var patron= manager.GetPatronWithDetails(id);
            if (patron is null)
            {
                return NotFound();
            }
            return patron;
        }
        [HttpPost]
        public ActionResult Add(PatronDto patron) 
        {
            manager.Add(patron);
            return Ok("patron added successfully");
        }

        [HttpPut]
        public ActionResult Update(PatronDto patron)
        {
            var IsFound= manager.Update(patron);
            if (!IsFound)
            {
                return NotFound();
            }
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        public ActionResult Delete(int id) 
        {
            var IsFound= manager.Delete(id);
            if (!IsFound) { return NotFound(); }
            return Ok("Deleted Successfully");
        }
    }
}
