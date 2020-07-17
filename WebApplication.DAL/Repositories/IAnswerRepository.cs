using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL.Models;

namespace WebApplication.DAL.Repositories
{
    public interface IAnswerRepository
    {
        Task<List<Answer>> GetAnswersByQuestionIdsAsync(List<int> questionIds);
        Task<Answer> GetAnswerByIdAsync(int questionId);
    }
}
