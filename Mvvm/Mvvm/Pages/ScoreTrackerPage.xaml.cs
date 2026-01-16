namespace Mvvm.Pages;

public partial class ScoreTrackerPage : ContentPage
{
	public ScoreTrackerPage()
	{
		InitializeComponent();
	}

    private async void EndGame_Clicked(object? sender, EventArgs e)
    {
        // Navigate to the GameSetupPage route declared in AppShell
        await Shell.Current.GoToAsync("///results");
    }
}