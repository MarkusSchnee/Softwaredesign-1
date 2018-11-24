using System;
using System.Collections.Generic;

namespace Aufgabe06
{
    class Program
    {
        static int Highscore = 0;
        static int answeredQuestions = 0;
        static List<Quizelement> quizelements = new List<Quizelement>();
        static void Main(string[] args)
        {
            createQuizelements();
            MainMenue();
        }

        public static void createQuizelements()
        {
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

        }

        public static void MainMenue()
        {

        MainMenue:
            try
            {

                Console.Write("Deine Highscore ist:" + Highscore + "\n");
                Console.Write("beantwortete Fragen" + answeredQuestions + "\n");
                Console.Write("Bitte was auswählen:\n 1) neue Frage erstellen\n 2) Fragen beantworten\n 3) Beenden\n");
                int maincoice = int.Parse(Console.ReadLine());
                if (maincoice == 1)
                {
                    NewQuestion();
                    goto MainMenue;
                }
                else if (maincoice == 2)
                {
                    Random random = new Random();
                    int randomQuestion = random.Next(quizelements.Count);     
                    AnswerQuestion(quizelements[randomQuestion]);
                    goto MainMenue;
                }

                else if (maincoice == 3)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Falsche Eingabe. Zurück zum Hauptmenü!");
                    goto MainMenue;
                }

            }
            catch
            {
                Console.WriteLine("Falsche Eingabe. Zurück zum Hauptmenü!");
                goto MainMenue;
            }
        }

        public static void AnswerQuestion(Quizelement quizelement)
        {
            quizelement.ShowQuestion();
            Console.Write("\nBitte eine Antwort wählen ");
            int AnswerChoice = int.Parse(Console.ReadLine()) - 1;

            if (quizelement.answer[AnswerChoice].isRightOrWrong())
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
        }

        public static void NewQuestion()
        {
            Console.Write("Bitte neue Frage eingeben\n> ");
            String userQuestion = Console.ReadLine();

            Console.Write("Wieviele Antwortmöglichkeiten soll es geben? (Bitte eine Zahl 2-6)\n> ");
            int howManyAnswers = Int32.Parse(Console.ReadLine());
            answers[] userAnswer = new answers[howManyAnswers];

            Console.Write("Bitte die Richtige Antwort eingeben: \n> ");
            userAnswer[0] = new answers(Console.ReadLine(), true);

            for (int i = 1; i < howManyAnswers; i++)
            {
                Console.Write("Bitte Antwort eingeben\n> ");
                userAnswer[i] = new answers(Console.ReadLine(), false);
            }
            quizelements.Add(new Quizelement(userQuestion, userAnswer));

        }



    }
}
