using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LMcNally.Xamarin.MvpDemo.Presentation.Presenters;
using LMcNally.Xamarin.MvpDemo.Presentation.Services;
using LMcNally.Xamarin.MvpDemo.Droid.Views;

namespace LMcNally.Xamarin.MvpDemo.Droid.Services
{
	public class NavigationService : INavigationService
	{
		public NavigationService(MvpDemoApplication application)
		{
			m_application = application;
		}

		public void PushPresenter(BasePresenter presenter)
		{
			var oldPresenter = m_application.Presenter as BasePresenter;

			if (presenter != oldPresenter)
			{
				m_application.Presenter = presenter;
				Intent intent = null;

				if (presenter is LoginPresenter)
				{
					intent = new Intent(m_application.CurrentActivity, typeof(LoginActivity));
				}
				else if (presenter is MainPresenter)
				{
					intent = new Intent(m_application.CurrentActivity, typeof(MainActivity));
				}

				if (intent != null)
				{
					m_application.CurrentActivity.StartActivity(intent);
				}
			}
		}

		private MvpDemoApplication m_application;
	}
}