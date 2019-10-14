using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    class JournalEntry
    {
        public string ColName { get; set; }
        public string ColChanges { get; set; }
        public string ObjInf { get; set; }
        public JournalEntry(string cn, string cc, string oi)
        {
            ColName = cn;
            ColChanges = cc;
            ObjInf = oi;
        }
        public override string ToString()
        {
            string s ="\n"+ "Collection name: " + ColName + "\n" +"Changes: " + ColChanges + "\n" + "Copywriter: \n" +ObjInf;
            return s;
        }
      
    }
}
