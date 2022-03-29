using Bliss.Business.Models.Shared;

namespace Bliss.Business.Models
{
    //Class ends with 'Model' to not conflite with attribute 'Choice'
    public class ChoiceModel : Entity
    {
        public ChoiceModel()
        {   }

        public ChoiceModel(string choice)
        {
            Choice = choice;
        }

        public ChoiceModel(string choice, int votes)
        {
            Choice = choice;
            Votes = votes;
        }

        public ChoiceModel(int id, int questionId, string choice)
        {
            Id = id;
            QuestionId = questionId;
            Choice = choice;
        }

        public int QuestionId { get; set; }
        public string Choice { get; set; }
        public int Votes { get; set; }

        public QuestionModel Question { get; set; }
    }
}