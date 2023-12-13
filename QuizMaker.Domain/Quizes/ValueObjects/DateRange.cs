using QuizMaker.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Domain.Quizes.ValueObjects
{
    public class DateRange : Value<DateRange>
    {
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public DateRange(DateTime? startDate, DateTime? endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

    }
}
