using System;
using System.Collections.Generic;


namespace Aufgabe08
{
    class Program
    {
        static bool isGameRunning;
        static public int Points = 0;
        static public int attemptedQuestions = 0;
        static public List<Question> questionCatalogue = new List<Question>();


        static void Main(string[] args)
        {
            CreateDefaultQuestion();
            StartGame();
        }
        public static void StartGame()
        {
            isGameRunning = true;
            Console.WriteLine("Willkommen");
            do
            {
                Console.WriteLine("Punkte: " + Points);
                Console.WriteLine("Beantwortete Fragen: " + attemptedQuestions);
                Console.WriteLine("Welche Option:");
                Console.WriteLine("1) Frage eintragen");
                Console.WriteLine("2) Frage beantworten");
                Console.WriteLine("3) Beenden");

                string Option = Console.ReadLine();

                if (Option == "1")
                {
                    InsertQuestion();
                }
                else if (Option == "2")
                {
                    AskQuestion();

                }
                else if (Option == "3")
                {
                    Console.WriteLine("Bye");
                    break;
                }

            } while (isGameRunning);
        }


        public static void AskQuestion()
        {
            attemptedQuestions++;
            Random r = new Random();
            int randomQIndex = r.Next(questionCatalogue.Count);             // Markus: randomQuestionIndex, Question nicht abkürzen
            Question randomQuestionToAsk = questionCatalogue[randomQIndex];

            randomQuestionToAsk.Show();
            Console.WriteLine(randomQuestionToAsk.callToAction);
            string userAnswer = Console.ReadLine();
            if (randomQuestionToAsk.checkAnswer(userAnswer))
            {
                Points++;
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Falsch");
            }

        }
        public static void CreateDefaultQuestion()
        {
            questionCatalogue.Add(new EstimationQuestion("Wie viele Einkerbungen hat ein Golfball", 336));
            questionCatalogue.Add(new YesNoQ("Waren die Menschen auf dem Mond", true));
            questionCatalogue.Add(new MultipleAnswers("Was ist alles ein Säugetier?", new List<Answer>{
                new Answer("Wal", true),
                new Answer("Delphin", true),
                new Answer("Spinne", false),
                new Answer("Kuh", true),
            }));
            questionCatalogue.Add(new WritingQ("Wer ist ohne jeden Zweifel die allerwichtigste Person in Vault 101, der Eine, der uns von den grausamen Bedingungen der Atomwüste schützt, dem wir alles, sogar unser Leben, verdanken?", "Der Aufseher"));
            questionCatalogue.Add(new WritingQ("Was hat 4 Beine und kann nicht laufen?", "Tisch"));
            questionCatalogue.Add(new MultipleChoiceQ("Wie heißt das Tierwesen(aus Phantastische Tierwesen), welches verrückt nach allem ist was glänzt?", new List<Answer>{
                new Answer("Niffler", true),
                new Answer("Uli Hoeneß", false),
                new Answer("Donnervogel", false),
                new Answer("Phoenix", false)
            }));
        }
        public static void InsertQuestion()
        {
            Console.WriteLine("Bitte Frage eingeben!");
            string Questiontext = Console.ReadLine();
            Console.WriteLine("Um was für ein Fragentyp handelt es sich?");
            Console.WriteLine("1) Text eingeben");
            Console.WriteLine("2) Ja oder Nein Frage");
            Console.WriteLine("3) Schätzfrage");
            Console.WriteLine("4) Frage mit mehreren richigen Anwtorten");
            Console.WriteLine("5) Frage mit einer richtigen Anwtort");

            string Type = Console.ReadLine();

            switch (Type)
            {
                case "1":
                    Console.WriteLine("Bitte Richtige Antwort eingeben!");
                    String answertext = Console.ReadLine();
                    questionCatalogue.Add(new WritingQ(Questiontext, answertext));
                    break;
                case "2":
                    Console.WriteLine("Schreib y wenns richtig ist ein und n wenn nicht.");
                    string input = Console.ReadLine();
                    bool isCorrectYoN = false;
                    if (input == "y")
                    {
                        isCorrectYoN = true;
                    }
                    questionCatalogue.Add(new YesNoQ(Questiontext, isCorrectYoN));
                    break;
                case "3":
                    Console.WriteLine("Bitte die Richtige Zahl eingeben.");
                    int numberToGuess = Int32.Parse(Console.ReadLine());
                    questionCatalogue.Add(new EstimationQuestion(Questiontext, numberToGuess));
                    break;
                case "4":
                    Console.WriteLine("Wieviele Antworten soll es geben?");
                    int answerCount = Int32.Parse(Console.ReadLine());
                    List<Answer> newAnswer = new List<Answer>();
                    Answer userAnswer = new Answer();
                    bool isCorrect;
                    string text;
                    for (int i = 0; i < answerCount; i++)
                    {
                        Console.WriteLine("Bitte Anwort eingeben");
                        text = Console.ReadLine();
                        Console.WriteLine("Schreib y wenns richtig ist ein und n wenn nicht.");
                        if (Console.ReadLine() == "y")
                        {
                            isCorrect = true;
                        }
                        else
                        {
                            isCorrect = false;
                        }
                        newAnswer.Add(new Answer(text, isCorrect));
                    }
                    questionCatalogue.Add(new MultipleAnswers(Questiontext, newAnswer));
                    break;
                case "5":
                    Console.WriteLine("Wieviele Antworten soll es geben?");
                    int answerCountSingle = Int32.Parse(Console.ReadLine());
                    List<Answer> newAnswerS = new List<Answer>();
                    Console.WriteLine("Bitte Richtige Antwtort eingeben!");
                    newAnswerS.Add(new Answer(Console.ReadLine(), true));
                    for (int i = 0; i < answerCountSingle; i++)
                    {
                        Console.WriteLine("Bitte Anwort eingeben");
                        newAnswerS.Add(new Answer(Console.ReadLine(), false));
                    }
                    questionCatalogue.Add(new MultipleChoiceQ(Questiontext, newAnswerS));
                    break;
                default:
                    break;
            }
            
        }

    }




   

    
    class EstimationQuestion : Question
    {
        public EstimationQuestion(string Questiontext, int answertext)
        {
            this.Questiontext = Questiontext;
            this.answertext = answertext;
            this.callToAction = "Schätze die Richte Zahl";
        }

        public int answertext;
        public override void Show()
        {
            Console.WriteLine(Questiontext);
        }

        public override bool checkAnswer(string response)
        {
            int responseN = Int32.Parse(response);

            if (responseN > answertext - 50 && responseN < answertext + 50)
            {
                return true;
            }
            return false;
        }

    }
//Markus:
// Guter Code, leicht verständlich
// Klassennamen,Variablen und Methodennamen weise gewählt!
// Methode InsertQuestion etwas zu lang, splitten  
// sonst passt alles


}

