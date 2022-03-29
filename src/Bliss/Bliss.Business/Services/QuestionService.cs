using Bliss.Business.Interfaces.Notification;
using Bliss.Business.Interfaces.Repositories;
using Bliss.Business.Interfaces.Services;
using Bliss.Business.Models;
using Bliss.Business.Models.Validations;
using Bliss.Business.Services.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace Bliss.Business.Services
{
    public class QuestionService : BaseService, IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository,
                               INotifier notifier) : base(notifier)
        {
            _questionRepository = questionRepository;
        }

        public async Task<QuestionModel> Insert(QuestionModel question)
        {
            if (!ExecuteValidation(new QuestionValidation(), question)) 
                return null;

            if (_questionRepository.Search(f => f.Question == question.Question).Result.Any())
            {
                Notifier("The question alredy been added.");
                return null;
            }

            await _questionRepository.Insert(question);

            return question;
        }
    }
}