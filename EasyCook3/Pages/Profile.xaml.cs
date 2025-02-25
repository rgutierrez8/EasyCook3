using Microsoft.Extensions.DependencyInjection;
using EasyCook3.Core.Interfaces;
using EasyCook3.ViewModels;
using System.Xml.XPath;
using Microsoft.Extensions.Configuration;
using EasyCook3.Data;
namespace EasyCook3.Pages;

public partial class Profile : ContentPage
{
    private IServiceProvider serviceProvider;
    private readonly ApiService? _apiService;
    private UserVM? _viewModel;

    public Profile()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        serviceProvider = MauiProgram.CreateMauiApp().Services;
        _viewModel = serviceProvider.GetService<UserVM>();
        _apiService = serviceProvider.GetService<ApiService>();
        BindingContext = _viewModel;

        loadBanner();
	}

    public void loadBanner(string url = null, int? count = null)
    {
        imgBanner.Source = url;
        CountRecipes.Text = "Mostrar Recetas (" + count + ")";
    }

	public async void OnTapped(object sender, EventArgs e)
	{
        await WaitModal(sender, e);
    }

    public async Task WaitModal(object sender, EventArgs e)
    {
        if (sender is Element element && element is Frame frame)
        {
            var tapGestureRecognizer = frame.GestureRecognizers.OfType<TapGestureRecognizer>().FirstOrDefault();
            var parameter = tapGestureRecognizer?.CommandParameter;

            if (parameter != null)
            {
                await Navigation.PushModalAsync(new RecipeDetails((int)parameter));
            }
        }
    }

    public async void OnClicked(object sender, EventArgs e)
    {
        IConfiguration configuration = serviceProvider.GetService<IConfiguration>();
        await Navigation.PushModalAsync(new NewRecipe(configuration, _apiService));
    }
}