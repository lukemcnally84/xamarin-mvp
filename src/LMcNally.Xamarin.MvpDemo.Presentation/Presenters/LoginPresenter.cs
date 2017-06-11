using LMcNally.Xamarin.MvpDemo.Presentation.Views;

namespace LMcNally.Xamarin.MvpDemo.Presentation.Presenters
{
	public class LoginPresenter
	{
		public LoginPresenter()
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
			if (!m_view.IsPerformingAction && HasValidInput())
			{
				m_view.OnActionStarted();

				// TODO: Add logic for registration.
				bool loggedIn = false;

				m_view.OnActionFinished();

				if (loggedIn)
				{
					// TODO: Navigate to main screen.
				}
				else
				{
					m_view.OnLoginFailed("Login hasn't been implemented yet.");
				}
			}
		}

		private ILoginView m_view;
		private string m_email;
		private string m_password;
	}
}
