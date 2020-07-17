using System;
using System.Collections.Generic;

namespace WebApplication.DAL.Models
{
    public partial class Question
    {
        public Question()
        {
            InterviewQuestionAnswer = new HashSet<InterviewQuestionAnswer>();
        }

        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int? SurveyId { get; set; }

        public ICollection<InterviewQuestionAnswer> InterviewQuestionAnswer { get; set; }
    }
}
