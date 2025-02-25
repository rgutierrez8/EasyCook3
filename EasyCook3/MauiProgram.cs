using EasyCook3.Core.Helpers;
using EasyCook3.Core.Interfaces;
using EasyCook3.Core;
using EasyCook3.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Syncfusion.Maui.Core.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using EasyCook3.Data;


namespace EasyCook3
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddSingleton<IRecipeService, RecipeService>();
            builder.Services.AddSingleton<IIngredientService, IngredientsService>();
            builder.Services.AddSingleton<IStepService, StepService>();
            builder.Services.AddSingleton<ICommentService, CommentService>();
            builder.Services.AddSingleton<IFavService, FavService>();
            builder.Services.AddSingleton<IMapper, Mapper>();   
            builder.Services.AddScoped<ApiService>();
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddSingleton<MySQLiService>();
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            builder.Services.AddSingleton<UserVM>();
            builder.Services.AddSingleton<ListRecipeVM>();
            builder.Services.AddSingleton<RecipeVM>();
            builder.Services.AddSingleton<FavsVM>();


            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("EasyCook3.appsettings.json");
            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            builder.Configuration.AddConfiguration(config);

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
