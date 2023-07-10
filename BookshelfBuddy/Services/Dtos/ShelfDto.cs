using BookshelfBuddy.Data.Entities;

namespace BookshelfBuddy.Services.Dtos
{
    public class ShelfDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid ShelfOwnerId { get; set; } = Guid.Empty;
    }
}