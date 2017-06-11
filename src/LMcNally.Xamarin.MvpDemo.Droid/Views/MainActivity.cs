using Android.App;
using Android.OS;
using LMcNally.Xamarin.MvpDemo.Presentation.Presenters;
using LMcNally.Xamarin.MvpDemo.Presentation.Views;

namespace LMcNally.Xamarin.MvpDemo.Droid.Views
{
	[Activity(Label = "MainActivity")]
	public class MainActivity : Activity, IMainView
	{
		#region Lifetime Overrides

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.MainView);

			var app = MvpDemoApplication.GetApplication(this);
			m_presenter = (MainPresenter)app.Presenter;
			m_presenter.SetView(this);

			app.CurrentActivity = this;
		}

		#endregion

		#region ILoginView Implementation

		public bool IsPerformingAction { get; private set; }

		public void OnActionStarted()
		{
			IsPerformingAction = true;
		}

		public void OnActionFinished()
		{
			IsPerformingAction = false;
		}

		#endregion

		#region Member Variables

		private MainPresenter m_presenter;

		#endregion
	}
}