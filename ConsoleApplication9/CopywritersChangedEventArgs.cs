using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    public class CopywritersChangedEventArgs<TKey> : EventArgs
    {
        public string ColName { get; set; }
        public Action ActInfo { get; set; }
        public string PropertyName { get; set; }
        public TKey Key { get; set; }
        public CopywritersChangedEventArgs(string ColName, Action ActInfo, string ColInfo, TKey Key)
        {
            this.ColName = ColName;
            this.ActInfo = ActInfo;
            PropertyName = ColInfo;
            this.Key = Key;
        }
        public override string ToString()
        {
            string s = $"CopywritersChangedEventArg:\n" +
                $"Collection Name: {ColName}\n" +
                $"Info: {ActInfo}\n";

            if (ActInfo == Action.Property)
                s += $"Property: {PropertyName}\n";
            return s;
        }
    }
}
