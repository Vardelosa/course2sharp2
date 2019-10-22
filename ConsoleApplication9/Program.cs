using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{

    class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = new Person[3];
            Copywriter[] copyrat = new Copywriter[3];
            Person[] persons1 = new Person[3];
            Copywriter[] copyrat1 = new Copywriter[3];
            persons[0] = new Person("Vladimir", "Ahakov", new DateTime(2000, 11, 13));
            persons[1] = new Person("Artemiy", "Begasov", new DateTime(1997, 03, 05));
            persons[2] = new Person("John", "Cook", new DateTime(1999, 09, 27));
            copyrat[0] = new Copywriter(persons[0], "King", (Level)1, 4);
            copyrat[1] = new Copywriter(persons[1], "Rognak", 0, 3);
            copyrat[2] = new Copywriter(persons[2], "Kilimonjaru", 0, 2);
            persons1[0] = new Person("1Vladimir", "Ahakov1", new DateTime(2010, 11, 13));
            persons1[1] = new Person("1Artemiy", "Begasov1", new DateTime(1911, 03, 05));
            persons1[2] = new Person("1John", "Cook1", new DateTime(1999, 09, 27));
            copyrat1[0] = new Copywriter(persons1[0], "1King1", (Level)1, 4);
            copyrat1[1] = new Copywriter(persons1[1], "1Rognak1", 0, 3);
            copyrat1[2] = new Copywriter(persons1[2], "1Kilimonjaru1", 0, 2);

            CopywriterCollection<string> c1 = new CopywriterCollection<string>();
            CopywriterCollection<string> c2 = new CopywriterCollection<string>();
            c1.ColName = "Collection 1";
            c2.ColName = "Сollection 2";
            c1.GenerateKey += GenerateKeyByTeamName;
            c2.GenerateKey += GenerateKeyByTeamName;

            Journal<string> j1 = new Journal<string>();

            c1.CopywritersChanged += j1.Changer;
            c2.CopywritersChanged += j1.Changer;
            c1.AddCopywriters(copyrat);
            c2.AddCopywriters(copyrat1);
            c1["Vladimir"].Nickname = "CHANGED!";
            //c2["1John"].Rating = 3;
            c1["Artemiy"].Surname = "CHANGED!";
            c1.Remove(copyrat[0]);
            //c1["Vladimir"].Nickname = "Deleted";
            List<Copywriter> list1 = new List<Copywriter>();
            foreach(var item in copyrat)
            {
                list1.Add(item);
            }
            foreach (var item in copyrat1)
            {
                list1.Add(item);
            }
            foreach (var item in list1)
            {
                Console.WriteLine(item.ToShortString());
            }
            c1.Sort_ColList(list1);
            
            //Journal j1 = new Journal();
            //c1.CopywritersCountChanged += j1.Changer;
            //c1.CopywriterReferenceChanged += j1.Changer;
            //c1.CopywriterReferenceChanged += j2.Changer;
            //c2.CopywriterReferenceChanged += j2.Changer;
            //c1.AddDefaults();
            //c2.AddDefaults();
            //c1.Remove(0);
            //c2.Remove(1);
            //c1[1] = copyrat[0];
            //c2[1] = copyrat[1];
            //Console.WriteLine(j1.ToString());
            //Console.WriteLine(j2.ToString());
            Console.WriteLine(j1.ToString());
            foreach (var item in list1)
            {
                Console.WriteLine(item.ToShortString());
            }
            Console.ReadKey();
        }

        static string GenerateKeyByTeamName(Copywriter cw)
        {
            return cw.Name;
        }
    }
}

