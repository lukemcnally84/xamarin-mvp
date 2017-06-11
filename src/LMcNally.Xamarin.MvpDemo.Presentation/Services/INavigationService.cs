using LMcNally.Xamarin.MvpDemo.Presentation.Presenters;

namespace LMcNally.Xamarin.MvpDemo.Presentation.Services
{
	public interface INavigationService
	{
		void PushPresenter(BasePresenter presenter);
	}
}