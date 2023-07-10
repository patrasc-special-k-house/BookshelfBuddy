using BookshelfBuddy.Data.Entities;

namespace BookshelfBuddy.Data.Repositories
{
    public class BooksRepository : BaseRepository<Book>
    {
        public BooksRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
