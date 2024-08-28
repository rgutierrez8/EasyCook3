using EasyCook3.Models.DTO;
using System.Xml.XPath;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;
using Newtonsoft.Json;

namespace EasyCook3.Pages;

public partial class NewRecipe : ContentPage
{
    private readonly IConfiguration _configuration;

    List<FileResult> list = new List<FileResult>();
    List<string> ListImg = new List<string>();
    FileResult Img1;
    FileResult Img2;
    FileResult Img3;
    FileResult Img4;
    private int countEntries = 4;
    private int countStepEntries = 4;
    public NewRecipe(IConfiguration configuration)
	{
		InitializeComponent();
        _configuration = configuration;

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
                FileTypes = FilePickerFileType.Images // Puedes especificar los tipos de archivos permitidos
            });

            if (result != null)
            {
                if (img == 1) 
                { 
                    FileNameLabel.Text = $"{result.FileName}"; 
                    Img1 = result;
                }
                if (img == 2) 
                { 
                    FileNameLabelImg2.Text = $"{result.FileName}"; 
                    Img2 = result;
                }
                if (img == 3) 
                { 
                    FileNameLabelImg3.Text = $"{result.FileName}"; 
                    Img3 = result;
                }
                if (img == 4) { 
                    FileNameLabelImg4.Text = $"{result.FileName}"; 
                    Img4 = result;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task LoadPicker()
    {
        var urlImgBB = "https://api.imgbb.com/1/upload?key=" + _configuration["Settings:imgBB_ApiKey"];

        foreach (var result in list)
        {
            if (result != null)
            {
                try
                {
                    using var stream = await result.OpenReadAsync();
                    var content = new MultipartFormDataContent();
                    var imageContent = new StreamContent(stream);
                    imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                    content.Add(imageContent, "image", result.FileName);

                    using var client = new HttpClient();
                    var response = await client.PostAsync(urlImgBB, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var JsonResult = JsonConvert.DeserializeObject<dynamic>(responseContent);
                        ListImg.Add(JsonResult.data.image.url.ToString());
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error al subir la imagen: {response.ReasonPhrase}");
                        Console.WriteLine(errorContent);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
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

        foreach (var grid  in StackIngs.Children.OfType<Grid>().ToList())
        {
            var entryIng = grid.Children[0] as Entry;
            var entryAmount = grid.Children[1] as Entry;

            if(String.IsNullOrWhiteSpace(entryIng.Text) || String.IsNullOrWhiteSpace(entryAmount.Text))
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
       
        foreach(var item  in StackSteps.Children.OfType<Editor>().ToList())
        {

            if (String.IsNullOrWhiteSpace(item.Text))
            {
                break;
            }

            StepDTO step = new StepDTO()
            {
                NumberStep = stepNumber,
                Description = item.Text,
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
        ListImg.Clear();
        list.Clear();

        var listIngredients = GetIngredients();
        var listSteps = GetSteps();

        if(Img1 != null) list.Add(Img1);
        if(Img2 != null) list.Add(Img2);
        if(Img3 != null) list.Add(Img3);
        if(Img4 != null) list.Add(Img4);

        await LoadPicker();

        var title = EntryTitle.Text;
        var description = EntryDescription.Text;
        var time = EntryTime.Text;

        if (!String.IsNullOrWhiteSpace(title) && !String.IsNullOrWhiteSpace(description) && !String.IsNullOrWhiteSpace(time))
        {
            NewRecipeDTO recipe = new NewRecipeDTO()
            {
                Title = title,
                Description = description,
                Time = time,
                MainImage =  1 <= ListImg.Count ? ListImg[0] : null,
                Img2 = 2 <= ListImg.Count ? ListImg[1] : null,
                Img3 = 3 <= ListImg.Count ? ListImg[2] : null,
                Img4 = 4 <= ListImg.Count ? ListImg[3] : null
            };
        }
    }

    public async void OnClickCancel(object sender, EventArgs e) 
    {
        await Navigation.PopModalAsync();
    }

    #endregion

}