using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ConsoleApplication9
{
    class CopywriterCollection : Person
    {

        public List<Copywriter> CopywriterList = new List<Copywriter>();
        
        public void AddDefaults()
        {
            const int defa = 3;
            for (int n = 0; n < defa; n++)
            {
                CopywriterList.Add(new Copywriter());
                CopywritersCountChanged?.Invoke(this, new CopywriterListHandlerEventArgs(ColName,
                                                                                 "Elemest added",
                                                                                 new Copywriter()));
            }
        }
        
        public void AddCopywriters(params Copywriter[] copywriters)
        {
            for (int i = 0; i < copywriters.Length; i++)
            {
                CopywriterList.Add(copywriters[i]);
                CopywritersCountChanged?.Invoke(this, new CopywriterListHandlerEventArgs(ColName,
                                                                                 "Elemest added",
                                                                                 copywriters[i]));
            }
        }
        public override string ToString()
        {
            string s = "List:\n";
            foreach (var c in CopywriterList)
                s += c.ToString();
            return s;
        }
        public string ToShortString()
        {
            string s = "";
            foreach (var c in CopywriterList)
            {
                s = s + "Author: " + c.AuthorInfo + "\r\n Nickname: " + c.Nickname + "\r\n Level: " + c.Level + "\r\n Rating: " + c.Rating;

                s = s + "\r\n Middle symbols in article: " + c.Middle + "\n";

            }
            return s;
        }
        //обьявление делегата
        public delegate void CopywriterListHandler(object source, CopywriterListHandlerEventArgs args);
        public string ColName { get; set; }
       
        
        public bool Remove(int n)
        {
            if (n > CopywriterList.Count | n < 0)
                return false;
            else
            {
                CopywriterList.RemoveAt(n);
                CopywritersCountChanged?.Invoke(this, new CopywriterListHandlerEventArgs(ColName,
                                                                                 "Elemest deleted",
                                                                                 CopywriterList[n]));
                return true;
            }

        }
        public Copywriter this[int index]
        {
            
            get
            {
                return CopywriterList[index];
            }
            set
            {
                CopywriterList[index] = value;
                CopywriterReferenceChanged?.Invoke(this, new CopywriterListHandlerEventArgs(ColName,
                                                                                    "Element Changed",
                                                                                    value));
            }
        }
        public event CopywriterListHandler CopywritersCountChanged;
        public event CopywriterListHandler CopywriterReferenceChanged;

        }
}
