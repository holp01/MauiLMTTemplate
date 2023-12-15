using MauiLMTTemplate.ViewModels;

namespace MauiLMTTemplate.Views;

public partial class ExpenseDetailView : ContentPageBase
{
	public ExpenseDetailView(ExpenseDetailViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}