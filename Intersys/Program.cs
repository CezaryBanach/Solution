using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Intersys
{
    class Program
    {
        static void Main(string[] args)
        {
            SolutionTests tests = new SolutionTests(new Solution());
            tests.Run();
            Console.Read();
        }
    }
}
