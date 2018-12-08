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

            }while (isGameRunning);
        }

        public static void CreateDefaultQuestion()
        {
            questionCatalogue.Add(new MultipleAnswers("If you pick an answer to this question at random, what is the chance that you will be correct?", new List<AnswerClass>{
                new AnswerClass("Can't be answered because we don't know how many questions are correct", false),
                new AnswerClass("It's 50%, either it is correct or it is not", true),
                new AnswerClass("It's obviously 25%", false),
                new AnswerClass("It's 100% if I believe in myself", true),
            }));
            questionCatalogue.Add(new Single("Who is the worlds smartest programmer?", new List<AnswerClass>{
                new AnswerClass("Terry Davis", true),
                new AnswerClass("Linus Torwalds", false),
                new AnswerClass("James Gosling", false),
                new AnswerClass("Bjarne Stroustrup", false)
            }));
            questionCatalogue.Add(new EstimationQuestion("What is the square root of 676", 26));
            questionCatalogue.Add(new YesNoQ("Can 1 trillion lions win against the sun if they attack at night?", true));
            questionCatalogue.Add(new Free("Who is currently the best president of the united states?", "Donald Trump"));
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
        public static void InsertQuestion()
        {
            Console.WriteLine("Please insert your question");
            string userQuestion = Console.ReadLine();

            Console.Write("Type the number corresponding to the question type you want to add. \n" +
            "1: freetext question \n" +
            "2: yes/no question \n" +
            "3: guess question \n" +
            "4: multiple answer question \n" +
            "5: single answer question \n");
            string questionType = Console.ReadLine();

            switch (questionType)
            {
                case "1":
                    questionCatalogue.Add(AddFreeTextQuestion(userQuestion));
                    break;
                case "2":
                    questionCatalogue.Add(AddBinaryQuestion(userQuestion));
                    break;
                case "3":
                    questionCatalogue.Add(AddGuessQuestion(userQuestion));
                    break;
                case "4":
                    questionCatalogue.Add(AddMultiQuestion(userQuestion));
                    break;
                case "5":
                    questionCatalogue.Add(AddSingleQuestion(userQuestion));
                    break;
                default:
                    Console.WriteLine("Your input was not valid.");
                    break;
            }
            Console.WriteLine("Your question was successfully added.");
        }

        public static Question AddFreeTextQuestion(string Questiontext)
        {
            Console.WriteLine("Please insert the correct answer");
            return new Free(Questiontext, Console.ReadLine());
        }
        public static Question AddBinaryQuestion(string Questiontext)
        {
            Console.WriteLine("Type y if your question is correct and n if it is not");
            string input = Console.ReadLine();
            bool isCorrect = false;
            if (input == "y")
            {
                isCorrect = true;
            }
            return new YesNoQ(Questiontext, isCorrect);
        }
        public static Question AddGuessQuestion(string Questiontext)
        {
            Console.WriteLine("Please insert the correct number");
            int number = Int32.Parse(Console.ReadLine());
            return new EstimationQuestion(Questiontext, number);
        }
        public static Question AddMultiQuestion(string Questiontext)
        {
            Console.WriteLine("How many possible answers do you want?");
            int howManyAnswers = Int32.Parse(Console.ReadLine());
            List<AnswerClass> userAnswers = new List<AnswerClass>();
            AnswerClass userAnswer = new AnswerClass();
            bool isCorrect;
            string text;
            for (int i = 0; i < howManyAnswers; i++)
            {
                Console.WriteLine("Please insert an answer");
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
                userAnswers.Add(new AnswerClass(text, isCorrect));
            }
            return new MultipleAnswers(Questiontext, userAnswers);
        }
        public static Question AddSingleQuestion(string Questiontext)
        {
            Console.WriteLine("How many possible answers do you want?");
            int howManyAnswers = Int32.Parse(Console.ReadLine());
            List<AnswerClass> userAnswers = new List<AnswerClass>();

            Console.WriteLine("Please insert the correct answer");
            userAnswers.Add(new AnswerClass(Console.ReadLine(), true));

            for (int i = 0; i < howManyAnswers; i++)
            {
                Console.WriteLine("Please insert an answer");
                userAnswers.Add(new AnswerClass(Console.ReadLine(), false));
            }
            return new Single(Questiontext, userAnswers);
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
    class Single : Question
    {
        public Single(string Questiontext, List<AnswerClass> answers)
        {
            this.Questiontext = Questiontext;
            this.callToAction = "Type the number corresponding to the correct answer";
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
        public override bool checkAnswer(string input)
        {
            int inputNumber = Int32.Parse(input);
            for (int i = 0; i < answers.Count; i++)
            {
                if (answers[i].isCorrect && i == inputNumber)
                {
                    return true;
                }
            }
            return false;
        }

    }
    class Free : Question
    {
        public Free(string Questiontext, string answerWord)
        {
            this.Questiontext = Questiontext;
            this.answerWord = answerWord;
            this.callToAction = "Type the correct word!";
        }
        public string answerWord;
        public override void Show()
        {
            Console.WriteLine(Questiontext);
        }

        public override bool checkAnswer(string input)
        {
            if (input.ToUpper() == answerWord.ToUpper())
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

