using Android.App;
using Android.Content;
using Android.Runtime;
using LMcNally.Xamarin.MvpDemo.Droid.Services;
using LMcNally.Xamarin.MvpDemo.Presentation.Presenters;
using System;

namespace LMcNally.Xamarin.MvpDemo.Droid
{
	[Application]
	public class MvpDemoApplication : Application
	{
		public MvpDemoApplication(IntPtr javaReference, JniHandleOwnership transfer) :
			base(javaReference, transfer)
		{
		}

		public override void OnCreate()
		{
			base.OnCreate();

			Presenter = new LoginPresenter(new NavigationService(this));
		}

		public BasePresenter Presenter { get; set; }

		public Activity CurrentActivity { get; set; }

		public static MvpDemoApplication GetApplication(Context context)
		{
			return (MvpDemoApplication)context.ApplicationContext;
		}
	}
}