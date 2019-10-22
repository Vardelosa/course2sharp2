using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    class Journal<TKey>
    {
        private List<JournalEntry> JournalList= new List<JournalEntry>();
        public void Changer(object source, CopywritersChangedEventArgs<TKey> args)
        {
            JournalList.Add(new JournalEntry(args.ColName, args.ActInfo, args.PropertyName, args.Key.ToString()));
        }
       
        public override string ToString()
        {
            string s = "Journal: \n\n";
            foreach(var c in JournalList)
            {
                s += c.ToString() + "\n\n";
            }
            return s;
        }
    }
}
