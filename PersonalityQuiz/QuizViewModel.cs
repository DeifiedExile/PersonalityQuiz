using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace PersonalityQuiz
{
    class QuizViewModel : INotifyPropertyChanged
    {


        public ICommand TrueCommand { get; }
        public ICommand FalseCommand { get; }
        public ICommand RestartCommand { get; }
        public ICommand SwipeLeftCommand { get; }
        public ICommand SwipeRightCommand { get; }
        public ICommand GetResultsCommand { get; }
        public ICommand ToggleTFCommand { get; }

        public int QuestionID = 0;
        public QuestionModel CurrentQuestionModel => QuestionModel.All[QuestionID];
        public int CharacterID;
        public ObservableCollection<QuestionModel> QuestionList = new ObservableCollection<QuestionModel>(QuestionModel.All);
        public CharacterModel Character => Characters.ElementAtOrDefault(CharacterID);
        public List<CharacterModel> Characters = new List<CharacterModel>();
        public async void GetCharacters()
        {
            Characters = await App.ApiResultManager.GetTasksAsync();
                 
        }

        public int[] PersonalityProfile = new int[] { 0, 0, 0, 0 };
        public bool _IsResult = false;
        public string getprofile => PersonalityProfile[0] + " " + PersonalityProfile[1] + " " + PersonalityProfile[2] + " " + PersonalityProfile[3];


        public ObservableCollection<QuestionModel> Questions => QuestionList;

        public bool IsResult
        {
            get => this._IsResult;
            set => this._IsResult = value;
        }



        public QuizViewModel()
        {
            TrueCommand = new Command(SubmitQuestionTrue);
            FalseCommand = new Command(SubmitQuestionFalse);
            SwipeLeftCommand = new Command(SubmitQuestionFalse);
            SwipeRightCommand = new Command(SubmitQuestionTrue);
            RestartCommand = new Command(RestartApp);
            GetResultsCommand = new Command(GetResults);
            ToggleTFCommand = new Command(ToggleTF);
            


        }

        void ToggleTF(object obj)
        {
            
        }

        async void GetResults()
        {
            Characters = await App.ApiResultManager.GetTasksAsync();
            foreach (QuestionModel q in QuestionModel.All)
            {
                if(q.State)
                {
                    this.PersonalityProfile[q.TraitUp]++;
                    this.PersonalityProfile[q.TraitDown]--;
                }
                else
                {
                    this.PersonalityProfile[q.TraitUp]--;
                    this.PersonalityProfile[q.TraitDown]++;
                }
            }
            int r = 0;
            for (int i = 0; i < PersonalityProfile.Length; i++)
            {
                if (PersonalityProfile[i] > r)
                {
                    r = i;
                }
            }
            CharacterID = r;
            IsResult = true;
            OnCharacterIdChanged(nameof(Character));
            OnCharacterIdChanged(nameof(IsResult));
        }

        void SubmitQuestionTrue()
        {
            this.PersonalityProfile[this.CurrentQuestionModel.TraitUp] += 1;
            this.PersonalityProfile[this.CurrentQuestionModel.TraitDown] -= 1;
            if (QuestionID >= QuestionModel.All.Count - 1)
            {
                int r = 0;
                for (int i = 0; i < PersonalityProfile.Length; i++)
                {
                    if (PersonalityProfile[i] > r)
                    {
                        r = i;
                    }
                }
                CharacterID = r;
                IsResult = true;

                OnCharacterIdChanged(nameof(CharacterID));
                OnCharacterIdChanged(nameof(IsResult));

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
            if (QuestionID >= QuestionModel.All.Count - 1)
            {

                int r = 0;
                for (int i = 0; i < PersonalityProfile.Length; i++)
                {
                    if (PersonalityProfile[i] > r)
                    {
                        r = i;
                    }
                }
                CharacterID = r;
                IsResult = true;
                OnCharacterIdChanged(nameof(Character));
                OnCharacterIdChanged(nameof(IsResult));

            }
            else
            {
                QuestionID++;
                OnQuestionIdChanged(nameof(CurrentQuestionModel));
            }

        }

        void RestartApp()
        {
            (Application.Current).MainPage = new MainPage();
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
