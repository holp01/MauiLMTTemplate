using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLMTTemplate.ViewModels.Base
{
    public abstract partial class ViewModelBase : ObservableObject, IViewModelBase
    {
        private long _isBusy;

        public bool IsBusy => Interlocked.Read(ref _isBusy) > 0;

        [ObservableProperty]
        private bool _isInitialized;

        public IAsyncRelayCommand _initializeAsyncCommand { get; }

        public INavigationService _navigationService { get; }

        public ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;

            _initializeAsyncCommand =
                new AsyncRelayCommand(
                    async () =>
                    {
                        await IsBusyFor(InitializeAsync);
                        IsInitialized = true;
                    },
                    AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler);
        }

        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task IsBusyFor(Func<Task> unitOfWork)
        {
            Interlocked.Increment(ref _isBusy);
            OnPropertyChanged(nameof(IsBusy));

            try
            {
                await unitOfWork();
            }
            finally
            {
                Interlocked.Decrement(ref _isBusy);
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {

        }
    }
}
