using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using track_terms.Services;
using track_terms.Models;

namespace track_terms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForTesting : ContentPage
	{
		public ForTesting()
		{
			InitializeComponent();
		}

		private void clearData_Clicked(object sender, EventArgs e)
		{
			DB.ClearData();
			(Application.Current).MainPage = new AppShell();
		}

		private void loadDataButton_Clicked(object sender, EventArgs e)
		{
			DB.LoadData();
			(Application.Current).MainPage = new AppShell();
		}

		private void AssessmentButton_Clicked(object sender, EventArgs e)
		{
			editor.Text = HelperClass.GetObjAssessOutput(1);
		}
	}
}