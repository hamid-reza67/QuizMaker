using QuizMaker.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Domain.Shared.ValueObjects
{
    public class TextEditor : Value<TextEditor>
    {
        public string? Text { get; private set; }
        public TextEditor(string? text)
        {
            if (text?.Length > 4000)
                throw new ArgumentOutOfRangeException("Text cannot be longer that 4000 characters.");
            Text = text;
        }

        public static implicit operator string?(TextEditor textEditor) => textEditor.Text;
    }
}
