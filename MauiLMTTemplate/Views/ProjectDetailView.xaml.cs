using MauiLMTTemplate.ViewModels;

namespace MauiLMTTemplate.Views;

public partial class ProjectDetailView : ContentPageBase
{
	public ProjectDetailView(ProjectDetailViewModel viewModel)
	{
		BindingContext = viewModel;
        InitializeComponent();
	}
}