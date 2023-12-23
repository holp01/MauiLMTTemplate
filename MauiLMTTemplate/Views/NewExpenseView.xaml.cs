using MauiLMTTemplate.ViewModels;

namespace MauiLMTTemplate.Views;

public partial class NewExpenseView : ContentPageBase
{
	public NewExpenseView(NewExpenseViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
	}
}