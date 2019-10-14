using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication9
{
    interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Data { get; set; }
    }
}

