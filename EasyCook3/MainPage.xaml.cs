using EasyCook3.ViewModels;
using EasyCook3.Pages;

namespace EasyCook3
{
    public partial class MainPage : ContentPage
    {

        private ListRecipeVM _viewModel;
        public MainPage()
        {
            InitializeComponent();
            _viewModel = MauiProgram.CreateMauiApp().Services.GetService<ListRecipeVM>();
            BindingContext = _viewModel;
        }

        public async void OnTapped(object sender, EventArgs e)
        {
            await WaitModal(sender, e);

        }

        public async Task WaitModal(object sender, EventArgs e)
        {
            if (sender is Element element && element is Frame frame)
            {
                var tapGestureRecognizer = frame.GestureRecognizers.OfType<TapGestureRecognizer>().FirstOrDefault();
                var parameter = tapGestureRecognizer?.CommandParameter;

                if (parameter != null)
                {
                    await Navigation.PushModalAsync(new RecipeDetails((int)parameter));
                }
            }
        }

        public void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                _viewModel.UpdateListRecipes(selectedIndex);
            }
        }


    }

}
