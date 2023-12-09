using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using QuizMaker.Domain.Questions;
using QuizMaker.Domain.Quizes.ValueObject;
using System.Diagnostics;
using QuizMaker.Domain.Participants;
using QuizMaker.Domain.Shared;

namespace QuizMaker.Domain.Quizes
{
    public class Quiz
    {
        public Guid Id { get; }
        public Guid OwnerId { get; }
        public Title Title { get; private set; }
        public Duration Duration { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public string StartTimeMessage { get; private set; }
        public string EndTimeMessage { get; private set; }
        public AllowedNumberOfTimesToParticipate AllowedNumberOfTimesToParticipate { get; private set; }
        public bool ShowStatsAfterTheEnd { get; private set; }
        public bool ShowResultPageAfterTheEnd { get; private set; }
        public bool ShufflingQuestions { get; private set; }
        public bool ShufflingQuestionOptions { get; private set; }
        public bool PlayMediaOnce { get; private set; }
        public PassingMark PassingMark { get; private set; }
        public QuizState State { get; private set; }

        private List<Question> _questions = new();
        public IReadOnlyList<Question> Questions => _questions.AsReadOnly();

        private List<Participant> _participants = new();
        public IReadOnlyList<Participant> Participants => _participants.AsReadOnly();

        public Quiz(Guid ownerId, Title title)
        {
            Id = Guid.NewGuid();
            OwnerId = ownerId;
            Title = title;
            State = QuizState.Inactive;
        }

        public void Update(
            Title title,
            Duration duration,
            DateTime? startDate,
            DateTime? endDate,
            string startTimeMessage,
            string endTimeMessage,
            AllowedNumberOfTimesToParticipate allowedNumberOfTimesToParticipate,
            bool showStatsAfterTheEnd,
            bool showResultPageAfterTheEnd,
            bool shufflingQuestions,
            bool shufflingQuestionOptions,
            bool playMediaOnce,
            PassingMark passingMark)
        {
            EnsureValidState();
            Title = title;
            Duration = duration;
            StartDate = startDate;
            EndDate = endDate;
            StartTimeMessage = startTimeMessage;
            EndTimeMessage = endTimeMessage;
            AllowedNumberOfTimesToParticipate = allowedNumberOfTimesToParticipate;
            ShowStatsAfterTheEnd = showStatsAfterTheEnd;
            ShowResultPageAfterTheEnd = showResultPageAfterTheEnd;
            ShufflingQuestions = shufflingQuestions;
            ShufflingQuestionOptions = shufflingQuestionOptions;
            PlayMediaOnce = playMediaOnce;
            PassingMark = passingMark;
        }
        public void Publish()
        {
            EnsureValidState();
            State = QuizState.Active;
        }

        private void EnsureValidState()
        {
            var valid =
                State switch
                {
                    QuizState.Active =>
                        Questions.Count == 0
                        && Participants.Count == 0,
                    _ => true
                };

            if (!valid)
                throw new InvalidEntityStateException(this, $"Post-checks failed in state {State}");
        }

    }

    public enum QuizState
    {
        Active,
        Inactive
    }
}
