using System;
using System.Collections.Generic;

namespace Aufgabe06
{
    class Program
    {
        static int Highscore = 0;
        static int answeredQuestions = 0;
        static void Main(string[] args)
        {
            List<Quizelement> quizelements = new List<Quizelement>();

            quizelements.Add(new Quizelement("Wer war der erste Bundeskanzler", new answers[]
            {
                new answers("Angela Merkel", false),
                new answers("Brack Obama", false),
                new answers("Helmut Kohl", false),
                new answers("Konrad Adenauer", true)
            }));

            quizelements.Add(new Quizelement("Wer ist ohne jeden Zweifel die allerwichtigste Person in Vault 101, der Eine, der uns von den grausamen Bedingungen der Atomwüste schützt, dem wir alles, sogar unser Leben, verdanken?", new answers[]
            {
                new answers("Der Aufseher", true),
                new answers("Der Aufseher", true),
                new answers("Der Aufseher", true),
                new answers("Der Aufseher", true)
            }));


        MainMenue:
            Console.Write("Deine Highscore ist:" + Highscore + "\n");
            Console.Write("beantwortete Fragen" + answeredQuestions + "\n");
            Console.Write("Bitte was auswählen:\n 1) neue Frage erstellen\n 2) Fragen beantworten\n 3) Beenden\n");
            int maincoice = int.Parse(Console.ReadLine());
            if (maincoice == 1)
            {
                Console.Write("Upps not ready yet");
            }
            else if (maincoice == 2)
            {
                Random random = new Random();
                int randomQuestion = random.Next(0, 2);
                quizelements[randomQuestion].ShowQuestion();
                Console.Write("\nBitte eine Antwort wählen ");
                int AnswerChoice = int.Parse(Console.ReadLine()) - 1;

                if (quizelements[randomQuestion].answer[AnswerChoice].isRightOrWrong())
                {
                    Highscore += 1;
                    Console.Write("\nRichtig");
                }
                else
                {
                    Console.Write("\nFalsch");
                }

                answeredQuestions += 1;
                Console.Write("Deine Highscore ist:" + Highscore + "\n");
                goto MainMenue;

            }

            else if (maincoice == 3)
            {
                Environment.Exit(0);
            }


        }


    }
}
