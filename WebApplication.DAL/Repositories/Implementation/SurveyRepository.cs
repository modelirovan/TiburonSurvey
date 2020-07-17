using WebApplication.DAL.Models;

namespace WebApplication.DAL.Repositories.Implementation
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly TiburonDBContext _tiburonDBContext;

        public SurveyRepository(TiburonDBContext tiburonDBContext)
        {
            _tiburonDBContext = tiburonDBContext;
        }
    }
}
