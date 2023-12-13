namespace MauiLMTTemplate.ViewModels.Base
{
    public interface IViewModelBase : IQueryAttributable
    {
        public IAsyncRelayCommand InitializeAsyncCommand { get; }

        public bool IsBusy { get; }

        public bool IsInitialized { get; }

        Task InitializeAsync();
    }
}