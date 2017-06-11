using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Widget;
using LMcNally.Xamarin.MvpDemo.Presentation.Presenters;
using LMcNally.Xamarin.MvpDemo.Presentation.Views;

namespace LMcNally.Xamarin.MvpDemo.Droid.Views
{
	[Activity(Label = "Login", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
	public class LoginActivity : Activity, ILoginView
	{
		#region Lifetime Overrides

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.LoginView);

			m_edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);
			m_edtEmail.TextChanged += m_edtEmail_TextChanged;

			m_edtPassword = FindViewById<EditText>(Resource.Id.edtPassword);
			m_edtPassword.TextChanged += m_edtPassword_TextChanged;

			m_btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
			m_btnLogin.Touch += m_btnLogin_Touch;

			m_presenter = new LoginPresenter();
			m_presenter.SetView(this);
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

		public void OnInputValidated(bool isValid)
		{
			m_btnLogin.Enabled = isValid;
		}

		public void OnLoginFailed(string errorMessage)
		{
			if (!m_dialogVisible)
			{
				m_dialogVisible = true;

				AlertDialog.Builder builder = new AlertDialog.Builder(this);
				builder.SetTitle("AliveDrive")
					.SetMessage(errorMessage)
					.SetNeutralButton("OK", (s, e) => { m_dialogVisible = false; })
					.Show();
			}
		}

		#endregion

		#region Implementation

		private void m_edtEmail_TextChanged(object sender, TextChangedEventArgs e)
		{
			m_presenter.UpdateEmail(e.Text.ToString());
		}

		private void m_edtPassword_TextChanged(object sender, TextChangedEventArgs e)
		{
			m_presenter.UpdatePassword(e.Text.ToString());
		}

		private void m_btnLogin_Touch(object sender, View.TouchEventArgs e)
		{
			m_presenter.Login();
		}

		#endregion

		#region Member Variables

		private LoginPresenter m_presenter;
		private EditText m_edtEmail;
		private EditText m_edtPassword;
		private Button m_btnLogin;

		private bool m_dialogVisible;

		#endregion
	}
}