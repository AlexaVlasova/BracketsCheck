using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BracketsCheck
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string wrongEq = "(5+[4*(3+2)-7)+9]";
            string rightEq = "{3+[5*(6+3)*(56/[7+1]*{3+5}*7)-[4+5]*7]-7}";
            Stack<char> brackets = new Stack<char>();

            char[] masWrong = wrongEq.ToCharArray();
            char[] masRignt = rightEq.ToCharArray();

            if (CheckBrackets.Check(masWrong, brackets) == true) Console.WriteLine("Правильная скобочная последовательность");
            else Console.WriteLine("Неверная скобочная последовательность");

            if (CheckBrackets.Check(masRignt, brackets) == true) Console.WriteLine("Правильная скобочная последовательность");
            else Console.WriteLine("Неверная скобочная последовательность");

        }

        public class CheckBrackets
        {
            public static bool Check(char[] equation, Stack<char> brackets)
            {
                bool check = false;
                brackets.Clear();

                for (int i = 0; i < equation.Length; i++)
                {
                    if (equation[i].Equals('(') || equation[i].Equals('[') || equation[i].Equals('{'))
                    {
                        brackets.Push(equation[i]);
                    }
                    else
                    {
                        if (equation[i].Equals(')') && brackets.Peek().Equals('('))
                        {
                            brackets.Pop();
                        }
                        if (equation[i].Equals(']') && brackets.Peek().Equals('['))
                        {
                            brackets.Pop();
                        }
                        if (equation[i].Equals('}') && brackets.Peek().Equals('{'))
                        {
                            brackets.Pop();
                        }
                    }
                }

                if (brackets.Count == 0) check = true;
                return check;

            }
        }
    }
}

