using System;

namespace Aufgabe06
{

    public class Quizelement
    {

        public string question;
        public answers[] answer;

        public Quizelement(String question, answers[] answer)
        {
            this.question = question;
            this.answer = answer;
        }


        public void ShowQuestion()
        {
            Console.Write("\n"+question+"\n");

            for (int i = 0; i < answer.Length; i++)
            {
                Console.WriteLine(answer[i].Answertext);
            }
        }





    }
}