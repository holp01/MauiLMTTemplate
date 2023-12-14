namespace MauiLMTTemplate.ViewModels.Base
{
    public interface IViewModelBase : IQueryAttributable
    {
        public INavigationService _navigationService { get; }

        public IAsyncRelayCommand _initializeAsyncCommand { get; }

        public bool IsBusy { get; }

        public bool IsInitialized { get; }

        Task InitializeAsync();
    }
}