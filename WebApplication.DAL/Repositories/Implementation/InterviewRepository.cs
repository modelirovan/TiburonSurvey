using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL.Models;

namespace WebApplication.DAL.Repositories.Implementation
{
    public class InterviewRepository : IInterviewRepository
    {
        private readonly TiburonDBContext _tiburonDBContext;

        public InterviewRepository(TiburonDBContext tiburonDBContext)
        {
            _tiburonDBContext = tiburonDBContext;
        }

        public async Task<Interview> CreateInterviewAsync(int interviewId, int surveyId, int questionId, int answerId)
        {
            var newInterview = new Interview
            {
                SurveyId = surveyId,
                InterviewQuestionAnswer = new List<InterviewQuestionAnswer>()
                {
                    new InterviewQuestionAnswer
                      {
                       AnswerId = answerId,
                       QuestionId = questionId,
                       InterviewId = interviewId
                      }
                }
            };

            await _tiburonDBContext.Interview.AddRangeAsync(newInterview);

            await _tiburonDBContext.SaveChangesAsync();

            return newInterview;
        }

        public async Task<Interview> UpdateInterviewAsync(int interviewId, int surveyId, int questionId, int answerId)
        {
            var interview = _tiburonDBContext.Interview.Where(x => x.InterviewId == interviewId).FirstOrDefault();
            interview.InterviewQuestionAnswer.Add(new InterviewQuestionAnswer
            {
                AnswerId = answerId,
                QuestionId = questionId,
                InterviewId = interviewId
            });

            _tiburonDBContext.Interview.Update(interview);

            await _tiburonDBContext.SaveChangesAsync();

            return interview;
        }

        public async Task<Interview> GetInterviewByIdAsync(int interviewId)
        {
            var interview = _tiburonDBContext.Interview.Where(x => x.InterviewId == interviewId).FirstOrDefaultAsync();
            return await interview;
        }
    }
}
