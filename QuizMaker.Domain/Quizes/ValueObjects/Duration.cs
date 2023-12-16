using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Domain.Quizes.ValueObjects
{
    public class Duration
    {
        public int? Value { get; private set; }
        public static Duration FromString(string stringTime)
        {
            if (stringTime.Length > 5)
                throw new ArgumentOutOfRangeException("Duration cannot be more than 5 character");

            if (!stringTime.Contains(':'))
                throw new ArgumentException("Duration should has a : character");

            var hour = byte.Parse(stringTime.Split(':')[0]);
            var minute = byte.Parse(stringTime.Split(':')[1]);
            var time = hour * 60 + minute;

            CheckValidity(time);
            return new Duration(time);
        }
        public static Duration FromInt(int? time)
        {
            CheckValidity(time);
            return new Duration(time);
        }
        internal Duration(int? value) => Value = value;

        public static implicit operator int?(Duration time) => time.Value;
        private static void CheckValidity(int? time)
        {
            if (time.HasValue && time <= 0)
                throw new ArgumentOutOfRangeException("Duration cannot be 0 and less than 0");

            if (time.HasValue && time > 5 * 60 * 60)
                throw new ArgumentOutOfRangeException("Duration cannot be more than 5 houres");
        }
    }
}
