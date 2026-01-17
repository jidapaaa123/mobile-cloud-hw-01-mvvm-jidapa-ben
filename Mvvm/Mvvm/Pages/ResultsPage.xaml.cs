namespace Mvvm.Pages;

public partial class ResultsPage : ContentPage
{
	public ResultsPage(ResultsPageModel model)
	{
		InitializeComponent();
		BindingContext = model;
    }
}