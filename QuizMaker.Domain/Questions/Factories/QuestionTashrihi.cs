using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker.Domain.Questions.Factories
{
    internal class QuestionTashrihi : QuestionFeature
    {
        public string Text { get; private set; }
        public string ImageUrl { get; private set; }
        public string VoiceUrl { get; private set; }
        public string FileUrl { get; private set; }
        public bool HasPermissionToWriteText { get; private set; }
        public bool HasPermissionToSendVoice { get; private set; }
        public bool HasPermissionToSendFiles { get; private set; }
        public QuestionTashrihi(object questionObject)
        {
            if (questionObject is QuestionTashrihi question)
            {
                Text = question.Text;
                ImageUrl = question.ImageUrl;
                VoiceUrl = question.VoiceUrl;
                FileUrl = question.FileUrl;
                HasPermissionToWriteText = question.HasPermissionToWriteText;
                HasPermissionToSendVoice = question.HasPermissionToSendVoice;
                HasPermissionToSendFiles = question.HasPermissionToSendFiles;
            }
            else
                throw new InvalidCastException("Unable to cast object to type 'QuizMaker.Domain.Questions.Factories.QuestionTashrihi'.");
        }
    }
}
