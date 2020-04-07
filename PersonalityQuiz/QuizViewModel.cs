using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PersonalityQuiz
{
    class QuizViewModel : INotifyPropertyChanged
    {
        //public QuestionModel Question;

        public ICommand TrueCommand { get; }
        public ICommand FalseCommand { get; }
        public int QuestionID = 0;
        public QuestionModel CurrentQuestionModel => QuestionModel.All[QuestionID];
        public int CharacterID = 4;
        public CharacterModel Character => CharacterModel.All[CharacterID];
        public int[] PersonalityProfile = new int[] { 0, 0, 0, 0 };
        //public bool isResult => Character != null;

        public string ResultName => Character.Name;
        public string ResultDescription => Character.Description;
        public string ResultUrl => Character.ImageUrl;

        public QuizViewModel()
        {
            TrueCommand = new Command(SubmitQuestionTrue);
            FalseCommand = new Command(SubmitQuestionFalse);
        }

        void SubmitQuestionTrue()
        {
            PersonalityProfile[this.CurrentQuestionModel.TraitUp]++;
            PersonalityProfile[this.CurrentQuestionModel.TraitDown]--;
            if (QuestionID >= QuestionModel.All.Count)
            {
                
                CharacterID = PersonalityProfile.IndexOf(PersonalityProfile.Max());
                
                OnCharacterIdChanged(nameof(Character));
                
            }
            else
            {
                QuestionID++;
                OnQuestionIdChanged(nameof(CurrentQuestionModel));
            }
        }

        void SubmitQuestionFalse()
        {
            PersonalityProfile[this.CurrentQuestionModel.TraitUp]--;
            PersonalityProfile[this.CurrentQuestionModel.TraitDown]++;
            if (QuestionID >= QuestionModel.All.Count)
            {

                CharacterID = PersonalityProfile.IndexOf(PersonalityProfile.Max());
                
                OnCharacterIdChanged(nameof(Character));

            }
            else
            {
                QuestionID++;
                OnQuestionIdChanged(nameof(CurrentQuestionModel));
            }
            
        }

        

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnCharacterIdChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnQuestionIdChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
