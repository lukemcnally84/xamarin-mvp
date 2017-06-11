using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using LMcNally.Xamarin.MvpDemo.Presentation.Views;
using LMcNally.Xamarin.MvpDemo.Presentation.Presenters;
using Android.Text;

namespace LMcNally.Xamarin.MvpDemo.Droid.Views
{
	[Activity(Label = "Sign-up")]
	public class SignUpActivity : Activity, ISignUpView
	{
		#region Lifetime Overrides

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.SignUpView);

			m_edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);
			m_edtEmail.TextChanged += m_edtEmail_TextChanged;

			m_edtName = FindViewById<EditText>(Resource.Id.edtEmail);
			m_edtName.TextChanged += m_edtName_TextChanged;

			m_edtAddress = FindViewById<EditText>(Resource.Id.edtEmail);
			m_edtAddress.TextChanged += m_edtAddress_TextChanged;

			m_edtPassword = FindViewById<EditText>(Resource.Id.edtPassword);
			m_edtPassword.TextChanged += m_edtPassword_TextChanged;

			m_edtConfirmPassword = FindViewById<EditText>(Resource.Id.edtConfirmPassword);
			m_edtConfirmPassword.TextChanged += m_edtConfirmPassword_TextChanged;

			m_btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
			m_btnSignUp.Touch += m_btnSignUp_Touch;

			var app = MvpDemoApplication.GetApplication(this);
			m_presenter = app.Presenter as SignUpPresenter;
			m_presenter.SetView(this);

			app.CurrentActivity = this;
		}

		public override void OnBackPressed()
		{
			m_presenter.GoToLogin();
		}

		protected override void OnStop()
		{
			base.OnStop();

			// We remove ourself from the navigation stack, so that the back
			// button doesn't bring the user back to the sign-up screen.
			Finish();
		}

		#endregion

		#region ISignUpView Implementation

		#region IActionView Implementation

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

		#region INavigationView Implementation

		public bool IsNavigating { get; private set; }

		public void OnNavigationStarted()
		{
			IsNavigating = true;
		}

		#endregion

		public void OnInputValidated(bool isValid)
		{
			m_btnSignUp.Enabled = isValid;
		}

		public void OnSignUpFailed(string errorMessage)
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

		private void m_edtName_TextChanged(object sender, TextChangedEventArgs e)
		{
			m_presenter.UpdateName(e.Text.ToString());
		}

		private void m_edtAddress_TextChanged(object sender, TextChangedEventArgs e)
		{
			m_presenter.UpdateAddress(e.Text.ToString());
		}

		private void m_edtPassword_TextChanged(object sender, TextChangedEventArgs e)
		{
			m_presenter.UpdatePassword(e.Text.ToString());
		}

		private void m_edtConfirmPassword_TextChanged(object sender, TextChangedEventArgs e)
		{
			m_presenter.UpdateConfirmPassword(e.Text.ToString());
		}

		private void m_btnSignUp_Touch(object sender, View.TouchEventArgs e)
		{
			m_presenter.SignUp();
		}

		#endregion

		#region Member Variables

		private SignUpPresenter m_presenter;
		private EditText m_edtEmail;
		private EditText m_edtName;
		private EditText m_edtAddress;
		private EditText m_edtPassword;
		private EditText m_edtConfirmPassword;
		private Button m_btnSignUp;

		private bool m_dialogVisible;

		#endregion

	}
}