﻿using Examination_system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public enum ExamType { practicalExam = 1, FinalExam = 2 }
    public abstract class Exam
    {
        private int time;
        private int numberOfQuestions;
        private double examGrade;
        QuestionBase[] questions;
        Answers[] answers;
        public abstract ExamType Type { get; set; }

        public int Time
        {
            get { return time; }
            set { time = value; }
        }
        public int NumberOfQuestions
        {
            get
            {
                return numberOfQuestions;
            }
            set { numberOfQuestions = value; }
        }

        public double ExamGrade
        { get { return examGrade; } set { examGrade = value; } }

        public QuestionBase[] Questions { get { return questions; } set { questions = value; } }

        public Answers[] Answers { get { return answers; } set { answers = value; } }


        // constructor
        public Exam(int _time, int _numberOfQuestions)
        {
            time = _time;
            numberOfQuestions = _numberOfQuestions;
            ExamGrade = 0;
            Questions = new QuestionBase[numberOfQuestions];
            answers = new Answers[numberOfQuestions];
        }
        public virtual void ShowExam()
        {
            if(questions is not null)
            {

                for (int i = 0; i < questions.Length; i++)
                {
                    answers[i] = new Answers();
                    Console.WriteLine(questions[i]);
                    Console.WriteLine("=================");
                    int id;
                    string answer = "";
                    if (questions[i].GetType().Name == "ChooseOneQuestions")
                    {
                        do
                        {
                            answer = Console.ReadLine();
                        } while (!(answer is string));
                        answers[i].AnswerText = answer;   // if user choose the text answer don't id [number of answer]
                    }
                    else
                    {
                        do
                        {

                        } while (!int.TryParse(Console.ReadLine(), out id));

                        answers[i].AnswerId = id;        // if user chooce the id [number of answer]

                        if (questions[i].AnswerList is not null)
                        {
                            for (int j = 0; j < questions[i].AnswerList.Length; j++)
                            {
                                if (questions[i].AnswerList[j].AnswerId == id)
                                    answers[i].AnswerText = questions[i].AnswerList[j].AnswerText;
                            }

                        }
                    }
                    Console.WriteLine("=====================================");

                }

            }
        }
    }
}
