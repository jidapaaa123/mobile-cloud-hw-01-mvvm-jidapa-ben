namespace Mvvm.Pages;

public partial class GameSetupPage : ContentPage
{
	public GameSetupPage()
	{
		InitializeComponent();
	}

    private async void StartGame_Clicked(object? sender, EventArgs e)
    {
        // Navigate to the GameSetupPage route declared in AppShell
        await Shell.Current.GoToAsync("///scoreTracker");
    }
}