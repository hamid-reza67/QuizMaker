using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Domain.Questions.Factories
{
    public class QuestionTestiFactory : QuestionFeatureFactory
    {
        protected override QuestionFeature MakeQuestion()
        {
            QuestionFeature question= new QuestionTesti();
            return question;
        }
    }
}
