using Syncfusion.Licensing;
using Microsoft.Extensions.Configuration;
using EasyCook3.Pages;
using EasyCook3.Data;
using Microsoft.Extensions.DependencyInjection;
using EasyCook3.ViewModels;

namespace EasyCook3
{
    public partial class App : Application
    {
        IConfiguration _configuration;
        public App()
        {
            var serviceProvider = MauiProgram.CreateMauiApp().Services;
            var _configuration = serviceProvider.GetService<IConfiguration>();
            SyncfusionLicenseProvider.RegisterLicense(_configuration["Settings:Syncfusion_ApiKey"]);
            
            

            InitializeComponent();

            MainPage = new LoadPage();

            MessagingCenter.Subscribe<object>(this, "UpdateFav", async (sender) =>
            {
                var favsVM = serviceProvider.GetService<FavsVM>();
                if (favsVM != null)
                {
                    await favsVM.RefreshRecipes();
                }
            });
        }

        protected override async void OnStart()
        {
            base.OnStart();

            // Simula una carga de datos o inicialización
            await Task.Delay(3000);

            // Navega a la página principal
            MainPage = new NavigationPage(new Login(MauiProgram.CreateMauiApp().Services.GetService<AuthService>()));
        }
    }
}
