using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.ViewModels
{
    public class HistoryViewModel
    {
        public Guid HistoryId { get; set; }
        public string? BookTitle { get; set; }
        public int? Amount { get; set; }
        public string CustomerFullname { get; set; }
        public string ManagerUsername { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
