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
			multiuseLabel.Text = String.Join(" ", Miscellaneous2.ReturnCourseItems());
		}

		private void clearData_Clicked(object sender, EventArgs e)
		{
			DB.ClearData();
			Shell.Current.GoToAsync("HomePage");
		}
	}
}