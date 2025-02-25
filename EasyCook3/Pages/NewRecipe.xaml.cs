using EasyCook3.Models.DTO;
using System.Xml.XPath;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text;
using EasyCook3.Data;

namespace EasyCook3.Pages;

public partial class NewRecipe : ContentPage
{
    private readonly IConfiguration _configuration;
    private readonly ApiService _apiService;

    List<FileResult> list = new List<FileResult>();
    List<string> ListImg = new List<string>();
    FileResult Img1;
    FileResult Img2;
    FileResult Img3;
    FileResult Img4;
    string img1Converted, img2Converted, img3Converted, img4Converted;
    private int countEntries = 4;
    private int countStepEntries = 4;
    public NewRecipe(IConfiguration configuration, ApiService apiService)
    {
        InitializeComponent();
        _configuration = configuration;
        _apiService = apiService;

        Img1 = null;
        Img2 = null;
        Img3 = null;
        Img4 = null;
    }

    #region EVENTOS DE IMAGEN
    private void OnPickFileClicked(object sender, EventArgs e)
    {
        listImg(1);
    }

    private void OnPickFileClickedTwo(object sender, EventArgs e)
    {
        listImg(2);
    }
    private void OnPickFileClickedThree(object sender, EventArgs e)
    {
        listImg(3);
    }
    private void OnPickFileClickedFour(object sender, EventArgs e)
    {
        listImg(4);
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
                    FileNameLabel.Text = $"{result.FileName}";
                    Img1 = result;
                    img1Converted = await ConvertToBase64(result);
                }
                if (img == 2)
                {
                    FileNameLabelImg2.Text = $"{result.FileName}";
                    Img2 = result;
                    img2Converted = await ConvertToBase64(result);
                }
                if (img == 3)
                {
                    FileNameLabelImg3.Text = $"{result.FileName}";
                    Img3 = result;
                    img3Converted = await ConvertToBase64(result);
                }
                if (img == 4)
                {
                    FileNameLabelImg4.Text = $"{result.FileName}";
                    Img4 = result;
                    img4Converted = await ConvertToBase64(result);
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

    #endregion

    #region EVENTOS DE INGREDIENTE

    public void OnAddIng(object sender, EventArgs e)
    {
        Grid grid = new Grid()
        {
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) },
                new ColumnDefinition  { Width = new GridLength(1, GridUnitType.Star) }
            },
            Margin = 20
        };

        Entry entryIng = new()
        {
            Placeholder = countEntries + "° Ingrediente",
            FontSize = 18,
            TextColor = Colors.White,
            AutomationId = "Ing" + countEntries
        };
        grid.SetColumn(entryIng, 0);
        Entry entryAmount = new()
        {
            Placeholder = "Cantidad",
            FontSize = 18,
            TextColor = Colors.White,
            AutomationId = "Amount" + countEntries
        };
        grid.SetColumn(entryAmount, 1);

        grid.Children.Add(entryIng);
        grid.Children.Add(entryAmount);
        StackIngs.Add(grid);

        countEntries++;
    }

    public List<IngredientsDTO> GetIngredients()
    {
        List<IngredientsDTO> ingredientsDTOs = new List<IngredientsDTO>();

        foreach (var grid in StackIngs.Children.OfType<Grid>().ToList())
        {
            var entryIng = grid.Children[0] as Entry;
            var entryAmount = grid.Children[1] as Entry;

            if (String.IsNullOrWhiteSpace(entryIng.Text) || String.IsNullOrWhiteSpace(entryAmount.Text))
            {
                break;
            }

            IngredientsDTO ing = new IngredientsDTO()
            {
                IngredientName = entryIng.Text,
                Amount = entryAmount.Text,
            };

            ingredientsDTOs.Add(ing);
        }

        return ingredientsDTOs;
    }

    #endregion

    #region EVENTOS DE PROCEDIMIENTOS

    public void OnAddStep(object sender, EventArgs e)
    {
        Editor editor = new Editor()
        {
            Placeholder = countStepEntries + "° Paso de procedimiento",
            TextColor = Colors.White,
            FontSize = 18,
            HeightRequest = 100,
            Margin = new Thickness(20, 0)
        };

        StackSteps.Children.Add(editor);
        countStepEntries++;
    }

    public List<StepDTO> GetSteps()
    {
        var stepNumber = 1;
        List<StepDTO> StepDTOs = new List<StepDTO>();

        foreach (var item in StackSteps.Children.OfType<Editor>().ToList())
        {

            if (String.IsNullOrWhiteSpace(item.Text))
            {
                break;
            }

            StepDTO step = new StepDTO()
            {
                NumberStep = stepNumber,
                Describe = item.Text,
            };

            StepDTOs.Add(step);
            stepNumber++;
        }

        return StepDTOs;
    }

    #endregion

    #region EVENTOS BOTONES

    public async void OnClickSave(object sender, EventArgs e)
    {

        var listIngredients = GetIngredients();
        var listSteps = GetSteps();

        var title = EntryTitle.Text;
        var description = EntryDescription.Text;
        var time = EntryTime.Text;

        if (!String.IsNullOrWhiteSpace(title) && !String.IsNullOrWhiteSpace(description) && !String.IsNullOrWhiteSpace(time))
        {
            NewRecipeDTO recipe = new NewRecipeDTO()
            {
                Title = title,
                Describe = description,
                NeededTime = time,
                MainImage = !string.IsNullOrEmpty(img1Converted) ? img1Converted : null,
                Img2 = !string.IsNullOrEmpty(img2Converted) ? img2Converted : null,
                Img3 = !string.IsNullOrEmpty(img3Converted) ? img3Converted : null,
                Img4 = !string.IsNullOrEmpty(img4Converted) ? img4Converted : null,
                Ingredients = listIngredients,
                Steps = listSteps,
            };

            var json = System.Text.Json.JsonSerializer.Serialize(recipe);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _apiService.PostAsync("Recipes/New", content);
            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Datos cargados correctamente", "OK");
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Error", "No se pudo subir la imagen", "OK");
            }
        }

    }

    public async void OnClickCancel(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    #endregion

}