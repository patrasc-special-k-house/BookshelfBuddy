using BookshelfBuddy.Data.Entities;
using BookshelfBuddy.Services.Dtos;

namespace BookshelfBuddy.Services
{
    public class BookService
    {
        private readonly UnitOfWork _unitOfWork;

        public BookService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Book> GetAll()
        {
            var result = _unitOfWork.Books.GetAll();

            return result;
        }

        public Book GetById(Guid bookId)
        {
            var result = _unitOfWork.Books.GetById(bookId);

            return result;
        }

        public bool Insert(BookDto bookDto)
        {
            if (bookDto == null)
            {
                return false;
            }

            var result = _unitOfWork.Shelves.GetById(bookDto.ShelfId);
            if (result == null) return false;

            var newBook = new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                Genre = bookDto.Genre,
                Description = bookDto.Description,
                ShelfId = bookDto.ShelfId
            };

            _unitOfWork.Books.Insert(newBook);
            _unitOfWork.SaveChanges();

            return true;
        }

        public bool Update(Guid id, BookDto book)
        {
            if (id == Guid.Empty || book == null)
            {
                return false;
            }

            var result = _unitOfWork.Books.GetById(id);
            if (result == null) return false;

            result.Title = book.Title;
            result.Author = book.Author;
            result.Genre = book.Genre;
            result.Description = book.Description;
            result.ShelfId = book.ShelfId;

            _unitOfWork.Books.Update(result);
            _unitOfWork.SaveChanges();

            return true;
        }

        public bool Remove(Guid id)
        {
            if (id == Guid.Empty)
            {
                return false;
            }

            var result = _unitOfWork.Books.GetById(id);
            if (result == null) return false;

            _unitOfWork.Books.Remove(result);
            _unitOfWork.SaveChanges();

            return true;
        }
    }
}
