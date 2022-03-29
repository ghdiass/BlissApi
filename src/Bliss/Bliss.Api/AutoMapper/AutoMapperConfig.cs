using AutoMapper;
using Bliss.Business.Dtos;
using Bliss.Business.Models;
using System.Linq;

namespace Bliss.Api.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreateQuestionDto, QuestionModel>()
                .ForMember(x => x.Choices,
                           opts => opts.MapFrom(src => src.Choices.Select(c => new ChoiceModel(c))));

            CreateMap<UpdateQuestionDto, QuestionModel>()
                .ForMember(x => x.Choices,
                           opts => opts.MapFrom(src => src.Choices.Select(c => new ChoiceModel(c.Choice, c.Votes))));
        }
    }
}
