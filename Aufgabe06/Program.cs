using System;

namespace Aufgabe06
{
    class Program
    {
        static void Main(string[] args)
        {
            int Highscore = 0;
            Main:            
            Console.Write("What do you want to do:\n 1) Create new Question\n 2)Answer Question\n 3)Quit\n");
            int maincoice = int.Parse(Console.ReadLine());
            if (maincoice == 1)
            {
                Console.Write("Upps not ready yet");
            }
            else if (maincoice == 2)
            {

                Quizelement quiz1 = new Quizelement();
                quiz1.question = "Wer war der erste Bundeskanzler";
                quiz1.answer = new string[] { "a) Brack Obama", "b) Helmut Kohl", "c) Konrad Adenauer", "d) Angelo Merkel" };
                quiz1.correct = 'c';
                quiz1.Show();
                char A = char.Parse(Console.ReadLine());

                if (quiz1.IsAnswerCorrect(A) == true)
                { Highscore = Highscore+1; }

                Console.Write("Your Score is:" + Highscore+"\n");
                goto Main;
            }

            else if (maincoice == 3)
            {
                Environment.Exit(0);
            }


        }
    }
}
