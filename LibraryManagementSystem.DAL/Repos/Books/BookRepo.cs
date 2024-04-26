using LibraryManagementSystem.DAL.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL;

public class BookRepo : IBookRepo
{
    private readonly SystemContext context;
    public BookRepo(SystemContext context)
    {
        this.context = context;
    }
    public void Add(Book book)
    {
        context.Set<Book>().Add(book);
    }

    public void Delete(Book book)
    {
        context.Set<Book>().Remove(book);
    }

    public IEnumerable<Book> GetAll()
    {
       return context.Set<Book>();
    }

    public Book? GetBookWithDetails(int id)
    {
        return context.Set<Book>().Include(b=>b.Patrons).FirstOrDefault(b=>b.Id==id);
    }

    public Book? GetById(int id)
    {
        return context.Set<Book>().FirstOrDefault(b => b.Id == id);
    }

    public int SaveChanges()
    {
        return context.SaveChanges();
    }

    public void Update(Book book)
    {
        
    }
}
