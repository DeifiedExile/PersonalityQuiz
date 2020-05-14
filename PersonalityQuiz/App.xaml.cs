using PersonalityQuiz.Data;
using Xamarin.Forms;


namespace PersonalityQuiz
{
    public partial class App : Application
    {
        public static ApiResultManager ApiResultManager { get; private set; }
        public App()
        {
            InitializeComponent();
            ApiResultManager = new ApiResultManager(new RestService());

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
