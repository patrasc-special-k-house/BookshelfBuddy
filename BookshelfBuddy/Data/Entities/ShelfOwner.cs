namespace BookshelfBuddy.Data.Entities
{
    public class ShelfOwner : BaseEntity
    {
        public Guid UserId { get; set; } = Guid.Empty;
        public User? User { get; set; } = null;
        public List<Shelf> Shelves { get; set; } = new List<Shelf>();
    }
}
