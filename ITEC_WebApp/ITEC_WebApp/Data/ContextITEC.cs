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
            modelBuilder.Entity<Weather>().HasOne(e => e.City).WithOne(e => e.Weather).HasForeignKey<City>(e => e.IdCity);
            modelBuilder.Entity<Country>().HasOne(e => e.Covid).WithOne(e => e.Country).HasForeignKey<Covid>(e => e.IdCovid);

            modelBuilder.Entity<Test>().ToTable("Test");
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Covid>().ToTable("Covid");
            modelBuilder.Entity<Hotel>().ToTable("Hotel");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Weather>().ToTable("Weather");
        }
    }
}
