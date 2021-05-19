using System;
using System.Collections.Generic;

#nullable disable

namespace BookManagement.Models
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool? IsActived { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
