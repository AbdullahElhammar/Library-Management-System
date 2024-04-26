using LibraryManagementSystem.DAL.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL.Repos.Patrons
{
    public class PatronRepo:IPatronRepo
    {
        private readonly SystemContext context;
        public PatronRepo(SystemContext context)
        {
            this.context = context;
        }

        public void Add(Patron patron)
        {
            context.Set<Patron>().Add(patron);
        }

        public void Delete(Patron patron)
        {
            var PatronToDelete= context.Set<Patron>().FirstOrDefault(p=>p.Id==patron.Id);
            context.Set<Patron>().Remove(PatronToDelete);
        }

        public IEnumerable<Patron> GetAll()
        {
            return context.Set<Patron>();
        }

        public Patron? GetById(int id)
        {
           return context.Set<Patron>().FirstOrDefault(p => p.Id == id);
        }

        public Patron GetPatronWithDetails(int id)
        {
            return context.Set<Patron>().Include(p=>p.Books).First(p=>p.Id == id);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void Update(Patron patron)
        {

        }
    }
}
