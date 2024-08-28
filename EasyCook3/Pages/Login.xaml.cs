using EasyCook3.Models.DTO;

namespace EasyCook3.Pages;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

	public async void OnClick(object sender, EventArgs e)
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

		if(UserEntry.Text == "winnions" && PasswordEntry.Text == "123456"/*1==1*/)
		{
			await Navigation.PushAsync(new MainTabbedPage());
		}
	}
}