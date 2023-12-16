using QuizMaker.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Domain.Shared.ValueObjects
{
    public class Score : Value<Score>
    {
        public int Value { get; private set; }
        public Score(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Score cannot be less than 0");

            if (value > 1000)
                throw new ArgumentOutOfRangeException("Score cannot be more than 1000");
            Value = value;
        }

        public static implicit operator int(Score passingMark) => passingMark.Value;
    }
}
