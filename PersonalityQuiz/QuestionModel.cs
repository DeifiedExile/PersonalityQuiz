using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PersonalityQuiz
{
    class QuestionModel
    {

        public string QText { get; private set; }
        public int TraitUp { get; private set; }
        public int TraitDown { get; private set; }
        
        public QuestionModel(string qText, int traitUp, int traitDown)
        {
            QText = qText;
            TraitUp = traitUp;
            TraitDown = traitDown;

        }
        
        static QuestionModel()
        {
            All = new List<QuestionModel>
            {
                new QuestionModel("I like to make things",          2, 0 ),
                new QuestionModel("I like being in control",        2, 1 ),
                new QuestionModel("I like to be alone",             0, 2),
                new QuestionModel("I tend to think very logically", 3, 1),
                new QuestionModel("I tend to go with my gut",       1, 2),
                new QuestionModel("I keep to keep my options open", 1, 0),
                new QuestionModel("I always look out for myself first",0, 3 ),
   
            };

        }

        public static IList<QuestionModel> All { get; private set; }
    }
}
