using System.Collections.Generic;

namespace PersonalityQuiz
{
    class QuestionModel
    {

        public string QText { get; private set; }
        public int TraitUp { get; private set; }
        public int TraitDown { get; private set; }
        public bool State { get; set; }

        public QuestionModel(string qText, int traitUp, int traitDown)
        {
            QText = qText;
            TraitUp = traitUp;
            TraitDown = traitDown;
            State = true;

        }
        
        static QuestionModel()
        {
            All = new List<QuestionModel>
            {
                new QuestionModel("I like to make things",          3, 2 ),
                new QuestionModel("I like being in control",        3, 0 ),
                new QuestionModel("I like to be alone",             2, 3),
                new QuestionModel("I tend to think very logically", 1, 0),
                new QuestionModel("I tend to go with my gut",       0, 3),
                new QuestionModel("I keep to keep my options open", 0, 2),
                new QuestionModel("I always look out for myself first",3, 2 ),

            };

        }


        public static IList<QuestionModel> All { get; private set; }
    }
}
