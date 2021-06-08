using System;
using System.Collections.Generic;

namespace Generate_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine(string.Join("\n", p.generateParenthesis(3)));
        }

        public List<String> generateParenthesis(int n)
        {
            List<string> combinations = new List<string>();
            generateAll(new char[2 * n], 0, combinations);
            return combinations;
        }

        public void generateAll(char[] current, int pos, List<String> result)
        {
            if (pos == current.Length)
            {
                if (valid(current))
                    result.Add(new String(current));
            }
            else
            {
                current[pos] = '(';
                generateAll(current, pos + 1, result);
                current[pos] = ')';
                generateAll(current, pos + 1, result);
            }
        }

        public bool valid(char[] current)
        {
            int balance = 0;
            foreach (char c in current)
            {
                if (c == '(') balance++;
                else balance--;
                if (balance < 0) return false;
            }
            return (balance == 0);
        }
    }
}
