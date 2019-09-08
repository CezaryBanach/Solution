using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Intersys
{
    public class Solution
    {
        private List<int> StringToIntList(string input, char separator = ' ')
        {
            return input.Split(separator).Select(Int32.Parse).ToList();
        }

        public void ReverseArray()
        {
            int N = Int32.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            List<int> res = StringToIntList(input);
            for(int i = 0; i<res.Count/2; i++)
            {
                int tmp = res[i];
                res[i] = res[res.Count - i - 1];
                res[res.Count - i - 1] = tmp;
            }
            var resString = "";
            for (int i = 0; i < res.Count; i++)
            {
                resString+=res[i] + " ";
            }
            Console.Write(resString.TrimEnd());
        }
        public void Palindrome()
        {
            string input = Console.ReadLine();
            Regex regex = new Regex("[^a-zA-Z]");
            input = regex.Replace(input, "");
            for (int i = 0; i < input.Length / 2; i++)
            {
                if (char.ToLower(input[i]) != char.ToLower(input[input.Length - i-1]))
                {
                    Console.Write("NO");
                    return;
                }
            }
            Console.Write("YES");
        }
        public void Permutation()
        {
            var input1 = StringToIntList(Console.ReadLine());
            var input2 = StringToIntList(Console.ReadLine());
            input1.Sort();
            input2.Sort();
            for (int i = 0; i < input1.Count; i++)
            {
                if (input1[i] != input2[i])
                {
                    Console.Write("NO");
                    return;
                }
            }
            Console.Write("YES");
        }
        public void ExistingPowersOf2()
        {
            string line;
            List<int> input = new List<int>();
            while ((line = Console.ReadLine()) != null)
            {
                int intVal;
                if(Int32.TryParse(line, out intVal))
                {
                    input.Add(intVal);
                }
            }
            //check if list is faster
            HashSet<double> res = new HashSet<double>();
            foreach (var elem in input)
            {
                var binaryRep = Convert.ToString(elem, 2);

                for (int i = 0; i < binaryRep.Length; i++)
                {
                    if (char.Equals('1', binaryRep[i]))
                    {
                        var powerOf2 = Math.Pow(2, binaryRep.Length - i - 1);
                        res.Add(powerOf2);
                    }
                }
            }
            var ordered = res.OrderBy(x => x);
            string output = "";
            if (!res.Any())
            {
                return;
            }
               
            for (int i = 0; i < res.Count; i++)
            {
                output+=ordered.ElementAt(i) +", ";
            }
            output = output.TrimEnd();
            
            output = output.Substring(0, output.Length - 1);
            Console.Write(output);
        }
        public void FindingPrimes()
        {
            var N = Int32.Parse(Console.ReadLine());
            List<Tuple<int, int>> cases = new List<Tuple<int, int>>();
            while (N > 0)
            {
                var input = StringToIntList(Console.ReadLine());
                cases.Add(new Tuple<int, int>(input.ElementAt(0), input.ElementAt(1)));
                N--;
            }
            //we call sieve only once, for greates value of n
            var maxEnd = cases.Max(x => x.Item2);
            var primes = SieveOfEratosthenes(maxEnd);

            for (int i = 0; i < cases.Count; i++)
            {
                //take n, skip m
                Console.WriteLine(primes.Take(cases[i].Item2).Skip(cases[i].Item1+1).Where(x => x).Count());
            }

            bool[] SieveOfEratosthenes(int n)
            {
                bool[] tab = new bool[n];
                for (int i = 0; i < tab.Length; i++)
                {
                    tab[i] = true;
                }
                var sqrtOfEnd = Math.Floor(Math.Pow(n, 0.5));
                for (int i = 2; i <= sqrtOfEnd; i++)
                {
                    if (tab[i])
                    {
                        for (int j = i*i; j < n; j +=i)
                        {
                            tab[j] = false;
                        }
                    }
                }
                return tab;
            }
        }
        public void CommonDigit()
        {
            int N = Int32.Parse(Console.ReadLine());
            var inputList = StringToIntList(Console.ReadLine());
            List<int> digitsCount = new List<int>();
            for(int i =0; i<=9; i++)
            {
                digitsCount.Add(0);
            }
            for (int i = 0; i < inputList.Count; i++)
            {
                var digits = SplitIntoDigits(inputList[i]);
                for (int j = 0; j < digits.Length; j++)
                {                  
                    digitsCount[digits[j]]++;
                }
            }

            int maxCount = digitsCount[9];
            int maxDigit = 9;
            for (int i = 8; i >= 0; i--)
            {
                if (digitsCount[i] > maxCount)
                {
                    maxCount = digitsCount[i];
                    maxDigit = i;
                }
                    
            }

            Console.Write(maxDigit);
        }
        public void DigitSum()
        {
            int N = Int32.Parse(Console.ReadLine());
            var input = StringToIntList(Console.ReadLine());
            var maxIndex = 0;
            var max = 0;
            for (int i = 0; i < N; i++)
            {
                var digitsSum = SplitIntoDigits(input[i]).Sum();
                if (digitsSum > max)
                {
                    max = digitsSum;
                    maxIndex = i;
                }
            }
            Console.Write(maxIndex);
        }
        int[] SplitIntoDigits(int input)
        {
            List<int> res = new List<int>();
            while (input > 0)
            {
                res.Add(input % 10);
                input /= 10;
            }
            return res.ToArray();
        }
    }
}
