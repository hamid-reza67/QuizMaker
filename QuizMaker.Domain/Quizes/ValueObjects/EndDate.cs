using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Domain.Quizes.ValueObjects
{
    public class EndDate
    {
        public DateTime? Value { get; private set; }
        public EndDate(DateTime? dateTime)
        {
            Value = dateTime;
        }
    }
}
