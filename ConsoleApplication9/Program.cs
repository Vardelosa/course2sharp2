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
            persons[0] = new Person("Vladimir", "Ahakov", new DateTime(2000, 11, 13));
            persons[1] = new Person("Artemiy", "Begasov", new DateTime(1997, 03, 05));
            persons[2] = new Person("John", "Cook", new DateTime(1999, 09, 27));
            copyrat[0] = new Copywriter(persons[0], "King", (Level)1, 4);
            copyrat[1] = new Copywriter(persons[1], "Rognak", 0, 3);
            copyrat[2] = new Copywriter(persons[2], "Kilimonjaru", 0, 2);


            CopywriterCollection c1 = new CopywriterCollection();
            CopywriterCollection c2 = new CopywriterCollection();
            c1.ColName = "Collection 1";
            c2.ColName = "Сollection 2";
            Journal j1 = new Journal();
            Journal j2 = new Journal();
            c1.CopywritersCountChanged += j1.Changer;
            c1.CopywriterReferenceChanged += j1.Changer;
            c1.CopywriterReferenceChanged += j2.Changer;
            c2.CopywriterReferenceChanged += j2.Changer;
            c1.AddDefaults();
            c2.AddDefaults();
            c1.Remove(0);
            c2.Remove(1);
            c1[1] = copyrat[0];
            c2[1] = copyrat[1];
            Console.WriteLine(j1.ToString());
            Console.WriteLine(j2.ToString());
            Console.ReadKey();
        }
    }
}
