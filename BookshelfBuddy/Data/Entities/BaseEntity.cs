using System.Diagnostics.CodeAnalysis;

namespace BookshelfBuddy.Data.Entities
{
    public class BaseEntity
    {
        [NotNull]
        public Guid Id { get; set; }
    }
}
