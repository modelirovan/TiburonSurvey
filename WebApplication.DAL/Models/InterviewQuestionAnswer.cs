using System;
using System.Collections.Generic;

namespace WebApplication.DAL.Models
{
    public partial class InterviewQuestionAnswer
    {
        public int InterviewId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }

        public Answer Answer { get; set; }
        public Interview Interview { get; set; }
        public Question Question { get; set; }
    }
}
