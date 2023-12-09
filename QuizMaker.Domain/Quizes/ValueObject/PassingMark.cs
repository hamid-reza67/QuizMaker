using QuizMaker.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Domain.Quizes.ValueObject
{
    public class PassingMark : Value<PassingMark>
    {
        public int? Value { get; private set; }
        public PassingMark(int? value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Passing mark cannot be less than 0");

            if (value > 1000)
                throw new ArgumentOutOfRangeException("Passing mark cannot be more than 1000");
            Value = value;
        }

        public static implicit operator int?(PassingMark passingMark) =>passingMark.Value;
    }
}
