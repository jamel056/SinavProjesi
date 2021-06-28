using E.Core.ExamFormModule.IRepository;
using E.Entities.Entities;
using E.Infrast.Data;
using E.Infrast.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E.Infrast.ExamFormModule
{
    public class ExamFormRepository : BaseRepository<ExamForm>, IExamFormRepository
    {
        private readonly AppIdentityDbContext _context;

        public ExamFormRepository(AppIdentityDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ExamForm> GetAsyncInclude(int id)
        {
            return await _context.ExamForms
                .Include(x => x.Questions)
                .ThenInclude(x => x.Answers)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
