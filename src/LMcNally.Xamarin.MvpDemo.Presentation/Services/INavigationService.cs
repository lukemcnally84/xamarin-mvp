using LMcNally.Xamarin.MvpDemo.Presentation.Presenters;

namespace LMcNally.Xamarin.MvpDemo.Presentation.Services
{
	public interface INavigationService
	{
		void NavigateTo(BasePresenter presenter);

		void StartNewNavigationStack(BasePresenter signUpPresenter);
	}
}