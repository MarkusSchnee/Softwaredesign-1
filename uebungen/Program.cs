using System;

namespace uebungen
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialisierung();
            Inferenz();
            Arrays();
        }

    public static void Initialisierung()
    {           
            int i = 42;
            double pi = 3.1415;
            string salute = "Hallo World!";           
            Console.WriteLine("Teil Initialisierung");
            Console.WriteLine(i+" "+pi+" "+salute);
        }

     public static void Inferenz()
     {            
            var iv = 43;
            var piv = 3.14d;
            var salutev = "Hallo World V";
            Console.WriteLine("Teil Inferenz");
            Console.WriteLine(iv+" "+piv+" "+salutev);
}
        public static void Arrays()
     {            

           // int[] ia = new int[10];
            char[] ca = new char[30];
            double[] da = new double[12];

            /*         
                name: ia Typ: integer    10 Werte
                name: ca Typ: character  30 Werte
                name: da Typ: double     12 Werte
            */

        int[] ia = {1, 0, 2, 9, 3, 8, 4, 7, 5, 6};

        int ergebnis = ia[2] * ia[8] + ia[4];
        Console.WriteLine("Teil Arrays");
        Console.WriteLine(ergebnis);

        double[] importantnumbers = {3.14,  2.71, 2.97*(10^-19)};
        Console.WriteLine(importantnumbers[0]);
        Console.WriteLine(importantnumbers[1]);
        Console.WriteLine(importantnumbers[2]);
        Console.WriteLine(ia.Length);
        }     
   
   
   
   
    }
}
