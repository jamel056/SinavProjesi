using E.Core.ExamFormModule.Requests;
using E.Core.IRepositories;
using E.Entities.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E.Core.ExamFormModule.Services
{
    public interface IExamFormService
    {
        Task<ExamForm> Get(int id);
        Task<List<ExamForm>> GetAll();
        Task<bool> Delete(int id);
        Task<bool> Create(ExamFormRequest request);
    }

    public class ExamFormService : IExamFormService
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public ExamFormService(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public async Task<ExamForm> Get(int id)
        {
            return await _unitOfWorks.ExamFormRepository.GetAsyncInclude(id);
        }

        public async Task<List<ExamForm>> GetAll()
        {
            return (await _unitOfWorks.ExamFormRepository.GetAllAsync()).ToList();
        }

        public async Task<bool> Delete(int id)
        {
            var form = await _unitOfWorks.ExamFormRepository.GetAsync(id);

            if (form == null) return false;

            _unitOfWorks.ExamFormRepository.Delete(form);

            return await _unitOfWorks.CommitAsync() > 0;
        }

        public async Task<bool> Create(ExamFormRequest request)
        {
            var form = new ExamForm()
            {
                FormQuestion = request.FormQuestion,
                FormText = request.FormText,
                Questions = new List<Questions>()
            };

            foreach (var question in request.Questions)
            {
                var item = new Questions
                {
                    Question = question.Question,
                    Answers = new List<Answers>()
                };

                form.Questions.Add(item);
                foreach (var answer in question.Answers)
                {
                    var index = 1;
                    item.Answers.Add(new Answers()
                    {
                        Answer = answer.Answer,
                        IsTrue = index == question.AnswerTrue ? true : false
                    });
                    index++;
                }
            }

            await _unitOfWorks.ExamFormRepository.AddAsync(form);
            return await _unitOfWorks.CommitAsync() > 0;
        }
    }
}
