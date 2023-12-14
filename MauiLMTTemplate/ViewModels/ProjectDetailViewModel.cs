using MauiLMTTemplate.Models.Projects;
using MauiLMTTemplate.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLMTTemplate.ViewModels
{
    [QueryProperty(nameof(Project), "Project")]
    public partial class ProjectDetailViewModel : ViewModelBase
    {
        [ObservableProperty]
        private Project _Project;

        public ProjectDetailViewModel(INavigationService navigationService)
            :base(navigationService)
        {
            
        }

    }
}
