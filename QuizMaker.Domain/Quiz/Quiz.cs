using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuizMaker.Domain.Quiz
{
    public class Quiz
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Title { get; private set; }
        public int? Duration { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public string StartTimeMessage { get; private set; }
        public string EndTimeMessage { get; private set; }
        public int? AllowedNumberOfTimesToParticipate { get; private set; }
        public bool ShowStatsAfterTheEnd { get; private set; }
        public bool ShowResultPageAfterTheEnd { get; private set; }
        public bool ShufflingQuestions { get; private set; }
        public bool ShufflingQuestionOptions { get; private set; }
        public bool PlayMediaOnce { get; private set; }
        public int? PassingMark { get; private set; }
        public IEnumerable<Question.Question>? Questions { get; private set; }
        public QuizState State { get; private set; }

        public Quiz(Guid id, Guid ownerId)
        {
            Id = id;
            OwnerId = ownerId;
            State = QuizState.Inactive;
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("Title cannot be empty");

            if (title.Length > 200)
                throw new ArgumentOutOfRangeException("Title cannot be longer that 200 characters");

            Title = title;
        }
        public void SetDuration(int? duration)
        {
            if (!duration.HasValue)
                throw new ArgumentNullException("Duration cannot be empty");

            if (duration <= 0)
                throw new ArgumentOutOfRangeException("Duration cannot be 0 and less than 0");

            if (duration > 5 * 60 * 60)
                throw new ArgumentOutOfRangeException("Duration cannot be more than 5 houres");

            Duration = duration;
        }
        public void SetStartDate(DateTime? startDate)
        {
            StartDate = startDate;
        }
        public void SetEndDate(DateTime? endDate)
        {
            EndDate = endDate;
        }
        public void UpdateStartTimeMessage(string message)
        {
            StartTimeMessage = message;
        }
        public void UpdateEndTimeMessage(string message)
        {
            EndTimeMessage = message;
        }
        public void SetAllowedNumberOfTimesToParticipate(int? allowedNumberOfTimesToParticipate)
        {
            if (allowedNumberOfTimesToParticipate == 0)
                throw new ArgumentOutOfRangeException("Allowed number of times to participate cannot be 0");

            if (allowedNumberOfTimesToParticipate > 10)
                throw new ArgumentOutOfRangeException("Allowed number of times to participate cannot be more than 10");

            AllowedNumberOfTimesToParticipate = allowedNumberOfTimesToParticipate;
        }
        public void SetShowStatsAfterTheEnd(bool showStatsAfterTheEnd)
        {
            ShowStatsAfterTheEnd=showStatsAfterTheEnd;
        }
        public void SetShowResultPageAfterTheEnd(bool showResultPageAfterTheEnd)
        {
            ShowResultPageAfterTheEnd= showResultPageAfterTheEnd;
        }
        public void SetShufflingQuestions(bool shufflingQuestions)
        {
            ShufflingQuestions = shufflingQuestions;
        }
        public void SetShufflingQuestionOptions(bool shufflingQuestionOptions)
        {
            ShufflingQuestionOptions = shufflingQuestionOptions;
        }
        public void SetPlayMediaOnce(bool playMediaOnce)
        {
            PlayMediaOnce=playMediaOnce;
        }
        public void SetPassingMark(int? passingMark)
        {
            if (passingMark < 0)
                throw new ArgumentOutOfRangeException("Passing mark cannot be less than 0");

            if (passingMark > 1000)
                throw new ArgumentOutOfRangeException("Passing mark cannot be more than 1000");

            PassingMark = passingMark;
        }
        public void SetQuestions(IEnumerable<Question.Question>? questions)
        {
            Questions = questions;
        }
        public void Publish()
        {
            State = QuizState.Active;
        }
        public enum QuizState
        {
            Active,
            Inactive
        }

    }
}
