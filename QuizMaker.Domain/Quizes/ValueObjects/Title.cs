using QuizMaker.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Domain.Quizes.ValueObjects
{
    public class Title : Value<Title>
    {
        public string Value { get; private set; }
        public Title(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("Title cannot be empty");

            if (value.Length > 200)
                throw new ArgumentOutOfRangeException("Title cannot be longer that 200 characters");

            Value = value;
        }

        public static implicit operator string(Title title) => title.Value;
    }
}
