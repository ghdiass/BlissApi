using AutoMapper;
using Bliss.Business.Dtos;
using Bliss.Business.Interfaces.Notification;
using Bliss.Business.Interfaces.Repositories;
using Bliss.Business.Interfaces.Services;
using Bliss.Business.Models;
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
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;

        public QuestionsController(IQuestionRepository questionRepository,
                                   IQuestionService questionService,
                                   IMapper mapper,
                                   INotifier notifier) : base(notifier)
        {
            _mapper = mapper;
            _questionService = questionService;
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
                return ResponseInternalServerError(e);
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
                return ResponseInternalServerError(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CreateQuestionDto createQuestion)
        {
            try
            {
                var question = await _questionService.Insert(_mapper.Map<QuestionModel>(createQuestion));
                return ResponseCreated(question);
            }
            catch (Exception e)
            {
                return ResponseInternalServerError(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateQuestionDto updateQuestion)
        {
            try
            {
                var question = await _questionService.Update(_mapper.Map<QuestionModel>(updateQuestion));
                return ResponseCreated(question);
            }
            catch (Exception e)
            {
                return ResponseInternalServerError(e);
            }
        }
    }
}