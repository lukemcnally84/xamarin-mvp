using LMcNally.Xamarin.MvpDemo.Presentation.Services;
using LMcNally.Xamarin.MvpDemo.Presentation.Views;

namespace LMcNally.Xamarin.MvpDemo.Presentation.Presenters
{
	public class MainPresenter : BasePresenter
	{
		public MainPresenter(INavigationService navigationService) :
			base(navigationService)
		{
		}

		public void SetView(IMainView view)
		{
			m_view = view;
		}

		private IMainView m_view;
	}
}