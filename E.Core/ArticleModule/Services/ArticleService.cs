using E.Core.ArticleModule.Requests;
using E.Core.IRepositories;
using E.Entities.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E.Core.ArticleModule.Services
{
    public interface IArticleService
    {
        Task<bool> Create(ArticleRequest request);
        Task<bool> Edit(EditArticleRequest request, int id);
        Task<bool> Delete(int id);
        Task<Article> Get(int id);
        Task<List<Article>> GetAll();
    }

    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public ArticleService(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public async Task<bool> Create(ArticleRequest request)
        {
            var article = new Article()
            {
                Title = request.Title,
                Text = request.Text
            };

            await _unitOfWorks.ArticleRepository.AddAsync(article);
            return await _unitOfWorks.CommitAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var article = await _unitOfWorks.ArticleRepository.GetAsync(id);

            if (article == null) return false;

            _unitOfWorks.ArticleRepository.Delete(article);

            return await _unitOfWorks.CommitAsync() > 0;
        }

        public async Task<bool> Edit(EditArticleRequest request, int id)
        {
            var article = await _unitOfWorks.ArticleRepository.GetAsync(id);

            if (article == null) return false;

            article.Title = request.Title;
            article.Text = request.Text;

            _unitOfWorks.ArticleRepository.Update(article);
            return await _unitOfWorks.CommitAsync() > 0;
        }

        public async Task<Article> Get(int id)
        {
            return await _unitOfWorks.ArticleRepository.GetAsync(id);
        }

        public async Task<List<Article>> GetAll()
        {
            return (await _unitOfWorks.ArticleRepository.GetAllAsync()).ToList();
        }
    }
}
