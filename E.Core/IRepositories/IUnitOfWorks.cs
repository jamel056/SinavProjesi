using E.Core.ArticleModule.IRepository;
using System.Threading.Tasks;

namespace E.Core.IRepositories
{
    public interface IUnitOfWorks
    {
        IArticleRepository ArticleRepository { get; }
        Task<int> CommitAsync();
    }
}
