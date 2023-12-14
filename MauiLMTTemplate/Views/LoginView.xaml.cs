using MauiLMTTemplate.ViewModels;

namespace MauiLMTTemplate.Views;

public partial class LoginView : ContentPageBase
{
    public LoginView(LoginViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}