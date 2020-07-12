using System;

namespace TestApplication.Models
{
    public class Accounting
    {
        public int AccountingId { get; set; }
        public int Sum { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
