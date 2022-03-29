using System.Collections.Generic;

namespace Bliss.Business.Dtos
{
    public class UpdateQuestionDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Image_url { get; set; }
        public string Thumb_url { get; set; }
        public List<UpdateChoiceDto> Choices { get; set; }
    }
}
