using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Domain.Questions.Factories
{
    internal class QuestionTesti : QuestionFeature
    {
        public string Text { get; private set; }
        public string ImageUrl { get; private set; }
        public string VoiceUrl { get; private set; }
        public string FileUrl { get; private set; }
        public List<TestiOption> Options { get; private set; }
        public QuestionTesti(object questionObject)
        {
            if (questionObject is QuestionTesti question)
            {
                Text = question.Text;
                ImageUrl = question.ImageUrl;
                VoiceUrl = question.VoiceUrl;
                FileUrl = question.FileUrl;
                question.Options.ForEach(Option => new TestiOption(Option.Priority, Option.Text, Option.ImageUrl, Option.IsCorrect));
            }
            else
                throw new InvalidCastException("Unable to cast object to type 'QuizMaker.Domain.Questions.Factories.QuestionTesti'.");
        }
    }

    internal class TestiOption
    {
        public int Priority { get; private set; }
        public string Text { get; private set; }
        public string ImageUrl { get; private set; }
        public bool IsCorrect { get; private set; }
        public TestiOption(int priority, string text, string imageUrl, bool isCorrect)
        {
            Priority = priority;
            Text = text;
            ImageUrl = imageUrl;
            IsCorrect = isCorrect;
        }
    }
}
