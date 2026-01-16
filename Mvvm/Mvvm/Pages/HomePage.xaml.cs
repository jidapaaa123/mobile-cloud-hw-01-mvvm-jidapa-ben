namespace Mvvm.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private async void NewGame_Clicked(object? sender, EventArgs e)
    {
        // Navigate to the GameSetupPage route declared in AppShell
        await Shell.Current.GoToAsync("///gameSetup");
    }
}