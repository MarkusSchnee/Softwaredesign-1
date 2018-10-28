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
            Strings();
            Verzweigungen();
            switch_case();
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
   
   public static void Strings()
   {
            //string meinString = "Dies ist ein String"; 
            //string a = "Dies ist ";
            //string b = "ein String";
            //string c = a + b; 
            Console.WriteLine("Teil Strings");          
            string a = "eins";
            string b = "zwei";
            string c = "eins";
            bool a_eq_b = (a == b);
            bool a_eq_c = (a == c);   
            string meinString = "Dies ist ein String";          
            char zeichen = meinString[5];            
            Console.WriteLine(meinString);
            Console.WriteLine(c);
            Console.WriteLine(a_eq_b);
            Console.WriteLine(a_eq_c);
            Console.WriteLine(zeichen);        
}
   public static void Verzweigungen()
   {
            Console.WriteLine("Teil Verzweigungen");           
            Console.WriteLine("Gib eine Zahl für A ein:");
            int A = int.Parse(Console.ReadLine());
            Console.WriteLine("Gib eine Zahl für B ein:");
            int B = int.Parse(Console.ReadLine());
            if (A > B){
                Console.WriteLine("a ist größer als b");
            }
            else{
                Console.WriteLine("b ist größer als a");
            }
            if (A > 3 && B == 6){
                Console.WriteLine("Du hast gewonnen");
            }
            else{
                Console.WriteLine("Leider verloren");
            }
}
   
        public static void switch_case()
        {
        Console.WriteLine("Tief im Wald kommst du auf eine Kreuzung. Es gibt zwei Wege. Aus dem Linken hörst du ein Sägen. Aus dem Rechten ein Schleifen.  ");
        Console.WriteLine("Welchen Weg nimmst du. Den Linken, den Rechten oder Zurück?");
        string richtung = Console.ReadLine();
        switch (richtung)
        {
            case "Linken":
                Console.WriteLine("Du wurdest von einem Baum erschlagen");
                break;
            case "Rechten":
                Console.WriteLine("Du wurdest von einer Axt erschlagen");
                break;
            case "Zurück":
                Console.WriteLine("DU hast dich verlaufen und wurdest von den Wölfen gefressen.");
                break;
            default:
                Console.WriteLine("Du konntest dich nicht entscheiden und bist verhungert.");
                break;
        } 
        //Es kommt ein fehler     !
        }

   
    }
}
