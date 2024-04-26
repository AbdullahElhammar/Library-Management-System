
using System.ComponentModel.DataAnnotations.Schema;


namespace LibraryManagementSystem.DAL;

public class BorrowingRecord
{
    public int Id { get; set; }
    [ForeignKey("Book")]
    public int BookId { get; set; }
    [ForeignKey("Patron")]
    public int PatronId { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime? ReturnDate { get; set; } // Nullable for books that are not yet returned
    public Book? Book { get; set; }
    public Patron? Patron { get; set; }
}
