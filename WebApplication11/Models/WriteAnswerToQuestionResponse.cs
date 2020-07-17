using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication11.Models
{
    public class WriteAnswerToQuestionResponse
    {
        public int NextQuestionId { get; set; }
        public int NextQuestionNumber { get; set; }
        public int InterviewId { get; set; }
        public int SurveyId { get; set; }
    }
}
