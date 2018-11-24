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
            CreateQuizElements();
            MainMenu();
        }

        public static void MainMenu()
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
                    MainMenu();
                }
                else if (maincoice == 2)
                {
                    Random random = new Random();
                    int randomQuestion = random.Next(quizElementList.Count);
                    AnswerQuestion(quizElementList[randomQuestion]);
                    MainMenu();
                }

                else if (maincoice == 3)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Falsche Eingabe. Zurück zum Hauptmenü!");
                    MainMenu();
                }

            }
            catch
            {
                Console.WriteLine("Falsche Eingabe. Zurück zum Hauptmenü!");
                MainMenu();
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

        public static void CreateQuizElements()
        {
            quizElementList.Add(new Quizelement("Wer war der erste Bundeskanzler",
                new answerClass[]{
                new answerClass("1) Angela Merkel", false),
                new answerClass("2) Brack Obama", false),
                new answerClass("3) Helmut Kohl", false),
                new answerClass("4) Konrad Adenauer", true)
            }));

            quizElementList.Add(new Quizelement("Wer ist ohne jeden Zweifel die allerwichtigste Person in Vault 101, der Eine, der uns von den grausamen Bedingungen der Atomwüste schützt, dem wir alles, sogar unser Leben, verdanken?",
                new answerClass[]{
                new answerClass("1) Der Aufseher", true),
                new answerClass("2) Der Aufseher", true),
                new answerClass("3) Der Aufseher", true),
                new answerClass("4) Der Aufseher", true)
             }));

            quizElementList.Add(new Quizelement("Wie heißt das Tierwesen(aus Phantastische Tierwesen), welches verrückt nach allem ist was glänzt?",
                new answerClass[]{
                new answerClass("1) Uli Hoeneß", false),
                new answerClass("2) Niffler", true),
                new answerClass("3) Donnervogel", false)
            }));

            quizElementList.Add(new Quizelement("Wo geht man durch ein Loch und durch zwei wieder raus?",
                new answerClass[]{
                new answerClass("1) Hose", true),
                new answerClass("2) T-Shirt", false),
           }));

            quizElementList.Add(new Quizelement("Aus welchem Material ist der Sarg von Schneewittchen?",
                new answerClass[]{
                new answerClass("1) Stein", false),
                new answerClass("2) Diamant", false),
                new answerClass("3) Glas", true),
                new answerClass("4) Pappe", false),
            }));
            quizElementList.Add(new Quizelement("Messer Gabel Schere Licht sind für",
            new answerClass[]{
                new answerClass("1) kurze Zeit wasserdicht", false),
                new answerClass("2) ältere Elfen nicht", false),
                new answerClass("3) lange Reisen Pflicht", false),
                new answerClass("4) kleine Kinder nicht", true)
            }));

        }
    }
}
