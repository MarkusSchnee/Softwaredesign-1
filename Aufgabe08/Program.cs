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
            int randomQIndex = r.Next(questionCatalogue.Count);
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
            questionCatalogue.Add(new MultipleAnswers("Was ist alles ein Säugetier?", new List<AnswerClass>{
                new AnswerClass("Wal", true),
                new AnswerClass("Delphin", true),
                new AnswerClass("Spinne", false),
                new AnswerClass("Kuh", true),
            }));
            questionCatalogue.Add(new WritingQ("Wer ist ohne jeden Zweifel die allerwichtigste Person in Vault 101, der Eine, der uns von den grausamen Bedingungen der Atomwüste schützt, dem wir alles, sogar unser Leben, verdanken?", "Der Aufseher"));
            questionCatalogue.Add(new WritingQ("Was hat 4 Beine und kann nicht laufen?", "Tisch"));
            questionCatalogue.Add(new MultipleChoiceQ("Wie heißt das Tierwesen(aus Phantastische Tierwesen), welches verrückt nach allem ist was glänzt?", new List<AnswerClass>{
                new AnswerClass("Niffler", true),
                new AnswerClass("Uli Hoeneß", false),
                new AnswerClass("Donnervogel", false),
                new AnswerClass("Phoenix", false)
            }));
        }
        public static void InsertQuestion()
        {
            Console.WriteLine("Bitte Frage eingeben!");
            string Questiontext = Console.ReadLine();

            Console.Write("Um was für ein Fragentyp handelt es sich?. \n" +
            "1: Text eingeben \n" +
            "2: Ja oder Nein Frage \n" +
            "3: Schätzfrage \n" +
            "4: Frage mit mehreren richigen Anwtorten \n" +
            "5: Frage mit einer richtigen Anwtort \n");
            string Type = Console.ReadLine();

            switch (Type)
            {
                case "1":
                    Console.WriteLine("Bitte Richtige Antwort eingeben!");
                    String answertext = Console.ReadLine();
                    questionCatalogue.Add(new WritingQ(Questiontext, answertext));
                    break;
                case "2":
                    Console.WriteLine("Hieb y wenns richtig ist ein und n wenn nicht.");
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
                    List<AnswerClass> newAnswer = new List<AnswerClass>();
                    AnswerClass userAnswer = new AnswerClass();
                    bool isCorrect;
                    string text;
                    for (int i = 0; i < answerCount; i++)
                    {
                        Console.WriteLine("Bitte Anwort eingeben");
                        text = Console.ReadLine();
                        Console.WriteLine("Type y if that answer is correct and n if it is not");
                        if (Console.ReadLine() == "y")
                        {
                            isCorrect = true;
                        }
                        else
                        {
                            isCorrect = false;
                        }
                        newAnswer.Add(new AnswerClass(text, isCorrect));
                    }
                    questionCatalogue.Add(new MultipleAnswers(Questiontext, newAnswer));
                    break;
                case "5":
                    Console.WriteLine("Wieviele Antworten soll es geben?");
                    int answerCountSingle = Int32.Parse(Console.ReadLine());
                    List<AnswerClass> newAnswerS = new List<AnswerClass>();
                    Console.WriteLine("Bitte Richtige Antwtort eingeben!");
                    newAnswerS.Add(new AnswerClass(Console.ReadLine(), true));
                    for (int i = 0; i < answerCountSingle; i++)
                    {
                        Console.WriteLine("Bitte Anwort eingeben");
                        newAnswerS.Add(new AnswerClass(Console.ReadLine(), false));
                    }
                    questionCatalogue.Add(new MultipleChoiceQ(Questiontext, newAnswerS));
                    break;
                default:
                    break;
            }
            Console.WriteLine("Quizfrage erfolgreich hinzugefügt");
        }

    }



    abstract class Question
    {
        public string Questiontext;
        public string callToAction;

        public abstract void Show();

        public abstract bool checkAnswer(string input);

    }
    class MultipleAnswers : Question
    {
        public MultipleAnswers(string Questiontext, List<AnswerClass> answers)
        {
            this.Questiontext = Questiontext;
            this.answers = answers;
            this.callToAction = "Bitte die Zahlen der eingeben. Mit Leerzeichen!(z.B.:2 3) ";
        }
        List<AnswerClass> answers;
        public override void Show()
        {
            Console.WriteLine(Questiontext);

            for (int i = 0; i < answers.Count; i++)
            {
                Console.WriteLine(i + ": " + answers[i].text);
            }
        }

        public override bool checkAnswer(string response)
        {
            string[] splittedInput = response.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            bool[] inputForEveryAnswer = new bool[answers.Count];

            for (int i = 0; i < answers.Count; i++)
            {
                inputForEveryAnswer[i] = false;
                for (int j = 0; j < splittedInput.Length; j++)
                {
                    if (splittedInput[j] == i.ToString())
                    {
                        inputForEveryAnswer[i] = true;
                    }
                }
                if (inputForEveryAnswer[i] != answers[i].isCorrect)
                {
                    return false;
                }
            }
            return true;
        }
    }


    class YesNoQ : Question
    {
        public YesNoQ(string Questiontext, bool isCorrect)
        {
            this.Questiontext = Questiontext;
            this.isCorrect = isCorrect;
            this.callToAction = "Bitte y oder n eingeben";
        }
        public bool isCorrect;

        public override void Show()
        {
            Console.WriteLine(Questiontext);
        }

        public override bool checkAnswer(string response)
        {
            bool yorn = false;
            if (response == "y")
            {
                yorn = true;
            }

            if (isCorrect == yorn)
            {
                return true;
            }
            return false;
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
    class MultipleChoiceQ : Question
    {
        public MultipleChoiceQ(string Questiontext, List<AnswerClass> answers)
        {
            this.Questiontext = Questiontext;
            this.callToAction = "Bitte die Nummer für die Antwort eingeben";
            this.answers = answers;
        }
        public List<AnswerClass> answers;
        public override void Show()
        {
            Console.WriteLine(Questiontext);

            for (int i = 0; i < answers.Count; i++)
            {
                Console.WriteLine(i + ": " + answers[i].text);
            }
        }
        public override bool checkAnswer(string response)
        {
            int responseN = Int32.Parse(response);
            for (int i = 0; i < answers.Count; i++)
            {
                if (answers[i].isCorrect && i == responseN)
                {
                    return true;
                }
            }
            return false;
        }

    }
    class WritingQ : Question
    {
        public WritingQ(string Questiontext, string WordToWrite)
        {
            this.Questiontext = Questiontext;
            this.WordToWrite = WordToWrite;
            this.callToAction = "Bitte das Richtige Wort eingeben!";
        }
        public string WordToWrite;
        public override void Show()
        {
            Console.WriteLine(Questiontext);
        }

        public override bool checkAnswer(string response)
        {
            if (response.ToUpper() == WordToWrite.ToUpper())
            {
                return true;
            }
            return false;
        }
    }
    public class AnswerClass
    {
        public AnswerClass() { }
        public AnswerClass(string text, bool isCorrect)
        {
            this.text = text;
            this.isCorrect = isCorrect;
        }

        public string text;
        public bool isCorrect;
    }


}

