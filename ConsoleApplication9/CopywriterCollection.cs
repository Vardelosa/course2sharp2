using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ConsoleApplication9
{
     static class ListExten
    {
        public static void Sort_List(this List<Copywriter> list)
        {
            list.Sort(new Copywriter());
        }
    }
    class CopywriterCollection<TKey> : Copywriter
    {

        public List<Copywriter> CopywriterList = new List<Copywriter>();
        
        public void AddDefaults()
        {
            const int defa = 3;
            for (int n = 0; n < defa; n++)
            {
                CopywriterList.Add(new Copywriter());
                //CopywritersCountChanged?.Invoke(this, new CopywriterListHandlerEventArgs(ColName,
                //                                                                 "Elemest added",
                //                                                                 new Copywriter()));
            }
        }
        
        public void AddCopywriters(params Copywriter[] copywriters)
        {
            for (int i = 0; i < copywriters.Length; i++)
            {
                CopywriterList.Add(copywriters[i]);
                //CopywritersCountChanged?.Invoke(this, new CopywriterListHandlerEventArgs(ColName,
                //                                                                 "Elemest added",
                //                                                                 copywriters[i]));
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
        public delegate void CopywritersChangedHandler<TKey>(object source,CopywritersChangedEventArgs<TKey> args);
        public event CopywritersChangedHandler<TKey> CopywritersChanged;
        public string ColName { get; set; }
        Dictionary<TKey, Copywriter> dic = new Dictionary<TKey, Copywriter>();

        public bool Remove(Copywriter cw)
        {
            if (!dic.ContainsValue(cw))
                return false;
            else
            {
                var item = dic.First(kvp => kvp.Value == cw);
                dic.Remove(item.Key);
                //CopywritersCountChanged?.Invoke(this, new CopywriterListHandlerEventArgs(ColName,
                 //                                                                "Elemest deleted",
                   //                                                              CopywriterList[n]));
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
            }
        }

        }
}
