using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class TFQuestions : QuestionBase
    {
        public override string Header { get; } = "True Or False Question";

        // constructor 
        public TFQuestions(string _body = "", double _marks = 0) : base(_body, _marks)  // chaning 
        {
            AnswerList = new Answers[2];
            AnswerList[0] = new Answers("True", 1);
            AnswerList[1] = new Answers("False", 2);
        }

        // just for display when show exam
        public override string ToString()
        {
            return $"{Header}     Marks({Marks})\n {Body}\n" +
                   $"1.{AnswerList[0].AnswerText}\t\t 2.{AnswerList[1].AnswerText}";
        }
        public static TFQuestions insertTFQuestion()
        {
            bool flag;
            double res;

            TFQuestions question = new TFQuestions();
            Console.WriteLine(question.Header);
            Console.WriteLine("Please Enter The Body of Question: ");
            question.Body = Console.ReadLine();

            do
            {
                Console.Write("Please Enter The Marks of Question: ");
                flag = double.TryParse(Console.ReadLine(), out res);
                question.Marks = res;

            } while (!flag);

             
            question.RightAnswer = new Answers();  // create new array of type Answer
            int id;
            do
            {
                Console.WriteLine($"Please Enter The Right Answer For the Question [1 for True, 2 for False]");
            } while (!int.TryParse(Console.ReadLine(), out id) || id < 1 || id > 2);
            question.RightAnswer.AnswerId = id;
            question.RightAnswer.AnswerText = question[id].AnswerText;

            return question;
        }
    }
}
