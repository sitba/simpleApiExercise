using Microsoft.EntityFrameworkCore;
using simpleApiExercise.Model.Providers;

namespace simpleApiExercise.Database
{
    public class ProvidersContext : DbContext
    {
        public DbSet<Provider> Providers { get; set; }

        public string DbPath { get; }

        public ProvidersContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "providers.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provider>()
                .Property(provider => provider.Id)
                .IsRequired()
                .HasColumnType(typeName: typeof(int).Name);
            modelBuilder.Entity<Provider>()
                .Property(provider => provider.Name)
                .IsRequired()
                .HasColumnType(typeName: typeof(string).Name);
            modelBuilder.Entity<Provider>()
                .Property(provider => provider.PostalAddress)
                .HasColumnType(typeName: typeof(string).Name);
            modelBuilder.Entity<Provider>()
                .Property(provider => provider.CreatedDate)
                .HasColumnType(typeName: typeof(DateTime).Name);
            modelBuilder.Entity<Provider>()
                .Property(provider => provider.Type)
                .HasColumnType(typeName: typeof(string).Name);
        }
    }
}