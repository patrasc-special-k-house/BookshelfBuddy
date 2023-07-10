using BookshelfBuddy.Data.Entities;

namespace BookshelfBuddy.Data.Repositories
{
    public class ShelvesRepository : BaseRepository<Shelf>
    {
        public ShelvesRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
