namespace BookshelfBuddy.Data.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid ShelfId { get; set; } = Guid.Empty;
        public Shelf? Shelf { get; set; } = null;
    }
}
