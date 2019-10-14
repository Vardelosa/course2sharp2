using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    class Order
    {
        public string Theme { get; set; }
        public DateTime Orderdate { get; set; }
        public int Deadline { get; set; }
        public Order()
        {
            Theme = "Unknown";
            Orderdate = new DateTime();
            Deadline = 0;
        }
        public Order(string theme, DateTime orderdate, int deadline)
        {
            Theme = theme;
            Orderdate = orderdate;
            Deadline = deadline;
        }
        public override string ToString()
        {
            string s = "Theme: " + Theme + ". Deadline: " + Deadline + "hours. " + "Date: " + Orderdate + ".";
            return s;
        }
    }
}