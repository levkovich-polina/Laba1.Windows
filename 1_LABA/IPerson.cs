using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_LABA
{
    internal interface IPerson
    {
        int CardNumber { get; }
        string Name { get; }
        DateTime Birthday { get; }
        int calcAge(DateTime date);
    }
}
