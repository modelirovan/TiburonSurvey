using System;
using System.Collections.Generic;

namespace WebApplication.DAL.Models
{
    public partial class Interview
    {
        public Interview()
        {
            InterviewQuestionAnswer = new HashSet<InterviewQuestionAnswer>();
        }

        public int InterviewId { get; set; }
        public int SurveyId { get; set; }
        public string UserName { get; set; }
        public bool? Gender { get; set; }
        public short? Age { get; set; }

        public ICollection<InterviewQuestionAnswer> InterviewQuestionAnswer { get; set; }
    }
}
