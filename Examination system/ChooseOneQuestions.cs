using Examination_system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class ChooseOneQuestions : QuestionBase
    {
        public override string Header { get; } = "Choose One Answer Question";

        // constructor 
        public ChooseOneQuestions(string _body = "", double _marks = 0) : base(_body, _marks) // Quetion Base chaning
        {
            AnswerList = new Answers[3]; // create new array of type Answer
        }
        public override string ToString()
        {
            return $"{Header}     Marks({Marks})\n {Body}\n" +
                   $"1.{AnswerList[0].AnswerText}\t\t 2.{AnswerList[1].AnswerText} \t\t {AnswerList[2].AnswerText}";
        }
        public static ChooseOneQuestions insertchoice()
        {
            bool flag;
            double mark;

            ChooseOneQuestions question = new ChooseOneQuestions();
            Console.WriteLine(question.Header);
            Console.WriteLine("Please Enter The Body of The Question: ");
            question.Body = Console.ReadLine();

            do
            {
                Console.Write("Please Enter The Marks of The Question : ");
                flag = double.TryParse(Console.ReadLine() , out mark);
                question.Marks = mark;

            } while(!flag);

            if(question.AnswerList is not null)
            {

                for (int i = 0; i < question.AnswerList.Length; i++)  // AnswerLsit.Lenght = 3
                {
                    question.AnswerList[i] = new Answers();
                    Console.WriteLine($"Please Enter The Choice Number {i + 1}");
                    question.AnswerList[i].AnswerText = Console.ReadLine();
                    question.AnswerList[i].AnswerId = i + 1; // id = 1 , 2 , 3
                }

            }
            question.RightAnswer = new Answers();
            int id;
            do
            {
                Console.WriteLine($"Please Enter The Right Answer for Quesion [1,2 Or 3]");
            } while (!int.TryParse(Console.ReadLine(), out id) || id < 1 || id > 3);
            question.RightAnswer.AnswerId = id;
            question.RightAnswer.AnswerText = question.AnswerList[id - 1].AnswerText;  // as index 0 or 1 or 2 as zero indexing
            return question;
        }

    }
}
