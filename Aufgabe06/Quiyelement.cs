using System;

namespace Aufgabe06
{

    public class Quizelement
    {
        //Was ist ein Assambly

        public string question;
        public string[] answer;
        public char correct;


        public Boolean IsAnswerCorrect(char choise)
        {
            if (choise == this.correct)
            {
                Console.WriteLine("yeah:)");
            }
            else
                Console.WriteLine("buuuuuh");


            return (choise == this.correct);

        }

        public void Show()
        {
            Console.WriteLine(question);
            foreach (var item in answer)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}