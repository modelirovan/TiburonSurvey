using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL.Models;

namespace WebApplication.DAL.Repositories
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllQuestionBySurveyIdAsync(int surveyId);
        Task<Question> GetQuestionByIdAsync(int questionId);
    }
}
