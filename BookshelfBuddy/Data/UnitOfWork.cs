using BookshelfBuddy.Data.Entities;
using BookshelfBuddy.Data.Repositories;

namespace BookshelfBuddy.Data
{
    public class UnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public ShelfOwnersRepository ShelfOwners { get; }
        public BooksRepository Books { get; }
        public ShelvesRepository Shelves { get; }
        public UsersRepository Users { get; }


        public UnitOfWork
        (
            AppDbContext dbContext,
            ShelfOwnersRepository shelfOwnersRepository,
            BooksRepository booksRepository,
            ShelvesRepository shelvesRepository,
            UsersRepository usersRepository
        )
        {
            _dbContext = dbContext;
            ShelfOwners = shelfOwnersRepository;
            Books = booksRepository;
            Shelves = shelvesRepository;
            Users = usersRepository;
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                var errorMessage = "Error when saving to the database: "
                    + $"{exception.Message}\n\n"
                    + $"{exception.InnerException}\n\n"
                    + $"{exception.StackTrace}\n\n";

                Console.WriteLine(errorMessage);
            }
        }
    }
}
