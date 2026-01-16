using CommunityToolkit.Mvvm.Input;
using Mvvm.Models;

namespace Mvvm.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}