using ITEC_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ITEC_WebApp.Data
{
    public class ContextITEC : DbContext
    {

        public ContextITEC(DbContextOptions<ContextITEC> options) : base(options)
        {

        }
        public DbSet<Test> Test { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Covid> Covid { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Weather> Weather { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().ToTable("Test");
            modelBuilder.Entity<Test>().ToTable("City");
            modelBuilder.Entity<Test>().ToTable("Country");
            modelBuilder.Entity<Test>().ToTable("Covid");
            modelBuilder.Entity<Test>().ToTable("Hotel");
            modelBuilder.Entity<Test>().ToTable("Room");
            modelBuilder.Entity<Test>().ToTable("User");
            modelBuilder.Entity<Test>().ToTable("Weather");
        }
    }
}
