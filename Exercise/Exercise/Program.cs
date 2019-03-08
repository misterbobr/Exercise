using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int[] alph = new int[26];
            char a;
            for (int i = 97; i < 123; i++)
            {
                a = (char)i;
                if (Regex.IsMatch(word, $"{a}", RegexOptions.IgnoreCase))
                {
                    alph[i - 0x61] = Regex.Matches(word, $"{a}", RegexOptions.IgnoreCase).Count;
                }
            }
            char _first = ' ';
            int _firstCount = 0;
            char _second = ' ';
            int _secondCount = 0;
            char _third = ' ';
            int _thirdCount = 0;
            for (int i = 97; i < 123; i++)
            {
                a = (char)i;
                if (alph[i - 97] > _firstCount)
                {
                    _third = _second;
                    _thirdCount = _secondCount;
                    _second = _first;
                    _secondCount = _firstCount;
                    _first = a;
                    _firstCount = alph[i - 97];
                }
                else if (alph[i - 97] > _secondCount)
                {
                    _third = _second;
                    _thirdCount = _secondCount;
                    _second = a;
                    _secondCount = alph[i - 97];
                }
                else if (alph[i - 97] > _thirdCount)
                {
                    _third = a;
                    _thirdCount = alph[i - 97];
                }
            }
            Console.WriteLine(_first + " " + _firstCount);
            Console.WriteLine(_second + " " + _secondCount);
            Console.WriteLine(_third + " " + _thirdCount);
            
            Console.ReadKey();
        }
    }
}
