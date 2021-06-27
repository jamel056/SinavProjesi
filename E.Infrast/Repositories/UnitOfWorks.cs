using E.Core.ArticleModule.IRepository;
using E.Core.IRepositories;
using E.Infrast.ArticleModule;
using E.Infrast.Data;
using System.Threading.Tasks;

namespace E.Infrast.Repositories
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly AppIdentityDbContext _context;

        public UnitOfWorks(AppIdentityDbContext context)
        {
            _context = context;
        }

        private IArticleRepository _articleRepository;
        public IArticleRepository ArticleRepository => _articleRepository ?? (_articleRepository = new ArticleRepository(_context));

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
