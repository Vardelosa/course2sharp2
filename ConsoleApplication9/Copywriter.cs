using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    class Copywriter : Person, IDateAndCopy
    {



        private int rating;
        private List<Article> artinfo = new List<Article>();
        private List<Order> ordinfo = new List<Order>();
        public string Nickname { get; set; }
        public Level Level { get; set; }
        public int Rating
        {
            get
            {
                return rating;
            }
            set
            {

                if (value <= 0 | value > 5)
                {
                    throw new ArgumentOutOfRangeException();
                }
                rating = value;
            }

        }

        public Copywriter(Person person, string nickname, Level level, int rating)
            : base(person.Name, person.Surname, person.Data)
        {
            Nickname = nickname;
            Level = level;
            Rating = rating;

        }
        public Copywriter()
        {
            Name = "Unknown";
            Surname = "Unknown";
            Data = new DateTime();
            Nickname = "Unknown";
            Level = 0;
            Rating = 1;

        }
        public new object DeepCopy()
        {
            Copywriter test = new Copywriter();
            test.Name = this.Name;
            test.Surname = this.Surname;
            test.Data = this.Data;
            test.Nickname = this.Nickname;
            test.Level = this.Level;
            test.Rating = this.Rating;
            test.artinfo = this.artinfo.ConvertAll(article => new Article(article.ArName, article.ArSymbols, article.ArDate));
            test.ordinfo = this.ordinfo.ConvertAll(order => new Order(order.Theme, order.Orderdate, order.Deadline));
            return test;

        }
        public IEnumerator<object> GetEnumerator()
        {
            foreach (var v in artinfo) { yield return v; }
            foreach (var v in ordinfo) { yield return v; }
        }
        public IEnumerable<Order> OrdersLate(int n)
        {
            foreach (var v in ordinfo)
            {
                if (v.Deadline > n)
                    yield return v;
            }
        }
        public int Middle
        {
            get
            {
                int sum = 0;
                int n;
                foreach (Article p in artinfo)
                {
                    sum = p.ArSymbols + sum;
                }
                n = sum / artinfo.Count;
                return n;
            }
        }
        public Person AuthorInfo
        {
            get
            {
                return new Person(Name, Surname, Data);
            }
            set
            {
                this.Name = value.Name;
                this.Surname = value.Surname;
                this.Data = value.Data;
            }
        }
        public Article LastArticle
        {
            get
            {
                if (artinfo.Count <= 0)
                {
                    return null;
                }
                else
                {
                    return artinfo[artinfo.Count - 1];
                }
            }
        }
        public List<Order> Ordinfo
        {
            get
            {
                return ordinfo;
            }
            set
            {
                ordinfo = value;
            }
        }
        public List<Article> Artinfo
        {
            get
            {
                return artinfo;
            }
            set
            {
                artinfo = value;
            }
        }

        public void AddArticles(params Article[] articles)
        {
            for (int i = 0; i < articles.Length; i++)
            {
                artinfo.Add(articles[i]);
            }
        }
        public void AddOrders(params Order[] orders)
        {
            for (int i = 0; i < orders.Length; i++)
            {
                ordinfo.Add(orders[i]);
            }
        }
        public override string ToString()
        {
            string s = "Author: " + AuthorInfo + ". " + "Date: " + data + "\r\n Nickname: " + Nickname + "\r\n Level: " + Level + "\r\n Rating: " + Rating;

            s = s + " \r\nList of articles: " + "\r\n";
            foreach (Article p in artinfo)
            {
                s = s + p.ToString() + "\r\n";
            }
            s = s + " \r\nList of orders: " + "\r\n";
            foreach (Order p in ordinfo)
            {
                s = s + p.ToString() + "\r\n";
            }
            return s;
        }
        public string ToShortString()
        {
            string s = "Author: " + AuthorInfo + "\r\n Nickname: " + Nickname;
            return s;
        }

    }
}