using E.Core.ArticleModule.IRepository;
using E.Entities.Entities;
using E.Infrast.Data;
using E.Infrast.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E.Infrast.ArticleModule
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        private readonly AppIdentityDbContext _context;

        public ArticleRepository(AppIdentityDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Article>> GetPart(int number)
        {
            return await _context.Articles
                .AsQueryable()
                .OrderByDescending(x => x.CreateDate)
                .Take(number)
                .ToListAsync();
        }
    }
}
