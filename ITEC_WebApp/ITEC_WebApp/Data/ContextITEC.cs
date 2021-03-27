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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().ToTable("Test");
        }
    }
}
