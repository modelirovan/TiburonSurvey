using System.Collections.Generic;

namespace WebApplication11.Models
{
    public class QuestionsAndAnswersModel
    {
        public int QuestionNumber { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<AnswerModel> Answers { get; set; } = new List<AnswerModel>();
    }
}
