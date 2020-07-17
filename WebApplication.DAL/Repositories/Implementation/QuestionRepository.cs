using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL.Models;

namespace WebApplication.DAL.Repositories.Implementation
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly TiburonDBContext _tiburonDBContext;

        public QuestionRepository(TiburonDBContext tiburonDBContext)
        {
            _tiburonDBContext = tiburonDBContext;
        }

        public async Task<List<Question>> GetAllQuestionBySurveyIdAsync(int surveyId)
        {
            var res = await (from a in _tiburonDBContext.Question
                                 //join b in _tiburonDBContext.InterviewQuestionAnswer on a.QuestionId equals b.QuestionId
                                 //join c in _tiburonDBContext.Answer on b.AnswerId equals c.AnswerId
                             join e in _tiburonDBContext.Survey on a.SurveyId equals e.SurveyId
                             where e.SurveyId == surveyId
                             select a).ToListAsync();

            return res;
        }

        public async Task<Question> GetQuestionByIdAsync(int questionId)
        {
            var res = await _tiburonDBContext.Question.Where(x => x.QuestionId == questionId).FirstOrDefaultAsync();
            return res;
        }
    }
}
