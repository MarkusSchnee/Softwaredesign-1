using System;

namespace Aufgabe06
{
    class Program
    {
        static void Main(string[] args)
        {
            Quizelement quiz1 = new Quizelement();
            quiz1.question = "Wer war der erste Bundeskanzler";
            quiz1.answer = new string[] { "a) Brack Obama", "b) Helmut Kohl", "c) Konrad Adenauer", "d) Angelo Merkel" };
            quiz1.correct = 'c';
            quiz1.Show();
            char A = char.Parse(Console.ReadLine());
           
            Console.Write(quiz1.IsAnswerCorrect(A));



        }
    }
}
