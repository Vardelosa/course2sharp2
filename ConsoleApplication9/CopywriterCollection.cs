using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;


namespace ConsoleApplication9
{
     static class ListExten
    {
        public static void Sort_List(this List<Copywriter> list)
        {
            list.Sort(new Copywriter());
        }
    }
    class CopywriterCollection<TKey>  : Copywriter
    {
        public string ColName { get; set; }

        public delegate void CopywritersChangedHandler<TKey>(object source, CopywritersChangedEventArgs<TKey> args);

        public event CopywritersChangedHandler<TKey> CopywritersChanged;

        Dictionary<TKey, Copywriter> dic = new Dictionary<TKey, Copywriter>();

        public delegate TKey KeyGenerator(Copywriter cw);

        public event KeyGenerator GenerateKey;

        public void Sort_ColList(List<Copywriter> list)
        {
            list.Sort(new Copywriter());
        }
        public void AddCopywriters(params Copywriter[] copywriters)
        {
            foreach (var cw in copywriters)
            {
                cw.PropertyChanged += PropertyChanged;
                dic.Add(GenerateKey(cw), cw);
                CopywritersChanged?.Invoke(cw, new CopywritersChangedEventArgs<TKey>(ColName, Action.Add, null, GenerateKey(cw)));
            }
        }
        public bool Remove(Copywriter cw)
        {
            if (!dic.ContainsValue(cw))
                return false;
            else
            {
                var item = dic.First(kvp => kvp.Value == cw);
                CopywritersChanged?.Invoke(cw, new CopywritersChangedEventArgs<TKey>(ColName, Action.Remove, null, GenerateKey(item.Value)));
                dic.Remove(item.Key);
                return true;
            }
        }
        public Copywriter this[TKey key]
        {
            
            get
            {
                return dic[key];
            }
            set
            {
                dic[key] = value;
                value.PropertyChanged += PropertyChanged;
            }
        }
        private void PropertyChanged(object source, PropertyChangedEventArgs args)
        {
            CopywritersChanged?.Invoke(source, new CopywritersChangedEventArgs<TKey>(ColName, Action.Property, args.PropertyName, GenerateKey(source as Copywriter)));
        }
        public override string ToString()
        {
            string s = "List:\n";
            foreach (var c in dic)
                s += c.Value.ToString();
            return s;
        }
        public string ToShortString()
        {
            string s = "";
            foreach (var c in dic)
            {
                s = s + "Author: " + c.Value.AuthorInfo + "\r\n Nickname: " + c.Value.Nickname + "\r\n Level: " + c.Value.Level + "\r\n Rating: " + c.Value.Rating;

                s = s + "\r\n Middle symbols in article: " + c.Value.Middle + "\n";

            }
            return s;
        }
    }
}
