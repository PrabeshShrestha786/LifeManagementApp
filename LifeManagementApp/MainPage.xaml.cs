using LifeManagementApp.ViewModels;

namespace LifeManagementApp;

public partial class MainPage : ContentPage
{
    private readonly NotesViewModel viewModel;

    public MainPage(NotesViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.InitializeAsync();
    }
}
