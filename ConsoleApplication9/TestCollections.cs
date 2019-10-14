using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    class TestCollections
    {
        List<Person> people = new List<Person>();
        List<string> str = new List<string>();
        Dictionary<Person, Copywriter> peopdic = new Dictionary<Person, Copywriter>();
        Dictionary<string, Copywriter> strdic = new Dictionary<string, Copywriter>();

        public static Copywriter GenerateCopywriter(int n)
        {
            return new Copywriter(new Person(n.ToString(), n.ToString(), new DateTime(n)), n.ToString(), (Level)(n%3), 3);
        }
        public TestCollections(int amount)
        {
            for (int i = 1; i <= amount; ++i)
            {
                Copywriter copy = GenerateCopywriter(i);
                people.Add(copy.AuthorInfo);
                str.Add(copy.AuthorInfo.ToString());
                peopdic.Add(copy.AuthorInfo, copy);
                strdic.Add(copy.AuthorInfo.ToString(), copy);
            }
        }
        public long TimePers(Copywriter copy)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            if (!people.Contains(copy.AuthorInfo))
                return -1;

            stopwatch.Stop();
            return stopwatch.ElapsedTicks;
        }
        public long TimeStr(Copywriter copy)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            if (!str.Contains(copy.AuthorInfo.ToString()))
                return -1;

            stopwatch.Stop();
            return stopwatch.ElapsedTicks;
        }
        public long TimeCopyDic(Copywriter copy)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            if (!peopdic.ContainsValue(copy))
                return -1;

            stopwatch.Stop();
            return stopwatch.ElapsedTicks;
        }
        public long TimeCopyDicKey(Copywriter copy)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            if (!peopdic.ContainsKey(copy.AuthorInfo))
                return -1;

            stopwatch.Stop();
            return stopwatch.ElapsedTicks;
        }
        public long TimeStrDic(Copywriter copy)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            if (!strdic.ContainsValue(copy))
                return -1;

            stopwatch.Stop();
            return stopwatch.ElapsedTicks;
        }
        public long TimeStrDicKey(Copywriter copy)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            if (!strdic.ContainsKey(copy.AuthorInfo.ToString()))
                return -1;

            stopwatch.Stop();
            return stopwatch.ElapsedTicks;
        }
    }
}
