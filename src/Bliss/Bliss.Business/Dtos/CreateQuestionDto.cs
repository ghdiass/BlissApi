using System.Collections.Generic;

namespace Bliss.Business.Dtos
{
    public class CreateQuestionDto
    {
        public string Question { get; set; }
        public string Image_url { get; set; }
        public string Thumb_url { get; set; }
        public List<string> Choices { get; set; }
    }
}
