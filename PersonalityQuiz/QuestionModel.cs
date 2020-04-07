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
        
        //public int QuestionID = 0;
        public string QText { get; private set; }
        public int TraitUp { get; private set; }
        public int TraitDown { get; private set; }
        //public ICommand TrueCommand { get; }
        //public ICommand FalseCommand { get; }
        //public QuestionModel CurrentQuestionModel => All[QuestionID];

        //int[] PersonalityProfile = new int[] { 0, 0, 0, 0 };



        public QuestionModel(string qText, int traitUp, int traitDown)
        {
            QText = qText;
            TraitUp = traitUp;
            TraitDown = traitDown;

        }


        //void SubmitQuestionTrue()
        //{
        //    PersonalityProfile[this.CurrentQuestionModel.TraitUp]++;
        //    PersonalityProfile[this.CurrentQuestionModel.TraitDown]--;
        //    QuestionID++;
        //    OnQuestionIDChanged();

        //}

        //void SubmitQuestionFalse()
        //{
        //    PersonalityProfile[this.CurrentQuestionModel.TraitUp]--;
        //    PersonalityProfile[this.CurrentQuestionModel.TraitDown]++;
        //    QuestionID++;
        //    OnQuestionIDChanged();
        //}

        

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
                new QuestionModel("I always look out for myself first",0, 3 )
                

            };

        }

        public static IList<QuestionModel> All { get; private set; }

        //public event PropertyChangedEventHandler PropertyChanged;

        //void OnQuestionIDChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

    }
}
