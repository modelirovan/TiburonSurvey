using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication11.Models
{
    public class AnswerModel
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
    }
}
