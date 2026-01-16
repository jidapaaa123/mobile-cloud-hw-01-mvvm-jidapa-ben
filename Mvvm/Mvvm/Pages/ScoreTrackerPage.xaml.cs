namespace Mvvm.Pages;

public partial class ScoreTrackerPage : ContentPage
{
	public ScoreTrackerPage(ScoreTrackerPageModel model)
	{
		InitializeComponent();
        BindingContext = model;
    }
}