using System;

namespace Aufgabe06
{

    public class Quizelement
    {
        //Was ist ein Assambly

        public string question;
        public string [] answer;
        public char correct;

        
        public Boolean IsAnswerCorrect(char choise){
        
            return (choise == this.correct);
    
        }

        void Show(){
            Console.WriteLine(question);
            Console.WriteLine(answer);
        }
    }
}