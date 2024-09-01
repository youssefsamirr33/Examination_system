using Examination_system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public abstract class QuestionBase
    {
        private string body;
        private double marks;
        Answers[] answerList;
        private Answers rightAnswer;
        public abstract string Header { get; }  // abstract property for Header of Question

        public string Body
        {
            get { return body; }
            set { body = value; }
        }
        public double Marks
        {
            get { return marks; }
            set { marks = value; }
        }
        public Answers RightAnswer
        {
            get { return rightAnswer; }
            set { rightAnswer = value; }
        }
        public Answers[] AnswerList
        {
            get { return answerList; }
            set
            {
                answerList = value;
            }
        }

        public Answers this[int id]
        {
            get
            {
                if(answerList is not null)
                {
                    // search insied array by answer id
                    for (int i = 0; i < answerList.Length; i++)
                    {
                        if (answerList[i].AnswerId == id) return answerList[i];
                    }
                }
                return new Answers();
            }
        }
        public Answers this[string text]
        {
            get
            {
                if( answerList is not null)
                {
                    // search insied array by answer text
                    for (int i = 0; i < answerList.Length; i++)
                    {
                        if (answerList[i].AnswerText == text) return answerList[i];
                    }

                }
                return new Answers();
            }
        }

        // constructor
        public QuestionBase(string _body, double _marks)
        {
            body = _body;
            marks = _marks;
        }

        public static QuestionBase[] CreateBaseQuestions(int size)
        {
            QuestionBase[] questions = new QuestionBase[size];

            if(questions is not null)
            {
                for (int i = 0; i < questions.Length; i++)
                {
                    int questionType;
                    do
                    {
                        Console.WriteLine($"Please Choose The Type of the Question Number {i + 1} (1 for T/F Question, 2 for Choose one Quesion ) ");

                    } while (!int.TryParse(Console.ReadLine(), out questionType) || questionType < 1 || questionType > 2); // or !(questionType > 0 && questionType <3)

                    if (questionType == 1)  // validate T/F Question
                    {
                        Console.WriteLine($"The Data OF True or False Question Number {i + 1}");
                        questions[i] = TFQuestions.insertTFQuestion();
                    }
                    else if (questionType == 2)  // validate Choose one Quesion
                    {
                        Console.WriteLine($"The Data of Choose One Question Number {i + 1}");
                        questions[i] = ChooseOneQuestions.insertchoice();

                    }
     
                }

            }
            return questions;
        }



        public static QuestionBase[] CreateBaseQuestionsMCQ(int size)
        {
            QuestionBase[] questions = new QuestionBase[size];

            if (questions is not null)
            {
                for (int i = 0; i < questions.Length; i++)
                {
                    Console.WriteLine($"The Data of Choose One Question Number {i + 1}");
                    questions[i] = MCQ.AddMCQQuestion();

                }

            }
            return questions;
        }
    }
}
