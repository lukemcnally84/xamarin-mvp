using LMcNally.Xamarin.MvpDemo.Presentation.Services;
using LMcNally.Xamarin.MvpDemo.Presentation.Views;

namespace LMcNally.Xamarin.MvpDemo.Presentation.Presenters
{
	public class SignUpPresenter : BasePresenter
	{
		public SignUpPresenter(INavigationService navigationService) :
			base(navigationService)
		{
		}

		public void SetView(ISignUpView view)
		{
			m_view = view;
			ValidateInput();
		}

		public void UpdateEmail(string email)
		{
			m_email = email;
			ValidateInput();
		}

		public void UpdateName(string name)
		{
			m_name = name;
			ValidateInput();
		}

		public void UpdateAddress(string address)
		{
			m_address = address;
			ValidateInput();
		}

		public void UpdatePassword(string password)
		{
			m_password = password;
			ValidateInput();
		}

		public void UpdateConfirmPassword(string confirmPassword)
		{
			m_confirmPassword = confirmPassword;
			ValidateInput();
		}

		private void ValidateInput()
		{
			m_view.OnInputValidated(HasValidInput());
		}

		private bool HasValidInput()
		{
			// TODO: Perform real validation.
			return !string.IsNullOrEmpty(m_email) &&
				!string.IsNullOrEmpty(m_name) &&
				!string.IsNullOrEmpty(m_address) &&
				!string.IsNullOrEmpty(m_password) &&
				!string.IsNullOrEmpty(m_confirmPassword) &&
				m_password == m_confirmPassword;
		}

		public void SignUp()
		{
			if (!m_view.IsNavigating &&
				!m_view.IsPerformingAction &&
				HasValidInput())
			{
				m_view.OnActionStarted();

				// TODO: Add logic for sign-up.
				bool signedUp = true;

				m_view.OnActionFinished();

				if (signedUp)
				{
					m_view.OnNavigationStarted();
					NavigationService.StartNewNavigationStack(new MainPresenter(NavigationService));
				}
				else
				{
					m_view.OnSignUpFailed("There was a problem creating your account, please try again later.");
				}
			}
		}

		public void GoToLogin()
		{
			if (!m_view.IsNavigating)
			{
				m_view.OnNavigationStarted();
				NavigationService.StartNewNavigationStack(new LoginPresenter(NavigationService));
			}
		}

		private ISignUpView m_view;
		private string m_email;
		private string m_password;
		private string m_name;
		private string m_address;
		private string m_confirmPassword;
	}
}