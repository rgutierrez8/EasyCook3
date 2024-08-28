using EasyCook3.Models;
using EasyCook3.ViewModels;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics.Text;
using Microsoft.Maui.Layouts;

namespace EasyCook3.Pages;


public partial class Liked : ContentPage
{
	private FavsVM _viewModel;
	public Liked()
	{
		InitializeComponent();

		_viewModel = MauiProgram.CreateMauiApp().Services.GetService<FavsVM>();
		BindingContext = _viewModel;
	}

	public async void OnTapped(object sender, EventArgs e)
	{
		if(sender is Element element && element is Frame frame)
		{
            var tapGestureRecognizer = frame.GestureRecognizers.OfType<TapGestureRecognizer>().FirstOrDefault();
            var parameter = tapGestureRecognizer?.CommandParameter;

            if (parameter != null)
            {
                await Navigation.PushModalAsync(new RecipeDetails((int)parameter));
            }
        }
	}
}