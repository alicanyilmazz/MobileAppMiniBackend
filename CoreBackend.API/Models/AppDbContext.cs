using Microsoft.EntityFrameworkCore;

namespace CoreBackend.API.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Actress> Actresses { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Base Properties Definitions
            modelBuilder.Entity<Actress>().HasKey(x=>x.Id);
            modelBuilder.Entity<Movie>().HasKey(x => x.Id);
            modelBuilder.Entity<Category>().HasKey(x => x.Id);

            modelBuilder.Entity<Actress>().Property(x => x.CreatedDate).ValueGeneratedOnAdd();
            modelBuilder.Entity<Movie>().Property(x => x.CreatedDate).ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().Property(x => x.CreatedDate).ValueGeneratedOnAdd();

            //modelBuilder.Entity<Actress>().Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
            //modelBuilder.Entity<Movie>().Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
            //modelBuilder.Entity<Category>().Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
            //HasColumnType("decimal(18,2)")

            modelBuilder.Entity<Actress>().Property(x => x.UpdatedDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Movie>().Property(x => x.UpdatedDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Category>().Property(x => x.UpdatedDate).HasDefaultValueSql("getdate()");

            // Actress Properties Definitions
            modelBuilder.Entity<Actress>().Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired(); //.HasColumnType(nvarchar)
            modelBuilder.Entity<Actress>().Property(x => x.Age).HasColumnName("Age").HasMaxLength(100).IsRequired(); //.HasColumnType(int)
            modelBuilder.Entity<Actress>().Property(x => x.PlaceOfBirth).HasColumnName("PlaceOfBirth").HasMaxLength(100).IsRequired(); //.HasColumnType(nvarchar)

            // Movie Properties Definitions
            modelBuilder.Entity<Movie>().Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired(); //.HasColumnType(nvarchar)
            modelBuilder.Entity<Movie>().Property(x => x.Author).HasColumnName("Author").HasMaxLength(100).IsRequired(); //.HasColumnType(nvarchar)
            modelBuilder.Entity<Movie>().Property(x => x.PhotoPath).HasColumnName("PhotoPath").HasMaxLength(100).IsRequired(); //.HasColumnType(nvarchar)
            modelBuilder.Entity<Movie>().Property(x => x.ReleaseDate).HasColumnName("ReleaseDate");

            // Category Properties Definitions
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();

            // Entity Relation Defitions
            modelBuilder.Entity<Category>().HasMany(x => x.Movies).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Actress>().HasMany(x => x.Movies).WithMany(x => x.Actresses).UsingEntity<Dictionary<string, object>>(
           "ActressMovie",
            x => x.HasOne<Movie>().WithMany().HasForeignKey("MovieId").HasConstraintName("FK__MovieId"),
            x => x.HasOne<Actress>().WithMany().HasForeignKey("ActressId").HasConstraintName("FK__ActressId")
           );

           base.OnModelCreating(modelBuilder);
        }
    }
}
