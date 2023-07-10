namespace BookshelfBuddy.Data.Entities
{
    public class Shelf : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Book> Books { get; set; } = new List<Book>();
        public Guid ShelfOwnerId { get; set; } = Guid.Empty;
        public ShelfOwner? ShelfOwner { get; set; } = null;
    }
}
