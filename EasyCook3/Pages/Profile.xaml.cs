using Microsoft.Extensions.DependencyInjection;
using EasyCook3.Core.Interfaces;
using EasyCook3.ViewModels;
using System.Xml.XPath;
using Microsoft.Extensions.Configuration;
namespace EasyCook3.Pages;

public partial class Profile : ContentPage
{
    private IServiceProvider serviceProvider;

    public Profile()
	{
		InitializeComponent();

        serviceProvider = MauiProgram.CreateMauiApp().Services;
        var _viewModel = serviceProvider.GetService<UserVM>();
        BindingContext = _viewModel;

        loadBanner();
	}

	public void loadBanner(string url = "default_banner.png")
	{
		imgBanner.Source = url;
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
        await Navigation.PushModalAsync(new NewRecipe(configuration));
    }
}