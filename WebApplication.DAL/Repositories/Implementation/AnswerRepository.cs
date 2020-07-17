using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL.Models;

namespace WebApplication.DAL.Repositories.Implementation
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly TiburonDBContext _tiburonDBContext;

        public AnswerRepository(TiburonDBContext tiburonDBContext)
        {
            _tiburonDBContext = tiburonDBContext;
        }

        public async Task<List<Answer>> GetAnswersByQuestionIdsAsync(List<int> questionIds)
        {
            var res = await (from a in _tiburonDBContext.Answer
                             join b in questionIds on a.QuestionId equals b
                             select a).ToListAsync();

            return res;
        }

        public async Task<Answer> GetAnswerByIdAsync(int answerId)
        {
            var res = await _tiburonDBContext.Answer.Where(x => x.QuestionId == answerId).FirstOrDefaultAsync();
            return res;
        }
    }
}
