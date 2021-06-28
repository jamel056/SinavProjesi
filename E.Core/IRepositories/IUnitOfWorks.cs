using E.Core.ArticleModule.IRepository;
using E.Core.ExamFormModule.IRepository;
using System.Threading.Tasks;

namespace E.Core.IRepositories
{
    public interface IUnitOfWorks
    {
        IArticleRepository ArticleRepository { get; }
        IExamFormRepository ExamFormRepository { get; }

        Task<int> CommitAsync();
    }
}
