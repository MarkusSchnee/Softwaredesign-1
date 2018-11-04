using System;

namespace aufgabe03
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
            Console.WriteLine("Welche Zahl soll umgerechnet werden?");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("auswelchem zahlensystem stammt die zahl? Bitte als zahl eingeben. (z.B. Dezimal ist es eine 10)");
            int fromSystem = int.Parse(Console.ReadLine());
            Console.WriteLine("in welches zahlensystem soll umgerechnet werden? Bitte als zahl eingeben. (z.B. Binär ist eine 2)");
            int toSystem = int.Parse(Console.ReadLine());       
            Console.WriteLine("Das Ergebnis ist: " + ConvertNumberFromSystemToSystem(number, fromSystem, toSystem));
            }
            catch
            {
              Console.WriteLine("bitte eine gültige zahl eingeben");  
            }
        }

         static int ConvertNumberFromSystemToSystem(int number, int fromSystem, int toSystem)
            {
                int result = 0;
                if(fromSystem==10)
                {                   
                    result = DecimalToOther(number, toSystem);                   
                }

                else if (toSystem==10)
                {
                    result = OtherToDecimal(number, fromSystem);
                }

                else
                {                 
                    result = OtherToDecimal(number, fromSystem);
                    result = DecimalToOther(result, toSystem);                   
                }
                return result;
            }

           static int DecimalToOther(int dec, int system)
            {
                int result = 0;
                int factor = 1;
                while (dec != 0)
                {
                    int digit = dec % system;
                    dec /= system;
                    result += factor * digit;
                    factor *= 10;
                }
                return result;
            }

            static int OtherToDecimal(int other, int system)
            {
                int result = 0;
                int factor = 1;
                while (other != 0)
                {
                    int digit = other % 10;
                    other /= 10;
                    result += factor * digit;
                    factor *= system;
                }
                return result;
            }




    }
}
