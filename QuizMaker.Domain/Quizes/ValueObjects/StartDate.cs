using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Domain.Quizes.ValueObjects
{
    public class StartDate
    {
        public DateTime? Value { get; private set; }
        public StartDate(DateTime? dateTime)
        {
            //if (dateTime<DateTime.Now)
            //    throw new ArgumentOutOfRangeException(nameof(dateTime));
            Value = dateTime;
        }
    }
}
