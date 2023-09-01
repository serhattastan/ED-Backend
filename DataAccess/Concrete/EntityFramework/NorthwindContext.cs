using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile proje classlarını ilişkilendir
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\projectmodels;Database=Northwind;Trusted_Connection = true");
        }

        //Referansları veritabanındaki ilgili tablolar ile bağlama.
        //Product nesnesini Products tablosuna bağla.
        public DbSet<Product> Products { get; set; }
        //Category nesnesini Categories tablosuna bağla.
        public DbSet<Category> Categories { get; set; }
        //Customer nesnesini Customers tablosuna bağla.
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
