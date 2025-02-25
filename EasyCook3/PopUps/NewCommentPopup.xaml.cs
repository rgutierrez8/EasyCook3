using EasyCook3.Core.Interfaces;
using EasyCook3.Models.DTO;
using EasyCook3.Pages;
using MauiPopup;
using MauiPopup.Views;

namespace EasyCook3.PopUps;

public partial class NewCommentPopup : BasePopupPage
{
	private readonly ICommentService _commentService;

	private readonly int _recipeId;

	public NewCommentPopup(int recipeId)
	{
		InitializeComponent();

		var commentService = MauiProgram.CreateMauiApp().Services.GetService<ICommentService>();
		_commentService = commentService;
		_recipeId = recipeId;
	}

	public void OnCancel(object sender, EventArgs e)
	{
		PopupAction.ClosePopup(this);
	}
	public async void OnSave(object sender, EventArgs e)
	{
		NewCommentDTO commentDTO = new NewCommentDTO()
		{
			RecipeId = _recipeId,
			Describe = newComment.Text
		};

		var response = await _commentService.NewComment(commentDTO);

		if (response)
		{
            PopupAction.ClosePopup(this);
        }
	}
}