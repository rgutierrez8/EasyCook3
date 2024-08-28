using Syncfusion.Licensing;
using Microsoft.Extensions.Configuration;
using EasyCook3.Pages;

namespace EasyCook3
{
    public partial class App : Application
    {
        public App()
        {
            var serviceProvider = MauiProgram.CreateMauiApp().Services;
            var _configuration = serviceProvider.GetService<IConfiguration>();
            SyncfusionLicenseProvider.RegisterLicense(_configuration["Settings:Syncfusion_ApiKey"]);

            InitializeComponent();

            MainPage = new LoadPage();
        }

        protected override async void OnStart()
        {
            base.OnStart();

            // Simula una carga de datos o inicialización
            await Task.Delay(3000);

            // Navega a la página principal
            MainPage = new NavigationPage(new Login());
        }
    }
}
