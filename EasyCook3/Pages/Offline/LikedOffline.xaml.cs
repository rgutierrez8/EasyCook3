using EasyCook3.Pages.Offline;
using EasyCook3.ViewModels;

namespace EasyCook3.Pages;

public partial class LikedOffline : ContentPage
{
    private FavsVM _viewModel;
    public LikedOffline()
    {
        InitializeComponent();

        _viewModel = MauiProgram.CreateMauiApp().Services.GetService<FavsVM>();
        NavigationPage.SetHasNavigationBar(this, false);
        BindingContext = _viewModel;
    }

    public async void OnTapped(object sender, EventArgs e)
    {
        if (sender is Element element && element is Frame frame)
        {
            var tapGestureRecognizer = frame.GestureRecognizers.OfType<TapGestureRecognizer>().FirstOrDefault();
            var parameter = tapGestureRecognizer?.CommandParameter;

            if (parameter != null)
            {
                await Navigation.PushModalAsync(new RecipeDetailOffline((int)parameter));
            }
        }
    }
}