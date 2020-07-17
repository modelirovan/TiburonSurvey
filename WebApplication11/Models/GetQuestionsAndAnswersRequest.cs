using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication11.Models
{
    public class GetQuestionsAndAnswersRequest
    {
        public int SurveyId { get; set; }
        public int QuestionNumber { get; set; }
    }
}
