using Android.Content;
using LMcNally.Xamarin.MvpDemo.Droid.Views;
using LMcNally.Xamarin.MvpDemo.Presentation.Presenters;
using LMcNally.Xamarin.MvpDemo.Presentation.Services;

namespace LMcNally.Xamarin.MvpDemo.Droid.Services
{
	public class NavigationService : INavigationService
	{
		public NavigationService(MvpDemoApplication application)
		{
			m_application = application;
		}

		public void NavigateTo(BasePresenter presenter)
		{
			var oldPresenter = m_application.Presenter as BasePresenter;

			if (presenter != oldPresenter)
			{
				m_application.Presenter = presenter;
				Intent intent = null;

				if (presenter is LoginPresenter)
				{
					// The only way to get to the login screen is if the user is not
					// authorized to get to the main application. This could be due to
					// first use, session expiry, or logout. In all cases, we don't want
					// the previous Activity on the navigation stack, so we create the
					// intent from the app, not the previous activity.
					intent = new Intent(m_application, typeof(LoginActivity));
				}
				else if (presenter is SignUpPresenter)
				{
					// As above, we can only get to the sign-up screen when we're not
					// authorized to get to the main application. Hence, we create the
					// intent from the app, not the previous activity.
					intent = new Intent(m_application, typeof(SignUpActivity));
				}
				else if (presenter is MainPresenter)
				{
					if (m_application.CurrentActivity == null)
					{
						// We're navigating to the main UI from login or sign-up. We
						// ensure the back button doesn't take us back to login or
						// sign-up, by creating the Intent from the app.
						intent = new Intent(m_application, typeof(MainActivity));
					}
					else
					{
						intent = new Intent(m_application.CurrentActivity, typeof(MainActivity));
					}
				}

				if (intent != null)
				{
					m_application.CurrentActivity.StartActivity(intent);
				}
			}
		}

		public void StartNewNavigationStack(BasePresenter presenter)
		{
			var oldActivity = m_application.CurrentActivity;

			NavigateTo(presenter);

			oldActivity?.Finish();
		}

		private MvpDemoApplication m_application;
	}
}