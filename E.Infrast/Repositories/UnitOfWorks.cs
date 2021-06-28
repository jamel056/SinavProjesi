using E.Core.ArticleModule.IRepository;
using E.Core.ExamFormModule.IRepository;
using E.Core.IRepositories;
using E.Infrast.ArticleModule;
using E.Infrast.Data;
using E.Infrast.ExamFormModule;
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

        private IExamFormRepository _examFormRepository;
        public IExamFormRepository ExamFormRepository => _examFormRepository ?? (_examFormRepository = new ExamFormRepository(_context));

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
