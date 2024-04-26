
using LibraryManagementSystem.BL;
using LibraryManagementSystem.DAL;
using LibraryManagementSystem.DAL.Data.Context;
using LibraryManagementSystem.DAL.Repos.Patrons;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<SystemContext>(options => options.UseSqlServer(ConnectionString));
           
            builder.Services.AddScoped<IPatronRepo, PatronRepo>();
            builder.Services.AddScoped<IBookRepo, BookRepo>();
            builder.Services.AddScoped<IBorrRecordRepo, BorrRecordRepo>();
            builder.Services.AddScoped<IPatronManager, PatronManager>();
            builder.Services.AddScoped<IBookManager, BookManager>();
            builder.Services.AddScoped<IBorrowingRecordManager, BorrowingRecordManager>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
