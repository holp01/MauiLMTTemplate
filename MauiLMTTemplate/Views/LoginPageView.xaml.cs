using MauiLMTTemplate.ViewModels;

namespace MauiLMTTemplate.Views;

public partial class LoginPageView : ContentPageBase
{
    public LoginPageView(LoginViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}