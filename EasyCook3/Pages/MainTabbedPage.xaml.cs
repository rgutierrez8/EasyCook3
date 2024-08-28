using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyCook3.Pages;

public partial class MainTabbedPage : TabbedPage
{
    public MainTabbedPage()
    {
        InitializeComponent();

        var home = new MainPage()
        {
            //Title = "Home",
            IconImageSource = "home3.png"
        };
        /*var recipes = new RecipeDetails()
        {
            //Title = "Recipes",
            IconImageSource = "list.png"
        };*/
        var liked = new Liked()
        {
            //Title = "Like's",
            IconImageSource = "like.png"
        };
        var profile = new Profile()
        {
            //Title = "Profile",
            IconImageSource = "profile.png"
        };

        this.Children.Add(home);
        //this.Children.Add(recipes);
        this.Children.Add(liked);
        this.Children.Add(profile);
    }
}