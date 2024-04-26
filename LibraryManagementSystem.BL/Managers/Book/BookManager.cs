using LibraryManagementSystem.DAL;


namespace LibraryManagementSystem.BL;

public class BookManager:IBookManager
{
    private readonly IBookRepo repo;
    public BookManager(IBookRepo repo) {  this.repo = repo; }

    public int Add(BookDto BookToAdd)
    {
        Book book= new Book
        {
            Id=BookToAdd.Id,
            Title=BookToAdd.Title,
            Author= BookToAdd.Author,
            PublicationYear= BookToAdd.PublicationYear,
            BookISBN=BookToAdd.BookISBN
        };
        repo.Add(book);
        repo.SaveChanges();
        return book.Id;
    }

    public bool Delete(int id)
    {
        var BookToDelete = repo.GetById(id);
        if (BookToDelete == null)
        {
            return false;
        }
        repo.Delete(BookToDelete);
        repo.SaveChanges();
        return true;
    }

    public IEnumerable<BookDto> GetAll()
    {
        IEnumerable<Book> books = repo.GetAll();
        return books.Select(book => new BookDto
        {
            Id=book.Id,
            Title=book.Title,
            Author=book.Author,
            PublicationYear=book.PublicationYear,
            BookISBN=book.BookISBN
        });
    }

    public BookWithDetailsDto? GetBookWithDetails(int id)
    {
        Book? book= repo.GetBookWithDetails(id);
        if (book == null)
        {
            return null;
        }
        return new BookWithDetailsDto
        {
            Id= book.Id,
            Title=book.Title,
            Author=book.Author,
            PublicationYear=book.PublicationYear,
            BookISBN=book.BookISBN,
            Patrons=book.Patrons.Select(b=> new PatronDto
            {
                Id= b.Id,
                Name=b.Name,
                Address=b.Address
            }).ToList()
        };
    }

    public BookDto? GetById(int id)
    {
        var book= repo.GetById(id);
        if (book == null) { return null; }
        return new BookDto
        {
            Id= book.Id,
            Title=book.Title,
            Author=book.Author,
            PublicationYear=book.PublicationYear,
            BookISBN=book.BookISBN
        };
    }

    public bool Update(BookDto book)
    {
        var BookToUpdate= repo.GetById(book.Id);
        if (BookToUpdate == null) { return false; }
        BookToUpdate.Title=book.Title;
        BookToUpdate.Author=book.Author;
        BookToUpdate.PublicationYear=book.PublicationYear;
        BookToUpdate.BookISBN=book.BookISBN;
        repo.Update(BookToUpdate);
        repo.SaveChanges();
        return true;
    }
}
