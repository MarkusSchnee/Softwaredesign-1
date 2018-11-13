using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringumdrehen
{
   class Program
    {
        public static char[] reserveString(string input)
        {
            char[] output = new char[input.Length];
 
            for (int i = 1; i <= input.Length; i++)
            {
                output[i-1] = input[input.Length-i];
            }
 
            return output;
        }
 
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a string!");
            string inputString = Console.ReadLine();
            char[] outputString = reserveString(inputString);
 
            for(int i = 0; i < inputString.Length-1; i++)
            {
                Console.Write(outputString[i]);
            }
 
            Console.Write(outputString[inputString.Length - 1]);
            Console.ReadKey();
        }
    }
}