namespace MauiLMTTemplate
{
    public partial class App : Application
    {
        private readonly INavigationService _navigationService;

        public App(INavigationService navigationService)
        {
            _navigationService = navigationService;

            InitializeComponent();

            // OPTIONAL: Code that you need to run when Initing the App, some routine or Api call
            InitApp(); 

            MainPage = new AppShell(navigationService);
        }

        private void InitApp()
        {
            //OPTIONAL: Add code that you need to run when Initiating the App
        }

        protected override void OnStart()
        {
            base.OnStart();

            //Add the code that should run when Starting the App
        }

        protected override void OnSleep()
        {
            base.OnSleep();

            //Add the code that should run when App is going into Sleep mode
        }
    }
}
