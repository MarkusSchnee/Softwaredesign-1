using System;
using System.Collections.Generic;

namespace Aufgabe06
{
    class Program
    {
        static int Highscore = 0;
        static int answeredQuestions = 0;
        static List<Quizelement> quizElementList = new List<Quizelement>();
        static void Main(string[] args)
        {
            createQuizelements();
            MainMenue();
        }

        public static void createQuizelements()
        {
            quizElementList.Add(new Quizelement("Wer war der erste Bundeskanzler", new answerClass[]
                        {
                new answerClass("Angela Merkel", false),
                new answerClass("Brack Obama", false),
                new answerClass("Helmut Kohl", false),
                new answerClass("Konrad Adenauer", true)
                        }));

            quizElementList.Add(new Quizelement("Wer ist ohne jeden Zweifel die allerwichtigste Person in Vault 101, der Eine, der uns von den grausamen Bedingungen der Atomwüste schützt, dem wir alles, sogar unser Leben, verdanken?", new answerClass[]
            {
                new answerClass("Der Aufseher", true),
                new answerClass("Der Aufseher", true),
                new answerClass("Der Aufseher", true),
                new answerClass("Der Aufseher", true)
            }));

            quizElementList.Add(new Quizelement("Wie heißt das Tierwesen(aus Phantastische Tierwesen), welches verrückt nach allem ist was glänzt?", new answerClass[]
            {
                new answerClass("Uli Hoeneß", false),
                new answerClass("Niffler", true),
                new answerClass("Donnervogel", false)
            }));

            quizElementList.Add(new Quizelement("Wo geht man durch ein Loch und durch zwei wieder raus?", new answerClass[]
           {
                new answerClass("Hose", true),
                new answerClass("T-Shirt", false),
           }));

            quizElementList.Add(new Quizelement("Aus welchem Material ist der Sarg von Schneewittchen?", new answerClass[]
            {
                new answerClass("Stein", false),
                new answerClass("Diamant", false),
                new answerClass("Glas", true),
                new answerClass("Pappe", false),
            }));
            quizElementList.Add(new Quizelement("Messer Gabel Schere Licht sind für", new answerClass[]
            {
                new answerClass("kurze Zeit wasserdicht", false),
                new answerClass("ältere Elfen nicht", false),
                new answerClass("lange Reisen Pflicht", false),
                new answerClass("kleine Kinder nicht", true)
            }));

        }

        public static void MainMenue()
        {
            try
            {

                Console.Write("Deine Highscore ist: " + Highscore + "\n");
                Console.Write("beantwortete Fragen: " + answeredQuestions + "\n");
                Console.Write("Bitte was auswählen:\n 1) neue Frage erstellen\n 2) Fragen beantworten\n 3) Beenden\n");
                int maincoice = int.Parse(Console.ReadLine());
                if (maincoice == 1)
                {
                    NewQuestion();
                    MainMenue();
                }
                else if (maincoice == 2)
                {
                    Random random = new Random();
                    int randomQuestion = random.Next(quizElementList.Count);
                    AnswerQuestion(quizElementList[randomQuestion]);
                    MainMenue();
                }

                else if (maincoice == 3)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Falsche Eingabe. Zurück zum Hauptmenü!");
                    MainMenue();
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
            quizelement.Show();
            Console.Write("\nBitte eine Antwort wählen ");
            int AnswerChoice = int.Parse(Console.ReadLine()) - 1;

            if (quizelement.answer[AnswerChoice].isRightOrWrong())
            {
                Highscore += 1;
                Console.Write("\nRichtig\n");
            }
            else
            {
                Console.Write("\nFalsch\n");
            }
            answeredQuestions += 1;
        }

        public static void NewQuestion()
        {
            Console.Write("Bitte neue Frage eingeben\n> ");
            String userQuestion = Console.ReadLine();

            Console.Write("Wieviele Antwortmöglichkeiten soll es geben? (Bitte eine Zahl 2-6)\n> ");
            int howManyAnswers = Int32.Parse(Console.ReadLine());
            answerClass[] userAnswer = new answerClass[howManyAnswers];

            Console.Write("Bitte die Richtige Antwort eingeben: \n> ");
            userAnswer[0] = new answerClass(Console.ReadLine(), true);

            for (int i = 1; i < howManyAnswers; i++)
            {
                Console.Write("Bitte Antwort eingeben\n> ");
                userAnswer[i] = new answerClass(Console.ReadLine(), false);
            }
            quizElementList.Add(new Quizelement(userQuestion, userAnswer));
        }
    }
}
