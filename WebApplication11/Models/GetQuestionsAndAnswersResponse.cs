using System.Collections.Generic;

namespace WebApplication11.Models
{
    public class GetQuestionsAndAnswersResponse
    {
       //public List<QuestionsAndAnswersModel> QuestionsAndAnswers { get; set; } = new List<QuestionsAndAnswersModel>();
        public int QuestionNumber { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
    }
}
