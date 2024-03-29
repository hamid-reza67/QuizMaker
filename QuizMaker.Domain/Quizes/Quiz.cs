﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizMaker.Domain.Questions;
using QuizMaker.Domain.Quizes.ValueObjects;
using System.Diagnostics;
using QuizMaker.Domain.Participants;
using QuizMaker.Domain.Shared.Exceptions;
using QuizMaker.Domain.Questions.Enumeration;
using QuizMaker.Domain.Shared.ValueObjects;

namespace QuizMaker.Domain.Quizes
{
    public class Quiz
    {
        public Guid Id { get; }
        public Guid OwnerId { get; }
        public Title Title { get; private set; }
        public QuizDurationType DurationType { get; private set; }
        public Duration Duration { get; private set; }
        public DateRange DateRange { get; private set; }
        public Score PassingMark { get; private set; }
        public TextEditor StartMessage { get; private set; }
        public TextEditor EndMessage { get; private set; }
        public AllowedNumberOfTimesToParticipate AllowedNumberOfTimesToParticipate { get; private set; }
        public bool ShufflingQuestions { get; private set; }
        public bool ShufflingQuestionOptions { get; private set; }
        public bool DisplayDistinctQuestionsToEachParticipant { get; private set; }
        public QuestionCount ComfortableQuestionCount { get; private set; }
        public QuestionScore ComfortableQuestionScore { get; private set; }
        public QuestionCount MediumQuestionCount { get; private set; }
        public QuestionScore MediumQuestionScore { get; private set; }
        public QuestionCount HardQuestionCount { get; private set; }
        public QuestionScore HardQuestionScore { get; private set; }
        public bool PlayMediaOnce { get; private set; }
        public bool DisplayResultAfterTheEnd { get; private set; }
        public bool AbilityToMoveBetweenQuestions { get; private set; }
        public bool DisplayTheAnswerWhenNext { get; private set; }
        public QuizDirection QuizDirection { get; private set; }
        public QuizState State { get; private set; }

        private List<QuestionType> _availableQuestionTypes = new();
        public IReadOnlyList<QuestionType> AvailableQuestionTypes => _availableQuestionTypes.AsReadOnly();

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
            EnsureValidState();
        }

        public void Update(
            Title title,
            QuizDurationType durationType,
            Duration duration,
            DateRange dateRange,
            Score passingMark,
            TextEditor startMessage,
            TextEditor endMessage,
            AllowedNumberOfTimesToParticipate allowedNumberOfTimesToParticipate,
            bool shufflingQuestions,
            bool shufflingQuestionOptions,
            bool displayDistinctQuestionsToEachParticipant,
            QuestionCount comfortableQuestionCount,
            QuestionScore comfortableQuestionScore,
            QuestionCount mediumQuestionCount,
            QuestionScore mediumQuestionScore,
            QuestionCount hardQuestionCount,
            QuestionScore hardQuestionScore,
            bool playMediaOnce,
            bool displayResultAfterTheEnd,
            bool abilityToMoveBetweenQuestions,
            bool displayTheAnswerWhenNext,
            QuizDirection quizDirection,
            IEnumerable<QuestionType> availableQuestionTypes
            )
            {
                Title = title;
                DurationType = durationType;
                Duration = duration;
                DateRange = dateRange;
                PassingMark = passingMark;
                StartMessage = startMessage;
                EndMessage = endMessage;
                AllowedNumberOfTimesToParticipate = allowedNumberOfTimesToParticipate;
                ShufflingQuestions = shufflingQuestions;
                ShufflingQuestionOptions = shufflingQuestionOptions;
                DisplayDistinctQuestionsToEachParticipant = displayDistinctQuestionsToEachParticipant;
                ComfortableQuestionCount = comfortableQuestionCount;
                ComfortableQuestionScore = comfortableQuestionScore;
                MediumQuestionCount = mediumQuestionCount;
                MediumQuestionScore = mediumQuestionScore;
                HardQuestionCount = hardQuestionCount;
                HardQuestionScore = hardQuestionScore;
                PlayMediaOnce = playMediaOnce;
                DisplayResultAfterTheEnd = displayResultAfterTheEnd;
                AbilityToMoveBetweenQuestions = abilityToMoveBetweenQuestions;
                DisplayTheAnswerWhenNext = displayTheAnswerWhenNext;
                QuizDirection = quizDirection;
                _availableQuestionTypes = availableQuestionTypes.ToList();
                State = QuizState.Inactive;
                EnsureValidState();
            }
        public void Publish()
        {
            State = QuizState.Active;
            EnsureValidState();
        }
        public void AddQuestion(Guid quizId,
            HardshipLevel hardshipLevel,
            Score questionScore,
            TextEditor participateTips,
            TextEditor resultTips,
            QuestionType questionType,
            object questionFeature)
        {
            if (!AvailableQuestionTypes.Contains(questionType))
                throw new ArgumentException("Quiz does not have this question type.");

            _questions.Add(new Question(Id, hardshipLevel, questionScore, participateTips, resultTips, questionType, questionFeature));
            EnsureValidState();
        }

        private void EnsureValidState()
        {
            bool validState = true;
            if (DurationType == QuizDurationType.Variable && AbilityToMoveBetweenQuestions)
                validState = false;

            if (AbilityToMoveBetweenQuestions && DisplayTheAnswerWhenNext)
                validState = false;

            var valid =
                validState &&
                State switch
                {
                    QuizState.Active =>
                        Questions.Any()
                        && Participants.Any(),
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
    public enum QuizDurationType
    {
        Fix,
        Variable
    }

    public enum QuizDirection
    {
        RightToLeft,
        LeftToRight
    }
}
