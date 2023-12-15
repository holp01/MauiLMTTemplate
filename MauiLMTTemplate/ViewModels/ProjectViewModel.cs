using MauiLMTTemplate.Models.Projects;
using MauiLMTTemplate.ViewModels.Base;
using MauiLMTTemplate.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLMTTemplate.ViewModels
{
    public partial class ProjectViewModel : ViewModelBase
    {
        private readonly ObservableCollectionViewModel<Project> _projects = new();

        public IReadOnlyList<Project> Projects => _projects;

        [ObservableProperty]
        private Project _selectedProject;

        public ProjectViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        public override async Task InitializeAsync()
        {
            //+OPTIONAL: If makes sense to repeat the initialize, after entering this page the first time, comment the code below
            if (IsInitialized)
                return;

            IsInitialized = true;
            //-OPTIONAL

            await IsBusyFor(
                async () =>
                {
                    //Simulate api call
                    await Task.Delay(5000);
                    var projects = new List<Project>()
                    {
                        new Project { Id = 1, Name = "Project 1", Description = "This is the first project." },
                        new Project { Id = 2, Name = "Project 2", Description = "This is the second project." },
                        new Project { Id = 3, Name = "Project 3", Description = "This is the third project." }
                    };

                    _projects.ReloadData(projects);
                });
        }

        [RelayCommand]
        private async Task ProjectTappedAsync(Project project)
        {
            await IsBusyFor(
                async () =>
                {
                    await Task.Delay(10);
                    await _navigationService.NavigateToAsync("ProjectDetail", new Dictionary<string, object> { { "Project", project } });
                });

            //Unselect Project due to SelectionMode
            SelectedProject = null;
        }
    }
}
