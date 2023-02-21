using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using track_terms.Views;
using track_terms.Models;

namespace track_terms
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			MainPage = new AppShell();
		}

		protected override void OnStart()
		{
			string greeting = $"Hello! Please go to the Testing Section and Press \"Load Data\" to load the sample data. {Environment.NewLine} {Environment.NewLine}" +
				$"The notification for assessment will be on the course detail page.";
			MainPage.DisplayAlert("Hello", greeting, "Ok");
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
