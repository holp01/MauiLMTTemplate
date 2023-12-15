using MauiLMTTemplate.Models.Expenses;
using MauiLMTTemplate.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLMTTemplate.ViewModels
{
    [QueryProperty(nameof(Expense), "Expense")]
    public partial class ExpenseDetailViewModel : ViewModelBase
    {
        [ObservableProperty]
        private Expense _Expense;

        public ExpenseDetailViewModel(INavigationService navigationService)
            :base(navigationService)
        {
            
        }

        public override async Task InitializeAsync()
        {
            //OPTIONAL: Code here if needed to make an Api call, for example, for the project detail using the Id.
            await base.InitializeAsync();
        }
    }
}
