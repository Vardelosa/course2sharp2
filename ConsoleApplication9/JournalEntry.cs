using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    class JournalEntry
    {
        public string ColName { get; set; }
        public Action ActInfo { get; set; }
        public string ColInfo { get; set; }
        public string Key { get; set; }
        public JournalEntry(string ColName, Action ActInfo, string ColInfo, string Key)
        {
            this.ColName = ColName;
            this.ActInfo = ActInfo;
            this.ColInfo = ColInfo;
            this.Key = Key;
        }
        public override string ToString()
        {
            string s =$"Collection Name: {ColName}\n" +
                   $"Info: {ActInfo}\n"+
                   $"Key: {Key}\n";
            if (ActInfo == Action.Property)
                s += $"Property: {ColInfo}\n";
            return s;
        }

    }
}
