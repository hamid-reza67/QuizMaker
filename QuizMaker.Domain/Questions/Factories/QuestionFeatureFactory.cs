using QuizMaker.Domain.Questions.Enumeration;
using QuizMaker.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Domain.Questions.Factories
{
    public abstract class QuestionFeatureFactory
    {
        protected abstract QuestionFeature MakeQuestion(object questionObject);
        public QuestionFeature CreateQuestion(object questionObject)
        {
            return MakeQuestion(questionObject);
        }
    }
}
