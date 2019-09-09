using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersys
{
    public class SolutionTests
    {
        private StringReader stringReader;
        private StringWriter stringWriter;

        private TextReader defaultIn;
        private TextWriter defaultOut;

        private Solution solution;

        public SolutionTests(Solution solution)
        {
            this.solution = solution;
        }

        public void Run()
        {
            Init();
            defaultOut.WriteLine("Reverse array: " + ReverseArray());
            defaultOut.WriteLine("Palindrome: " + Palindrome());
            defaultOut.WriteLine("Permutation: " + Permutation());
            defaultOut.WriteLine("ExistingPowersOf2: " + ExistingPowersOf2());
            defaultOut.WriteLine("FindingPrimes: " + FindingPrimes());
            defaultOut.WriteLine("CommonDigit: " + CommonDigit());
            defaultOut.WriteLine("DigitSum: " + DigitSum());

            Dispose();
        }
        private void Init()
        {
            stringWriter = new StringWriter();

            defaultIn = Console.In;
            defaultOut = Console.Out;
            
            Console.SetOut(stringWriter);
        }
        private void Dispose()
        {
            stringWriter.Dispose();
            stringReader?.Dispose();
            Console.SetIn(defaultIn);
            Console.SetOut(defaultOut);
        }
        private void SetConsoleInput(string input)
        {
            stringReader = new StringReader(input);
            Console.SetIn(stringReader);
        }
        private void ClearWriter(StringWriter stringWriter)
        {
            stringWriter.GetStringBuilder().Clear();
        }

        private string ReverseArray()
        {
            SetConsoleInput("3" +
                Environment.NewLine +
                "1 2 3");

            solution.ReverseArray();

            var res1 = stringWriter.ToString();
            ClearWriter(stringWriter);


            SetConsoleInput("4" +
                    Environment.NewLine +
                    "1 2 1 0");

            solution.ReverseArray();

            var res2 = stringWriter.ToString();
            ClearWriter(stringWriter);


            return (res1 == "3 2 1" && res2 == "0 1 2 1").ToString();
        }



        private string Palindrome()
        {
            SetConsoleInput("abut-1-tuba");

            solution.Palindrome();

            var res1 = stringWriter.ToString();
            ClearWriter(stringWriter);

            SetConsoleInput("@allula");

            solution.Palindrome();

            var res2 = stringWriter.ToString();
            ClearWriter(stringWriter);

            return (res1 == "YES" && res2 == "NO").ToString();
        }
        private string Permutation()
        {
            string output = "";
            SetConsoleInput("1 2 5 3 7 0 7 3 5 2 1" + Environment.NewLine + "7 3 1 2 5 0 5 2 1 3 7");

            solution.Permutation();

            var res1 = stringWriter.ToString();
            ClearWriter(stringWriter);

            output += "Case 1: " + (res1 == "YES") + Environment.NewLine;


            SetConsoleInput("1 2 3 4 5 6 7 8 9 10 11" + Environment.NewLine + "6 5 4 3 2 0 11 10 9 8 7");

            solution.Permutation();

            var res2 = stringWriter.ToString();
            ClearWriter(stringWriter);

            output += "Case 2: " + (res2 == "NO");
            return output;
        }
        private string ExistingPowersOf2()
        {
            string output = "";
            SetConsoleInput("1" + Environment.NewLine 
                             + "3" + Environment.NewLine
                             + "4");

            solution.ExistingPowersOf2();

            var res1 = stringWriter.ToString();
            ClearWriter(stringWriter);

            output += "Case 1: " + (res1 == "1, 2, 4") + Environment.NewLine;


            SetConsoleInput("3" + Environment.NewLine
                 + "1" + Environment.NewLine
                 + "2");

            solution.ExistingPowersOf2();

            var res2 = stringWriter.ToString();
            ClearWriter(stringWriter);

            output += "Case 2: " + (res2 == "1, 2");
            return output;
        }
        private string FindingPrimes()
        {
            string output = "";
            SetConsoleInput("1" + Environment.NewLine
                             + "1 10");

            solution.FindingPrimes();

            var res1 = stringWriter.ToString();
            ClearWriter(stringWriter);

            output += "Case 1: " + (res1 == "4" + Environment.NewLine);


            SetConsoleInput("2" + Environment.NewLine
                 + "100 200" + Environment.NewLine
                 + "1 1");

            solution.FindingPrimes();

            var res2 = stringWriter.ToString();
            ClearWriter(stringWriter);

            output += "Case 2: " + (res2 == ("21" + Environment.NewLine+ 
                                             "0" + Environment.NewLine));
            return output;
        }
        private string CommonDigit()
        {
            string output = "";
            SetConsoleInput("4" + Environment.NewLine
                             + "101 20 21 3");

            solution.CommonDigit();

            var res1 = stringWriter.ToString();
            ClearWriter(stringWriter);

            output += "Case 1: " + (res1 == "1");


            SetConsoleInput("3" + Environment.NewLine
                 + "111 222 5");

            solution.CommonDigit();

            var res2 = stringWriter.ToString();
            ClearWriter(stringWriter);

            output += "Case 2: " + (res2 == ("2"));
            return output;
        }
        private string DigitSum()
        {
            string output = "";
            SetConsoleInput("3" + Environment.NewLine
                             + "2 4 3");

            solution.DigitSum();

            var res1 = stringWriter.ToString();
            ClearWriter(stringWriter);

            output += "Case 1: " + (res1 == "1");


            SetConsoleInput("3" + Environment.NewLine
                 + "20 21 19");

            solution.DigitSum();

            var res2 = stringWriter.ToString();
            ClearWriter(stringWriter);

            output += "Case 2: " + (res2 == ("2"));
            return output;
        }
    }
}
