using BookshelfBuddy.Data.Entities;

namespace BookshelfBuddy.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<ShelfOwner> ShelfOwners { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
