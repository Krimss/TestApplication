using System;

namespace TestApplication.Controllers
{
    public class Question
    {
        public bool GroupByCategoryId { get; set; }
        public bool GroupByMonthNum { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
    }
}
