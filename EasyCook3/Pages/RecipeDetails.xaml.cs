using EasyCook3.ViewModels;
using EasyCook3.Core.Interfaces;
using Microsoft.Maui.Controls;
using EasyCook3.Models;
using EasyCook3.Models.DTO;
//using static Kotlin.Jvm.Internal.Ref;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyCook3.Pages;

public partial class RecipeDetails : ContentPage
{	
    public RecipeDetails(int recipeId)
	{
		InitializeComponent();

        var serviceProvider = MauiProgram.CreateMauiApp().Services;
        var recipeService = serviceProvider.GetRequiredService<IRecipeService>();
        var favService = serviceProvider.GetRequiredService<IFavService>();
        var userService = serviceProvider.GetRequiredService<IUserService>();
        RecipeVM recipeVM = new RecipeVM(recipeId, recipeService, favService, userService);

        BindingContext = recipeVM;


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

    public void OnClickedAddFav(object sender, EventArgs args)
    {
        btnDelFav.Opacity = 1;
        btnDelFav.IsVisible = true;
        btnAddFav.Opacity = 0;
        btnAddFav.IsVisible = false;

        var id = GetCommandParamenter(sender);

        // FALTA HACER FUNCION PARA AGREGAR A FAVORITOS
    }
    public void OnClickedDeleteFav(object sender, EventArgs args)
    {
        btnAddFav.Opacity = 1;
        btnAddFav.IsVisible = true;
        btnDelFav.Opacity = 0;
        btnDelFav.IsVisible = false;

        var id = GetCommandParamenter(sender);

        // FALTA HACER FUNCION PARA ELIMINAR DE FAVORITOS
    }

    public int GetCommandParamenter(object sender)
    {
        int parameter = 0;

        if(sender is Button button)
        {
            parameter = (int)button.CommandParameter;
        }

        return parameter;

    }
}