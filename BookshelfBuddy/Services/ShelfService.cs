using BookshelfBuddy.Data.Entities;
using BookshelfBuddy.Services.Dtos;
namespace BookshelfBuddy.Services
{
    public class ShelfService
    {
        private readonly UnitOfWork _unitOfWork;

        public ShelfService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Shelf> GetAll()
        {
            var result = _unitOfWork.Shelves.GetAll();

            return result;
        }
        public Shelf GetById(Guid id)
        {
            var result = _unitOfWork.Shelves.GetById(id);
            return result;
        }
        public ShelfOwner GetShelfOwner(Guid id)
        {
            return _unitOfWork.ShelfOwners.GetByUserId(id);
        }
        public bool Insert(ShelfDto shelfDto)
        {
            if (shelfDto == null)
            {
                return false;
            }

            var shelfOwner = _unitOfWork.ShelfOwners.GetById(shelfDto.ShelfOwnerId);
            if (shelfOwner == null) return false;

            var newShelf = new Shelf
            {
                Title = shelfDto.Title,
                Description = shelfDto.Description,
                ShelfOwnerId = shelfDto.ShelfOwnerId
            };

            _unitOfWork.Shelves.Insert(newShelf);
            _unitOfWork.SaveChanges();
            return true;
        }
        public bool Update(Guid id, ShelfDto shelf)
        {
            if (id == Guid.Empty || shelf == null)
            {
                return false;
            }

            var result = _unitOfWork.Shelves.GetById(id);
            if (result == null) return false;

            result.Title = shelf.Title;
            result.Description = shelf.Description;
            result.ShelfOwnerId = shelf.ShelfOwnerId;

            _unitOfWork.Shelves.Update(result);
            _unitOfWork.SaveChanges();
            return true;
        }
        public bool Remove(Guid id)
        {
            if (id == Guid.Empty)
            {
                return false;
            }

            var result = _unitOfWork.Shelves.GetById(id);
            if (result == null) return false;

            _unitOfWork.Shelves.Remove(result);
            _unitOfWork.SaveChanges();
            return true;
        }

    }
}