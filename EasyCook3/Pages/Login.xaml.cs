using EasyCook3.Data;
using EasyCook3.Models.DTO;
using EasyCook3.PopUps;
using MauiPopup;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;


namespace EasyCook3.Pages;

public partial class Login : ContentPage
{
	private readonly MySQLiService _mydb;
	private readonly AuthService _authService;
	private readonly IConfiguration _configuration = MauiProgram.CreateMauiApp().Services.GetService<IConfiguration>();
	public Login(AuthService authService)
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
		var serviceProvider = MauiProgram.CreateMauiApp().Services;

        _authService = authService;

		_mydb = serviceProvider.GetService<MySQLiService>();

	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //await _mydb.InitializeAsync();
    }

    public async void OnClick(object sender, EventArgs e)
	{
		await LoginTask();
	}

    public async Task LoginTask()
	{

		if (String.IsNullOrWhiteSpace(UserEntry.Text) || String.IsNullOrWhiteSpace(PasswordEntry.Text))
		{
			await DisplayAlert("ERROR", "USUARIO Y PASSWORD REQUERIDOS", "OK");
		}

		UserLoginDTO user = new UserLoginDTO()
		{
			Username = UserEntry.Text,
			Password = PasswordEntry.Text,
        };

		if (CheckConnectivity())
		{
			var loginSuccess = await _authService.LoginAsync(user);
			if (loginSuccess)
			{
				try
				{
                    await _mydb.DropTableUserAsync();
                    await _mydb.DropTableRecipeAsync();
                    await _mydb.DropTableIngredientAsync();
                    await _mydb.DropTableStepAsync();
                    await _mydb.DropTableCommentAsync();
                }
				catch (Exception ex)
				{ Console.WriteLine(ex.Message); }

				var users = await _mydb.GetAllUser();
				var recipes = await _mydb.GetRecipesAsync();
				var ingredients = await _mydb.getallingredient();
				var steps = await _mydb.getallstep();
				var coments = await _mydb.getallcomment();

				user.Password = await _mydb.EncryptPassSha25(user.Password);
				await _mydb.AddUserAsync(user);
				Application.Current.MainPage = new NavigationPage(new MainTabbedPage());
			}
			else
			{
				await DisplayAlert("ALERT", "Usuario o contraseña incorrectos", "OK");
			}
		}
		else
		{
            if (_mydb.FindUser(user) != null)
			{
				await DisplayAlert("SIN CONEXIÓN", "Entraste en modo offline", "OK");
				Application.Current.MainPage = new NavigationPage(new LikedOffline());
			}
		}

    }

	public async void OnClickedNew(object sender, EventArgs e)
	{
		await PopupAction.DisplayPopup(new NewUserPopup());
	}

	public bool CheckConnectivity()
	{
		var Current = Connectivity.Current;

		if (Current.NetworkAccess == NetworkAccess.Internet)
		{
			return true;
		}

		return false;
	}
}