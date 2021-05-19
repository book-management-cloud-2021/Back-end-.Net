using System;
using System.Collections.Generic;

#nullable disable

namespace BookManagement.Models
{
    public partial class Book
    {
        public Book()
        {
            Histories = new HashSet<History>();
        }

        public Guid BookId { get; set; }
        public Guid? CategoryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double? Price { get; set; }
        public int? Amount { get; set; }
        public int? PrintLength { get; set; }
        public int? ReleaseYear { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public Guid? LanguageId { get; set; }
        public DateTime? InsertedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Category Category { get; set; }
        public virtual Language Language { get; set; }
        public virtual ICollection<History> Histories { get; set; }
    }
}
