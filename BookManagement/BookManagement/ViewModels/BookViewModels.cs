using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.ViewModels
{
    public class BookViewModel
    {
        public Guid BookId { get; set; }
        public Guid? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double? Price { get; set; }
        public int? Amount { get; set; }

        public int? PrintLength { get; set; }
        public int? ReleaseYear { get; set; }
        public string Publisher { get; set; }

        public Guid? LanguageId { get; set; }
        public string LanguageName { get; set; }
    }

    public class AddOrUpdateBookModel
    {
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

    }
}
