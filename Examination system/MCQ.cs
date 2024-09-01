using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class MCQ : QuestionBase
    {
        public override string Header { get; } = "MCQ Question";
        public MCQ(string _body = "", double _marks = 0) : base(_body, _marks)
        {
            AnswerList = new Answers[3];
        }
        public override string ToString()
        {
            return $"{Header}     Marks({Marks})\n {Body}\n" +
                   $"1.{AnswerList[0].AnswerText}\t\t 2.{AnswerList[1].AnswerText} \t\t {AnswerList[2].AnswerText}";
        }
        public static MCQ AddMCQQuestion()
        {
            bool flag;
            double res; 
            MCQ question = new MCQ();
            Console.WriteLine(question.Header);
            Console.WriteLine("Please Enter The Body Of Question:");
            question.Body = Console.ReadLine();
            do { 

                Console.WriteLine("Please Enter The Marks Of Question:");
                flag = double.TryParse(Console.ReadLine() , out res);
                question.Marks = res;
            }
            while (!flag);

            for (int i = 0; i < question.AnswerList?.Length; i++)
            {
                question.AnswerList[i] = new Answers();
                Console.WriteLine($"Please Enter The Choice Number {i + 1}");
                question.AnswerList[i].AnswerText = Console.ReadLine();
                question.AnswerList[i].AnswerId = i + 1;
            }
            question.RightAnswer = new Answers();
            string answer = "";
            do
            {
                Console.WriteLine($"Please Enter The Right Answer For the Question");
                answer = Console.ReadLine();
            } while (!(answer is string));
            question.RightAnswer.AnswerText = answer;
            return question;
        }
    }
}