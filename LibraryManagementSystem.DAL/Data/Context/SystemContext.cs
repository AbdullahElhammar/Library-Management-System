
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL.Data.Context
{
    public class SystemContext:DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Patron> Patron { get; set; }
        public DbSet<BorrowingRecord> BorrowingRecord { get; set; }

        public SystemContext(DbContextOptions<SystemContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region BookList
            var Books= new List<Book>
            {
                new Book{Id=1, Title="Aldaa w Aldwaa", Author="Ibn Alqim", BookISBN=1, PublicationYear=2000},
                 new Book{Id=2, Title="Albokhary", Author="Albokhary", BookISBN=2, PublicationYear=1200},
                  new Book{Id=3, Title="Mindset Of Solution", Author="Ahmed Khalil", BookISBN=3, PublicationYear=2010},
                   new Book{Id=4, Title="Benefits", Author="Ibn Alqim", BookISBN=4, PublicationYear=2002},

            };
            #endregion
            #region Patrons
           var Patrons = new List<Patron> { 
            new Patron{Id=1, Name="ahmed", Address="cairo"},
            new Patron{Id=2, Name="ali", Address="alex"},
            new Patron{Id=3, Name="abdullah", Address="Mansoura"},
            new Patron{Id=4, Name="khalid", Address="minia"},
            };
            #endregion
            #region BorrowingRecords
            var BorrowingRecords = new List<BorrowingRecord>
            {
                new BorrowingRecord{Id=2, BookId=1, PatronId=1, BorrowDate=new DateTime(2024,3,25), ReturnDate=DateTime.Now},
                new BorrowingRecord{Id=3, BookId=2, PatronId=2, BorrowDate=new DateTime(2024,3,11), ReturnDate=DateTime.Now},
                new BorrowingRecord{Id=1, BookId=4, PatronId=3, BorrowDate=new DateTime(2024,3,17), ReturnDate=DateTime.Now},
                new BorrowingRecord{Id=4, BookId=1, PatronId=4, BorrowDate=new DateTime(2024,3,22), ReturnDate=DateTime.Now}
            };
            #endregion

            builder.Entity<Book>().HasData(Books);  
            builder.Entity<Patron>().HasData(Patrons);  
            builder.Entity<BorrowingRecord>().HasData(BorrowingRecords);

        }

    }
}
