
namespace Mvvm.Pages;

public partial class GameSetupPage : ContentPage
{
	public GameSetupPage(GameSetupPageModel model)
	{
        InitializeComponent();
        BindingContext = model;
    }

    //private async void StartGame_Clicked(object? sender, EventArgs e)
    //{
    //    // Navigate to the GameSetupPage route declared in AppShell
    //    await Shell.Current.GoToAsync("///scoreTracker");
    //}

    //private async void AddPlayer_Clicked(object? sender, EventArgs e)
    //{
    //    throw new NotImplementedException();
    //}
}