namespace MauiLMTTemplate
{
    public partial class AppShell : Shell
    {
        private readonly INavigationService _navigationService;

        public AppShell(INavigationService navigationService)
        {
            _navigationService = navigationService;

            AppShell.InitializeRouting();
            InitializeComponent();
        }

        private static void InitializeRouting()
        {
            //Add your Views Routing here
        }
    }
}
