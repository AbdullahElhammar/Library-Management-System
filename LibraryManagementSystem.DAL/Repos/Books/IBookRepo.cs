using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL;

public interface IBookRepo
{
    IEnumerable<Book> GetAll();
    Book? GetById(int id);
    void Add(Book book);
    void Update(Book book);
    void Delete(Book book);
    Book? GetBookWithDetails(int id);
    int SaveChanges();
}
