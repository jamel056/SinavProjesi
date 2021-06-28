using E.Core.IRepositories;
using E.Entities.Entities;
using System.Threading.Tasks;

namespace E.Core.ExamFormModule.IRepository
{
    public interface IExamFormRepository : IBaseRepository<ExamForm>
    {
        Task<ExamForm> GetAsyncInclude(int id);
    }
}
