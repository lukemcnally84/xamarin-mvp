namespace LMcNally.Xamarin.MvpDemo.Presentation.Views
{
	public interface ILoginView : IActionView, INavigationView
	{
		void OnInputValidated(bool isValid);
		void OnLoginFailed(string errorMessage);
	}
}