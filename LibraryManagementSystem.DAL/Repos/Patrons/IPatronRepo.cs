using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL;

public interface IPatronRepo
{
    IEnumerable<Patron> GetAll();   
    Patron? GetById(int id); 
    void Add(Patron patron);    
    void Update(Patron patron); 
    void Delete(Patron patron);
    Patron? GetPatronWithDetails(int id);
    int SaveChanges();
}
