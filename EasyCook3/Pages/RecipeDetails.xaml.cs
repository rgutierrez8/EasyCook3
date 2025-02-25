using EasyCook3.ViewModels;
using EasyCook3.Core.Interfaces;
using Microsoft.Maui.Controls;
using EasyCook3.Models;
using EasyCook3.Models.DTO;
//using static Kotlin.Jvm.Internal.Ref;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls.Compatibility;
using MauiPopup;
using EasyCook3.PopUps;
using EasyCook3.Data;

namespace EasyCook3.Pages;

public partial class RecipeDetails : ContentPage
{
    private readonly IFavService _favService;
    private readonly IRecipeService _recipeService;
    private readonly RecipeVM _recipeVM;
    private readonly FavsVM _favVM;
    private readonly MySQLiService _mydb;

    public int _recipeId;
    public RecipeDetails(int recipeId)
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        var serviceProvider = MauiProgram.CreateMauiApp().Services;
        _recipeService = serviceProvider.GetRequiredService<IRecipeService>();
        _favService = serviceProvider.GetRequiredService<IFavService>();
        var userService = serviceProvider.GetRequiredService<IUserService>();
        _recipeVM = new RecipeVM(_recipeService, _favService, userService);
        _favVM = serviceProvider.GetService<FavsVM>();
        _mydb = serviceProvider.GetService<MySQLiService>();

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

    public async void OnClickedAddFav(object sender, EventArgs args)
    {
        var id = GetCommandParamenter(sender);

        FavDTO fav = new FavDTO()
        {
            RecipeId = id,
        };

        var response = await FavTask(method: "new", fav: fav);

        if(response)
        {
            AddRecipeMySQLi(id);
            LoadRecipeData(_recipeVM, id);
        }
    }

    public async void OnClickedDeleteFav(object sender, EventArgs args)
    {
        var id = GetCommandParamenter(sender);
        FavDTO fav = new FavDTO()
        {
            RecipeId = id,
        };

        var response = await FavTask(method: "del", fav: fav);

        if (response)
        {
            DeleteRecipeMySQLi(id);
            MessagingCenter.Send(this, "UpdateFav");
            _favVM.RefreshRecipes();
            LoadRecipeData(_recipeVM, id);
        }
    }

    public async Task<bool> FavTask(string method, FavDTO fav)
    {
        if (method == "new")
        {
            return await _favService.NewFav(fav);
        }
        else
        {
            return await _favService.DeleteFav(fav);
        }
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

    public async void OnAddComment(object sender, EventArgs args)
    {
        await PopupAction.DisplayPopup(new NewCommentPopup(_recipeId));
        LoadRecipeData(_recipeVM, _recipeId);
    }

    public async void AddRecipeMySQLi(int id)
    {
        if (!await _mydb.FinRecipeById(id))
        {
            var item = await _recipeService.GetRecipe(id);

            Recipe recipeCopy = new Recipe()
            {
                Id = item.Id,
                Title = item.Title,
                Descripe = item.Describe,
                MainImage = item.MainImage,
                Img2 = item.Img2,
                Img3 = item.Img3,
                Img4 = item.Img4,
                NeededTime = item.NeededTime,
                Username = item.Username,
                Like = item.Like,
                DontLike = item.dontLike
            };

            foreach (var item2 in item.ListIngredients)
            {
                Ingredient ingredient = new Ingredient()
                {
                    Id = item.Id,
                    Amount = item2.Amount,
                    IngredientName = item2.IngredientName
                };

                await _mydb.AddIngredientAsync(ingredient);
            }

            foreach (var item3 in item.ListSteps)
            {
                Step step = new Step()
                {
                    Id = item.Id,
                    NumberStep = item3.NumberStep,
                    Description = item3.Describe
                };

                await _mydb.AddStepAsync(step);
            }

            foreach (var item4 in item.CommentList)
            {
                Comment comment = new Comment()
                {
                    RecipeId = item.Id,
                    Username = item4.Username,
                    Description = item4.Describe
                };

                await _mydb.AddCommentAsync(comment);
            }

            await _mydb.AddRecipeAsync(recipeCopy);
        }
    }
    public async void DeleteRecipeMySQLi(int id)
    {
        _mydb.DeleteRecipe(id);
        _mydb.DeleteIngredient(id);
        _mydb.DeleteSteps(id);
        _mydb.DeleteComment(id);
    }

}