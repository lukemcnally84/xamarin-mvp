namespace LMcNally.Xamarin.MvpDemo.Presentation.Views
{
	public interface ILoginView
	{
		bool IsPerformingAction { get; }

		void OnInputValidated(bool isValid);
		void OnActionStarted();
		void OnActionFinished();
		void OnLoginFailed(string errorMessage);
	}
}