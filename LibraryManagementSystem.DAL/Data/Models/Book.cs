using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }= string .Empty;
    public string Author { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public int BookISBN { get; set; }
    public ICollection<Patron> Patrons { get; set; } = new HashSet<Patron>();   
}
