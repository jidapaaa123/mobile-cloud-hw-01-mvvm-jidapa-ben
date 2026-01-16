namespace Mvvm.Pages;

public partial class HelloWorld : ContentPage
{
    // Parameterless constructor required for XAML instantiation (DataTemplate)
    public HelloWorld(MainPageModel model)
    {
        InitializeComponent();
        BindingContext = model;
    }
}
