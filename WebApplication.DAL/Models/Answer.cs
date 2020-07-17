using System;
using System.Collections.Generic;

namespace WebApplication.DAL.Models
{
    public partial class Answer
    {
        public Answer()
        {
            InterviewQuestionAnswer = new HashSet<InterviewQuestionAnswer>();
        }

        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }

        public ICollection<InterviewQuestionAnswer> InterviewQuestionAnswer { get; set; }
    }
}
