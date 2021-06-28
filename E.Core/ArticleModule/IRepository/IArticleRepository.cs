using E.Core.IRepositories;
using E.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E.Core.ArticleModule.IRepository
{
    public interface IArticleRepository : IBaseRepository<Article>
    {
        Task<List<Article>> GetPart(int number);
    }
}
