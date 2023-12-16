using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Domain.Quizes.ValueObjects
{
    public class QuestionCount
    {
        public int? Value { get; private set; }
        public QuestionCount(int? value)
        {
            if (value > 1000)
                throw new ArgumentOutOfRangeException("Question count cannot be more than 1000");
            Value = value;
        }
        public static implicit operator int?(QuestionCount questionCount) => questionCount.Value; 
    }
}
