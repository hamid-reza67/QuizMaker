using QuizMaker.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Domain.Quizes.ValueObjects
{
    public class AllowedNumberOfTimesToParticipate : Value<AllowedNumberOfTimesToParticipate>
    {
        public int? Value { get; private set; }
        public AllowedNumberOfTimesToParticipate(int? value)
        {
            if (value == 0)
                throw new ArgumentOutOfRangeException("Allowed number of times to participate cannot be 0");

            if (value > 10)
                throw new ArgumentOutOfRangeException("Allowed number of times to participate cannot be more than 10");

            Value = value;
        }
        public static implicit operator int?(AllowedNumberOfTimesToParticipate allowedNumberOfTimesToParticipate) => allowedNumberOfTimesToParticipate.Value;
    }
}
