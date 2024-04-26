using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BL;

public interface IBookManager
{
    IEnumerable<BookDto> GetAll();
    BookDto? GetById(int id);
    int Add(BookDto book);
    bool Update(BookDto book);
    bool Delete(int id);
    BookWithDetailsDto? GetBookWithDetails(int id);
}
