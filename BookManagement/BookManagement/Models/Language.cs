using System;
using System.Collections.Generic;

#nullable disable

namespace BookManagement.Models
{
    public partial class Language
    {
        public Language()
        {
            Books = new HashSet<Book>();
        }

        public Guid LanguageId { get; set; }
        public string LanguageName { get; set; }
        public bool? IsActived { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
