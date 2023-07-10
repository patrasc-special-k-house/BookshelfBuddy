namespace BookshelfBuddy.Services.Dtos
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid ShelfId { get; set; } = Guid.Empty;
    }
}
