using LMcNally.Xamarin.MvpDemo.Presentation.Services;

namespace LMcNally.Xamarin.MvpDemo.Presentation.Presenters
{
	public abstract class BasePresenter
	{
		protected BasePresenter(INavigationService navigationService)
		{
			NavigationService = navigationService;
		}

		protected INavigationService NavigationService;
	}
}