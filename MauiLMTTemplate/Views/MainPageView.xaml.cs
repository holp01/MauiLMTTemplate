using MauiLMTTemplate.ViewModels;

namespace MauiLMTTemplate.Views;

public partial class MainPageView : ContentPageBase
{
    private readonly MainPageViewModel _viewModel;

    public MainPageView(MainPageViewModel viewModel)
    {
        BindingContext = _viewModel = viewModel;

        InitializeComponent();
    }
}