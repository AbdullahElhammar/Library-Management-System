using LibraryManagementSystem.DAL;

namespace LibraryManagementSystem.BL;

public class PatronManager : IPatronManager
{
    private readonly IPatronRepo repo;
    public PatronManager(IPatronRepo patronRepo)
    {
        this.repo = patronRepo;
    }

    public int Add(PatronDto PatronToAdd)
    {
        Patron patron = new Patron
        {
            Id = PatronToAdd.Id,
            Name = PatronToAdd.Name,
            Address = PatronToAdd.Address,
        };
        repo.Add(patron);
        repo.SaveChanges();
        return PatronToAdd.Id;
    }

    public bool Delete(int id)
    {
        var PatronToDelete= repo.GetById(id);
        if (PatronToDelete is null) { return false; }
        else
        {
            repo.Delete(PatronToDelete);
        }
        repo.SaveChanges();
        return true;
    }

    public IEnumerable<PatronDto> GetAll()
    {
        //it returns IEnumerable<Patron>
        var PatronModel= repo.GetAll();
        return PatronModel.Select(p => new PatronDto
        {
            Id = p.Id,
            Name = p.Name,
            Address = p.Address,    
        });
    }

    public PatronDto? GetById(int id)
    {
        Patron? PatronModel= repo.GetById(id);  
        if (PatronModel == null) { return null; }
        return new PatronDto
        {
            Id=PatronModel.Id,
            Name=PatronModel.Name,
            Address=PatronModel.Address
        };
    }

    public PatronWithDetailsDto? GetPatronWithDetails(int id)
    {
        Patron? patron = repo.GetPatronWithDetails(id);
        if (patron== null)
        {
            return null;
        }
        return new PatronWithDetailsDto
        {
            Id = patron.Id,
            Name = patron.Name,
            Address = patron.Address,
            Books = patron.Books.Select(p => new BookDto
            {
                Id = p.Id,
                Title = p.Title,
                Author = p.Author,
                PublicationYear = p.PublicationYear,
                BookISBN = p.BookISBN
            }).ToList()
        };
    }

    public bool Update(PatronDto NewPatron)
    {
        Patron? PatronToUpdate = repo.GetById(NewPatron.Id);
        if (PatronToUpdate == null)
        {
            return false;
        }
        PatronToUpdate.Name=NewPatron.Name;
        PatronToUpdate.Address=NewPatron.Address;
        repo.Update(PatronToUpdate);
        repo.SaveChanges();
        return true;

    }

}
