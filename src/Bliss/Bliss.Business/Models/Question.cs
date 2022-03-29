using Bliss.Business.Models.Shared;
using System;
using System.Collections.Generic;

namespace Bliss.Business.Models
{
    public class QuestionModel : Entity
    {
        public QuestionModel()
        {
            Published_at = DateTime.Now;
        }

        public QuestionModel(int id,
                             string question, 
                             string image_url, 
                             string thumb_url)
        {
            Id = id;
            Question = question;
            Image_url = image_url;
            Thumb_url = thumb_url;
            Published_at = DateTime.Now;
        }

        public string Question { get; set; }
        public string Image_url { get; set; }
        public string Thumb_url { get; set; }
        public DateTime Published_at { get; set; }
        public DateTime? Update_at { get; set; }

        public List<ChoiceModel> Choices { get; set; }
    }
}
