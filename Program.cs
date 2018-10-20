using System;
using System.Text;
using System.Collections.Generic;

namespace Softwaredesign
{
    public class Program
    {
        static void Main(string[] args)
        { 

            try
            {
                int arabic = Convert.ToInt32(args[0]);             

                if (arabic >= 0 && arabic <= 999 )
                {
                Console.WriteLine(GetRomanNumber(arabic));               
                }

                else
                {
                Console.WriteLine("Outside the value range");           
                }
            }

            catch
            {
                Console.WriteLine("Only numbers");
            }
        }

public static string GetRomanNumber(int value)
{
   
     string res = "";
 
      if (value >= 900) { value -= 900; res += "CM"; }
 
      while (value >= 500) { value -= 500; res += "D"; }
      if (value >= 400) { value -= 400; res += "CD"; }
 
      while (value >= 100) { value -= 100; res += "C"; }
      if (value >= 90) { value -= 90; res += "XC"; }
 
      while (value >= 50) { value -= 50; res += "L"; }
      if (value >= 40) { value -= 40; res += "XL"; }
 
      while (value >= 10) { value -= 10; res += "X"; }
      if (value >= 9) { value -= 9; res += "IX"; }
 
      while (value >= 5) { value -= 5; res += "V"; }
      if (value >= 4) { value -= 4; res += "IV"; }
 
      while (value >= 1) { value -= 1; res += "I"; }
 
      return res;

 }
    }
}
