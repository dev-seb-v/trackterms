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
		private  void testBtn_Clicked(object sender, EventArgs e)
		{
			try
			{
				string labelText = outputLabel. Text;
				string expected = "Spring 2023";
				
				if (Int32.TryParse(labelText, out int a))
				{
					termIdEntry.Text = " ";
					DisplayAlert("Non-Numeric Input Error", "Please enter a number", "Ok");
					return;
				}
				else
				{
					outputLabel.Text = DB.GetTermName(Int32.Parse(termIdEntry.Text));
					if (expected == outputLabel.Text)
					{
						DisplayAlert("Test Passed", "The correct term name was returned from DB.", "Ok");
					}
					else
					{
						DisplayAlert("Test Did Not Pass", "The expected string was not returned.", "Ok");
					}
				}
			}
			catch 
			{

				DisplayAlert("Error", "Please Try Again", "Ok");
				termIdEntry.Text = "";
				return;
			}
		}
	}
}