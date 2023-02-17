using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using track_terms.Services;
using track_terms.Models;

namespace track_terms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddTerm : ContentPage
	{
		public AddTerm()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			
		}

		private void SaveTerm_Clicked(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(nameEntry.Text))
			{
			    DisplayAlert("Missing Term Name", "Please enter a name", "OK");
				return;
			}

			DB.AddTerm(nameEntry.Text, startPicker.Date, endPicker.Date);
			Shell.Current.GoToAsync("HomePage");
		}
	}
}