using System.Threading.Tasks;

namespace WebApplication.DAL.Repositories
{
    public interface IInterview_Question_AnswerRepository
    {
        Task<int> InsertAnswerIdByQuestionIdAndInterviewIdAsync(int questionId, int answerId, int interviewId);
    }
}
