

using LibraryManagementSystem.DAL;

namespace LibraryManagementSystem.BL;

public class BookWithDetailsDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public int BookISBN { get; set; }
    public ICollection<PatronDto> Patrons { get; set; } = new HashSet<PatronDto>();
}
