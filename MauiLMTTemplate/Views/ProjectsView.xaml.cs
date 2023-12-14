using MauiLMTTemplate.ViewModels;

namespace MauiLMTTemplate.Views;

public partial class ProjectsView : ContentPageBase
{
    public ProjectsView(ProjectViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}