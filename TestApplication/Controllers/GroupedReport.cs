using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Models;
namespace TestApplication.Controllers
{
    public class GroupedReport
    {
        public List<string> Keys { get; set; }
        public List<Accounting> Accountings { get; set; }
        public GroupedReport(string c, string m,List<Accounting> a)
        {
            Keys = new List<string>();
            Keys.Add(c == "-1" ? "Группировка по категории отсутсвует" : "Группировка по категории " + c);
            Keys.Add(m == "-1" ? "Группировка по месяцу отсутсвует" : "Группировка по месяцу " + m);
            Accountings = a;
        }
    }
}
