using System;

namespace Aufgabe06
{
    public class answerClass
    {


        public String Answertext;
        public Boolean RightOrWrong;

        public answerClass(String Answertext, Boolean RightOrWrong)
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
