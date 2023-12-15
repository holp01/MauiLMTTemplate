using MauiLMTTemplate.Models.Expenses;
using MauiLMTTemplate.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLMTTemplate.ViewModels
{
    public partial class ExpenseViewModel : ViewModelBase
    {
        private readonly ObservableCollectionViewModel<Expense> _expenses = new();

        public IReadOnlyList<Expense> Expenses => _expenses;

        public ExpenseViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        public override async Task InitializeAsync()
        {
            //+OPTIONAL: If makes sense to repeat the initialize, after entering this page the first time, comment the code below
            if (IsInitialized)
                return;

            IsInitialized = true;
            //-OPTIONAL

            await IsBusyFor(
                async () =>
                {
                    await Task.Delay(5000);
                    //Simulate api call
                    var projects = new List<Expense>()
                    {
                        new Expense { Id = 1, Name = "Expense 1", Description = "This is the first Expense." },
                        new Expense { Id = 2, Name = "Expense 2", Description = "This is the second Expense." },
                        new Expense { Id = 3, Name = "Expense 3", Description = "This is the third Expense." }
                    };

                    _expenses.ReloadData(projects);
                });
        }

        [RelayCommand]
        private async Task ExpenseTappedAsync(Expense expense)
        {
            await IsBusyFor(
                async () =>
                {
                    await Task.Delay(10);
                    await _navigationService.NavigateToAsync("ExpenseDetail", new Dictionary<string, object> { { "Expense", expense } });
                });
        }
    }
}
