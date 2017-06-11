using System;
using LMcNally.Xamarin.MvpDemo.Presentation.Services;
using LMcNally.Xamarin.MvpDemo.Presentation.Views;

namespace LMcNally.Xamarin.MvpDemo.Presentation.Presenters
{
	public class LoginPresenter : BasePresenter
	{
		public LoginPresenter(INavigationService navigationService) :
			base(navigationService)
		{
		}

		public void SetView(ILoginView view)
		{
			m_view = view;
			ValidateInput();
		}

		public void UpdateEmail(string email)
		{
			m_email = email;
			ValidateInput();
		}

		public void UpdatePassword(string password)
		{
			m_password = password;
			ValidateInput();
		}

		private void ValidateInput()
		{
			m_view.OnInputValidated(HasValidInput());
		}

		private bool HasValidInput()
		{
			return !string.IsNullOrEmpty(m_email) && !string.IsNullOrEmpty(m_password);
		}

		public void Login()
		{
			if (!m_view.IsNavigating &&
				!m_view.IsPerformingAction &&
				HasValidInput())
			{
				m_view.OnActionStarted();

				// TODO: Add logic for login.
				bool loggedIn = true;

				m_view.OnActionFinished();

				if (loggedIn)
				{
					m_view.OnNavigationStarted();
					NavigationService.PushPresenter(new MainPresenter(NavigationService));
				}
				else
				{
					m_view.OnLoginFailed("There was a problem logging you in, please try again later.");
				}
			}
		}

		public void Register()
		{
			if (!m_view.IsNavigating)
			{
				m_view.OnNavigationStarted();
				NavigationService.PushPresenter(new SignUpPresenter(NavigationService));
			}
		}

		private ILoginView m_view;
		private string m_email;
		private string m_password;
	}
}