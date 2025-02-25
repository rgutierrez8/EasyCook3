using EasyCook3.Core.Interfaces;
using EasyCook3.Data;
using EasyCook3.Models.DTO;
using MauiPopup;
using MauiPopup.Views;

namespace EasyCook3.PopUps;

public partial class NewUserPopup : BasePopupPage
{
    private readonly IUserService _userService;
    private string pic, banner;
	public NewUserPopup()
	{
		InitializeComponent();

        var serviceProvider = MauiProgram.CreateMauiApp().Services;
        _userService = serviceProvider.GetService<IUserService>();
	}

	public void OnPickFileClicked (object sender, EventArgs e)
	{
        listImg(1);
	}
    public void OnPickFileClickedBanner(object sender, EventArgs e)
    {
        listImg(2);
    }

    public async void listImg(int img)
	{
        try
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Por favor selecciona un archivo",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null)
            {
                if (img == 1)
                {
                    FilePicLabel.Text = $"{result.FileName}";
                    pic = await ConvertToBase64(result);
                }
                if (img == 2)
                {
                    FileBannerLabel.Text = $"{result.FileName}";
                    banner = await ConvertToBase64(result);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task<string> ConvertToBase64(FileResult img)
    {
        string base64Image;
        var stream = await img.OpenReadAsync();

        using (var memoryStream = new MemoryStream())
        {
            await stream.CopyToAsync(memoryStream);
            var imageBytes = memoryStream.ToArray();
            return base64Image = Convert.ToBase64String(imageBytes);
        };
    }

    public async void OnAccept(object sender, EventArgs e)
    {
        if (!String.IsNullOrWhiteSpace(NameEntry.Text) && !String.IsNullOrWhiteSpace(LastNameEntry.Text) && !String.IsNullOrWhiteSpace(EmailEntry.Text) 
            && !String.IsNullOrWhiteSpace(UserEntry.Text) && !String.IsNullOrWhiteSpace(PassEntry.Text))
        {
            NewUserDTO user = new NewUserDTO()
            {
                FirstName = NameEntry.Text,
                LastName = LastNameEntry.Text,
                Email = EmailEntry.Text,
                Username = UserEntry.Text,
                Pass = PassEntry.Text,
                Pic = pic,
                Banner = banner,
            };

            var response = await _userService.NewUser(user);

            if (response == System.Net.HttpStatusCode.OK)
            {
                await DisplayAlert("Éxito", "Usuario registrado correctamente", "OK");
                PopupAction.ClosePopup(this);
            }
            if(response == System.Net.HttpStatusCode.InternalServerError)
            {
                await DisplayAlert("ERROR", "El EMAIL o USUARIO ingresado ya existe", "OK");
            }
            else
            {
                await DisplayAlert("ERROR!", "Usuario no registrado", "OK");
            }
        }
    }
    
    public void OnCancel(object sender, EventArgs e) 
    {
        PopupAction.ClosePopup(this);
    }
}