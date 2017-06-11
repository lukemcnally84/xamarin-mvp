namespace LMcNally.Xamarin.MvpDemo.Presentation.Views
{
	public interface IActionView
	{
		bool IsPerformingAction { get; }

		void OnActionFinished();
		void OnActionStarted();
	}
}