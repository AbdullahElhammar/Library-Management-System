

using LibraryManagementSystem.DAL;

namespace LibraryManagementSystem.BL;

public class PatronWithDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public ICollection<BookDto> Books { get; set; } = new HashSet<BookDto>();
}
