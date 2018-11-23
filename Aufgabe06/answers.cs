using System;

namespace Aufgabe06
{
    public class answers
    {


        public String Answertext;
        public Boolean RightOrWrong;

        public answers(String Answertext, Boolean RightOrWrong)
        {
            this.Answertext = Answertext;
            this.RightOrWrong = RightOrWrong;
        }

        public Boolean isRightOrWrong()
        {
            return RightOrWrong;
        }
    }
}
