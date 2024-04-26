
using LibraryManagementSystem.DAL;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.BL;

public class BorrowingRecordDto
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; } // Nullable for books that are not yet returned

}
