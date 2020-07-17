using WebApplication.DAL.Models;

namespace WebApplication.DAL.Repositories.Implementation
{
    public class ResultRepository : IResultRepository
    {
        private readonly TiburonDBContext _tiburonDBContext;

        public ResultRepository(TiburonDBContext tiburonDBContext)
        {
            _tiburonDBContext = tiburonDBContext;
        }
    }
}
