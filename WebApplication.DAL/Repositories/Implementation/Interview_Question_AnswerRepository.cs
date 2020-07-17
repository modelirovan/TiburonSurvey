using System.Threading.Tasks;
using WebApplication.DAL.Models;

namespace WebApplication.DAL.Repositories.Implementation
{
    public class Interview_Question_AnswerRepository : IInterview_Question_AnswerRepository
    {
        private readonly TiburonDBContext _tiburonDBContext;

        public Interview_Question_AnswerRepository(TiburonDBContext tiburonDBContext)
        {
            _tiburonDBContext = tiburonDBContext;
        }

        public async Task<int> InsertAnswerIdByQuestionIdAndInterviewIdAsync(int questionId, int answerId, int interviewId)
        {
            var newInterviewStep = new InterviewQuestionAnswer
            {
                AnswerId = answerId,
                QuestionId = questionId,
                InterviewId = interviewId
            };

            await _tiburonDBContext.AddAsync(newInterviewStep);

            return newInterviewStep.InterviewId;
        }
    }
}
