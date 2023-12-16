using QuizMaker.Domain.Questions.Enumeration;
using QuizMaker.Domain.Questions.Factories;
using QuizMaker.Domain.Quizes;
using QuizMaker.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Domain.Questions
{
    public class Question
    {
        public Guid Id { get; }
        public Guid QuizId { get; }
        public HardshipLevel HardshipLevel { get; private set; }
        public Score Score { get; private set; }
        public TextEditor ParticipateTips { get; private set; }
        public TextEditor ResultTips { get; private set; }
        public QuestionType QuestionType { get; private set; }
        public QuestionFeature QuestionFeature { get; private set; }
        public Question(Guid quizId,
            HardshipLevel hardshipLevel,
            Score score,
            TextEditor participateTips,
            TextEditor resultTips,
            QuestionType questionType,
            object questionFeature
            )
        {
            Id = Guid.NewGuid();
            QuizId = quizId;
            HardshipLevel = hardshipLevel;
            Score = score;
            ParticipateTips = participateTips;
            ResultTips = resultTips;
            QuestionType = questionType;
            QuestionFeature = questionType switch
            {
                QuestionType.Tashrihi => new QuestionTashrihiFactory().CreateQuestion(questionFeature),
                QuestionType.Testi => new QuestionTestiFactory().CreateQuestion(questionFeature),
                _ => throw new Exception("Question type is not valid")
            };
        }


        public void Update(HardshipLevel hardshipLevel,
            Score score,
            TextEditor participateTips,
            TextEditor resultTips,
            QuestionType questionType,
            object questionFeature)
        {
            HardshipLevel= hardshipLevel;
            Score= score;
            ParticipateTips= participateTips;
            ResultTips= resultTips;
            QuestionType = questionType;
        }


    }
}
