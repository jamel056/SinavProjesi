using E.Core.ArticleModule.IRepository;
using E.Entities.Entities;
using E.Infrast.Data;
using E.Infrast.Repositories;

namespace E.Infrast.ArticleModule
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(AppIdentityDbContext context) : base(context)
        {

        }
    }
}
