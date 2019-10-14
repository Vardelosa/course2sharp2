using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    class CopywritersChangedEventArgs<TKey>
    {
        public string ColName { get; set; }
        public Action ActInfo { get; set; }
        public string ColInfo { get; set; }
        public TKey Key { get; set; }
        CopywritersChangedEventArgs(string ColName, Action ActInfo, string ColInfo, TKey Key)
        {
            this.ColName = ColName;
            this.ActInfo = ActInfo;
            this.ColInfo = ColInfo;
            this.Key = Key;
        }
        public override string ToString()
        {
            string s = ColName + "\n" + ActInfo + "\n" + ColInfo + "\n" + Key;
            return s;
        }
    }
}
