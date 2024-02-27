using Microsoft.EntityFrameworkCore;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Concrete
{
    public class SignalRContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-AV376HC\\SQLEXPRESS;initial Catalog=SignalRDb;integrated Security=true;TrustServerCertificate=True");

        }

        public DbSet<About> Abouts{ get; set; }
        public DbSet<Booking> Bookings{ get; set; }
        public DbSet<Category> Categorys{ get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<Discount> Discounts{ get; set; }
        public DbSet<Feature> Features{ get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<SocialMedia> SocialMedias{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SocialMedia>().HasKey(s => s.SocialMeadiaID);
        }

        public DbSet<Testimonial> Testimonials{ get; set; }
    }
}
