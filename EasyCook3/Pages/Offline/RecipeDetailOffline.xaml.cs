using EasyCook3.Core.Interfaces;
using EasyCook3.PopUps;
using EasyCook3.ViewModels;
using MauiPopup;
using Syncfusion.Maui.Core.Carousel;

namespace EasyCook3.Pages.Offline;

public partial class RecipeDetailOffline : ContentPage
{
    private readonly IFavService _favService;
    private readonly IRecipeService _recipeService;
    private readonly RecipeVM _recipeVM;
    private readonly FavsVM _favVM;

    public int _recipeId;
    public RecipeDetailOffline(int recipeId)
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        var serviceProvider = MauiProgram.CreateMauiApp().Services;
        _recipeService = serviceProvider.GetRequiredService<IRecipeService>();
        _favService = serviceProvider.GetRequiredService<IFavService>();
        var userService = serviceProvider.GetRequiredService<IUserService>();
        _recipeVM = new RecipeVM(_recipeService, _favService, userService);
        _favVM = serviceProvider.GetService<FavsVM>();
        _recipeId = recipeId;
        BindingContext = _recipeVM;

        LoadRecipeData(_recipeVM, recipeId);

    }

    public async void LoadRecipeData(RecipeVM recipeVM, int recipeId)
    {
        await recipeVM.LoadRecipe(recipeId);

        #region AGREGAR IMAGENES AL CARRUSEL

        var list = new List<string>();

        if (recipeVM.RecipeDetail.MainImage != "") list.Add(recipeVM.RecipeDetail.MainImage);
        if (recipeVM.RecipeDetail.Img2 != "") list.Add(recipeVM.RecipeDetail.Img2);
        if (recipeVM.RecipeDetail.Img3 != "") list.Add(recipeVM.RecipeDetail.Img3);
        if (recipeVM.RecipeDetail.Img4 != "") list.Add(recipeVM.RecipeDetail.Img4);

        if (list == null) list.Add("img_not_found.png");

        carousel.ItemsSource = list;

        #endregion

        StepsFrame.Opacity = 0;
    }
    public void onBtnIngClick(object sender, EventArgs args)
    {
        btnIng.Background = Colors.Green;
        btnProc.Background = Colors.Transparent;
        btnProc.TextColor = Colors.White;
        StepsFrame.Opacity = 0;
        IngredFrame.Opacity = 1;
    }

    public void onBtnProcClick(object sender, EventArgs args)
    {
        btnProc.Background = Colors.Green;
        btnIng.Background = Colors.Transparent;
        btnIng.TextColor = Colors.White;
        StepsFrame.Opacity = 1;
        IngredFrame.Opacity = 0;
    }

    public int GetCommandParamenter(object sender)
    {
        int parameter = 0;

        if (sender is Button button)
        {
            parameter = (int)button.CommandParameter;
        }

        return parameter;
    }
}