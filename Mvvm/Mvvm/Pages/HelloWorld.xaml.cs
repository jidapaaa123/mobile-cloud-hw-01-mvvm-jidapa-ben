namespace Mvvm.Pages;

public partial class HelloWorld : ContentPage
{
    // Parameterless constructor required for XAML instantiation (DataTemplate)
    public HelloWorld(MainPageModel model)
    {
        InitializeComponent();
        BindingContext = model;
    }

    //// Optional constructor for DI or when a view model is provided
    //public HelloWorld(MainPageModel model) : this()
    //{
    //    BindingContext = model;
    //}
}
