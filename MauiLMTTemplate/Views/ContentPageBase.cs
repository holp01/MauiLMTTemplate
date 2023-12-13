using MauiLMTTemplate.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLMTTemplate.Views
{
    public abstract class ContentPageBase : ContentPage
    {
        public ContentPageBase()
        {
            NavigationPage.SetBackButtonTitle(this, string.Empty);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is not IViewModelBase ivmb)
            {
                return;
            }

            await ivmb.InitializeAsyncCommand.ExecuteAsync(null);
        }
    }
}
