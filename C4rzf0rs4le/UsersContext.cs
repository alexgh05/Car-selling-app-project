using C4rzf0rs4le.VideoUploadAPI;
using Microsoft.EntityFrameworkCore;

namespace C4rzf0rs4le
{
    public class UsersContext : DbContext
    {
        public DbSet<usersdatas> Users { get; set; }
        public DbSet<userslisting> Listings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Port=3306;Database=users_data;User=root;Password=octavian0504Aa&;";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<usersdatas>().ToTable("usersdatas");
            modelBuilder.Entity<userslisting>().ToTable("userslistings");
            modelBuilder.Entity<userslisting>().HasKey(l => l.Id); // Assuming Listing has a property 'Id' to be used as the primary key

            // Add other model configurations as necessary
        }
    }
}
