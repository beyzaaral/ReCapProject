using Entities.Conctere;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Conctere.EntityFramework
{
    //context : db tabloları proje class'larını ilişkilendirir.
    public class ReCapProjectContext : DbContext
        //okulda dosya adına göre yaz northwind'i
    {
        //projenin veritabanı ile ilişkilendirilendirilen yer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=ReCapProject;Trusted_Connection=true");
            //sqlserver'a nasıl bağlanılacağını belirtir.
            //yukarıda yazılan serverdan sonraki ıd sql dosyası ismi
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

    }
}
