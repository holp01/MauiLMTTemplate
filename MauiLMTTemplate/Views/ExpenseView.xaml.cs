using MauiLMTTemplate.ViewModels;

namespace MauiLMTTemplate.Views;

public partial class ExpenseView : ContentPageBase
{
    public ExpenseView(ExpenseViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}