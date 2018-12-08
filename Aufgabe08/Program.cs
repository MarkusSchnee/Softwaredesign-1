using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Aufgabe08
{
    class Program
    {
        static int points = 0, attemptedQuestions = 0;
        static bool isQuizGameRunning;
        static List<Question> questionCatalogue;
        // IOClass inputoutput;
        static void Main(string[] args)
        {

            createDefaultQuestions();
            startGame();
        }

        static void createDefaultQuestions()
        {

        }


        static void startGame()
        {
            isQuizGameRunning = true;
            Console.WriteLine("Willkommen");

            do
            {
                Console.WriteLine();
                Console.Write("Momentaner Punktestand: " + points + " " + "Versuchte Fragen: " + attemptedQuestions);
                if (attemptedQuestions != 0)
                    Console.Write("(" + ((float)points / (float)attemptedQuestions) * 100 + "%)");
                Console.WriteLine();
                Console.WriteLine("Wollen sie: ");
                Console.WriteLine("Eine Frage beantworten (1)");
                Console.WriteLine("Eine Frage eintragen (2)");
                Console.WriteLine("Das Quiz beenden (3)");


                int decision = Int32.Parse(Console.ReadLine());

                switch (decision)
                {
                    case 1:
                        askQuestion();
                        break;
                    case 2:
                        insertQuestion();
                        break;
                    case 3:
                        isQuizGameRunning = false;
                        Console.WriteLine("Thanks for playing.");
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Unbekannte Antwort, bitte wiederholen");
                        break;
                }
            } while (isQuizGameRunning);

        }


        public static void askQuestion()
        {
            attemptedQuestions++;
            Random r = new Random();
            int randomQIntdex = r.Next(questionCatalogue.Count);
            Question randomQuestiontoAsk = questionCatalogue[randomQIntdex]();
            Question.showQuestion;

            if (randomQuestiontoAsk.Questiontype == MultipleChoiceQ || randomQuestiontoAsk.Questiontype == MultipleAnswersQ)
            {
                int i = 0;
                while (i < Answerlist.Count)
                {
                    Answer answer = Answer[i];
                    Console.WriteLine(answer.Answertext);
                    i++;
                }

                while (i > Answerlist.Count)
                {
                    var response = Console.ReadLine;
                    if (randomQuestiontoAsk.checkAnswer(response))
                    {
                        addPoints();
                        Console.WriteLine("Correct");
                    }
                    else
                    {
                        Console.WriteLine("falsch");
                    }
                    break;
                }

            }
            else if (randomQuestiontoAsk.Questiontype == YN || randomQuestiontoAsk.Questiontype == EstimationQuestion || randomQuestiontoAsk.Questiontype == WrtingQ)
            {
                var Useranswer = Console.ReadLine();
                if (randomQuestiontoAsk.checkAnswer(Useranswer))
                {
                    addPoints();
                    Console.WriteLine("Correct");
                }
                else
                {
                    Console.WriteLine("falsch");
                }
            }

        }


        public static void addPoints()
        {
            points = +1;

        }
        public static void insertQuestion()
        {


        }


    }



    public class Question
    {
        public string Questiontext;
        public Enum Questiontype;
        //IOClass inputoutput;


        public Question(string Questiontext, Enum Questiontype)
        {
            this.QuestionText = QuestionText;
            this.Questiontype = Questiontype;
        }

        public bool checkAnswer()
        {
            return true;
        }
        public void showQuestion()
        {
            Console.WriteLine("Frage: " + QuestionText);
        }
    }
    public class MultipleChoiceQ : Question
    {

        static List<Answer> Answers;

        public MultipleChoiceQ()
        {
            Answers = new List<Answer>();
        }
        public bool checkAnswer(int response)
        {
            bool result;
            if (Answers[response].isCorrect)
                result = true;

            else
                result = false;
            return result;
        }
    }


    public class YesNoQ : Question
    {
        public bool YesOrNo;

        public YesNoQ(bool YesNoQ)
        {
            this.YesOrNo = YesOrNo;
        }
        public bool checkAnswer(string response)
        {
            bool result;
            bool yorn;

            if (response == "n")
            { yorn = false; }

            else if (response == "y")
            { yorn = true; }

            if (isCorrect != yorn)
            { result = false; }
            else if (isCorrect == yorn)
            { result = true; }

            return result;
        }
    }
    public class EstimationQuestion : Question
    {
        public int valueToEstimate;


        public EstimationQuestion(int valueToEstimate)
        {
            this.valueToEstimate = valueToEstimate;
        }
        public bool checkAnswer(int response)
        {
            bool result;
            int.TryParse(Answertext);
            return true;

            if (response < Answertext - 50 && response > Answertext + 50)
            { result = false; }
            else if (response > Answertext - 50 && response < Answertext + 50)
            { result = true; }
            return result;

        }
    }
    public class MultipleAnswersQ : Question
    {
        static List<Answer> Answers;

        public MultipleAnswersQ()
        {
            Answers = new List<Answer>();
        }
        public bool checkAnswer(int response)
        {
            bool result;
            if (Answers[response].isCorrect)
                result = true;

            else
                result = false;
            return result;
        }
    }
    public class WrtingQ : Question
    {
        public String WordToWrite;
        public WrtingQ(String WordToWrite)
        {
            this.WordToWrite = WordToWrite;
        }

        public bool checkAnswer(string response)
        {
            bool result;
            if (response != Answertext)
                result = false;

            else if (response = Answertext)
                result = true;

            return result;
        }
    }
    public class Answer
    {
        public string Answertext;
        public Answer(String Answertext)
        {
            this.Answertext = Answertext;
        }
        public bool isCorrect()
        {
            return true;
        }
    }


}

