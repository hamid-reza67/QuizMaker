using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Domain.Questions.Factories
{
    public class QuestionTashrihiFactory : QuestionFeatureFactory
    {
        protected override QuestionFeature MakeQuestion(object questionObject)
        {
            QuestionFeature question = new QuestionTashrihi(questionObject);
            return question;
        }
    }
}
