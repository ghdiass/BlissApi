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
        private readonly IChoiceRepository _choiceRepository;

        public QuestionService(IQuestionRepository questionRepository,
                               IChoiceRepository choiceRepository,
                               INotifier notifier) : base(notifier)
        {
            _questionRepository = questionRepository;
            _choiceRepository = choiceRepository;
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

        public async Task<QuestionModel> Update(QuestionModel oldQuestion)
        {
            if (!ExecuteValidation(new QuestionValidation(), oldQuestion))
                return null;

            var question = await _questionRepository.GetById(oldQuestion.Id);

            if(question == null)
            {
                Notifier("Question not found.");
                return null;
            }

            if (_questionRepository.Search(f => f.Question == oldQuestion.Question && f.Id != question.Id).Result.Any())
            {
                Notifier("The question alredy been added.");
                return null;
            }

            question.Update(oldQuestion.Question,
                            oldQuestion.Image_url,
                            oldQuestion.Thumb_url,
                            oldQuestion.Choices);

            foreach (var choice in _choiceRepository.Search(x => x.QuestionId == question.Id).Result)
                await _choiceRepository.Delete(choice.Id, false);
          
            await _questionRepository.Update(question, false);

            await _questionRepository.SaveChanges();

            return question;
        }
    }
}