using Bliss.Business.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bliss.Api.Controllers.Shared
{
    [AllowAnonymous]
    [Route("questions")]
    public class QuestionsController : ApiController
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionsController(IQuestionRepository questionRepository) : base()
        {
            _questionRepository = questionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int limit = 10, int offset = 0, string filter = null)
        {
            try
            {
                return ResponseOk(await _questionRepository.Get(limit, offset, filter));
            }
            catch (Exception e)
            {
                //Add log
                throw;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var question = await _questionRepository.GetById(id);

                return question != null 
                    ? ResponseOk(question)
                    : NotFound();
            }
            catch (Exception e)
            {
                //Add log
                throw;
            }
        }
    }
}