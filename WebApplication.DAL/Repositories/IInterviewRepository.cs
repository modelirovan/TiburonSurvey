using System.Threading.Tasks;
using WebApplication.DAL.Models;

namespace WebApplication.DAL.Repositories
{
    public interface IInterviewRepository
    {
        Task<Interview> CreateInterviewAsync(int interviewId, int surveyId, int questionId, int answerId);
        Task<Interview> GetInterviewByIdAsync(int interviewId);
        Task<Interview> UpdateInterviewAsync(int interviewId, int surveyId, int questionId, int answerId);
    }
}
