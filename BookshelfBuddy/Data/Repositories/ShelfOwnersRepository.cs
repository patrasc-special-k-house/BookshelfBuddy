using BookshelfBuddy.Data.Entities;

namespace BookshelfBuddy.Data.Repositories
{
    public class ShelfOwnersRepository : BaseRepository<ShelfOwner>
    {
        public ShelfOwnersRepository(AppDbContext dbContext) : base(dbContext) { }

        public ShelfOwner? GetByUserId(Guid userId)
        {
            var result = _dbContext.ShelfOwners.FirstOrDefault(e => e.UserId == userId);

            return result;
        }
    }
}
