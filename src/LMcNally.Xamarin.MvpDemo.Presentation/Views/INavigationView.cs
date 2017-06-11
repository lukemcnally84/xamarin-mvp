namespace LMcNally.Xamarin.MvpDemo.Presentation.Views
{
	public interface INavigationView
	{
		bool IsNavigating { get; }

		void OnNavigationStarted();
	}
}