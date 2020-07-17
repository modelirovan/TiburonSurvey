using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication11.Models
{
    public class WriteAnswerToQuestionRequest
    {
        public int CurrentIterviewId { get; set; }
        public int CurrentSurveyId { get; set; }
        public int CurrentQuestionId { get; set; }
        public int CurrentAnswerId { get; set; }
      
    }
}
