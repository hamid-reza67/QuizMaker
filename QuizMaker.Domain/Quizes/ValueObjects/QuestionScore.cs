using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Domain.Quizes.ValueObjects
{
    public class QuestionScore
    {
        public int? Score { get; private set; }
        public QuestionScore(int? score)
        {
            if (score is not null and <= 0)
                throw new ArgumentOutOfRangeException("Score cannot be less than 0");

            if (score is not null and >1000)
                throw new ArgumentOutOfRangeException("Score cannot be more than 1000");
            Score = score;
        }
    }
}
