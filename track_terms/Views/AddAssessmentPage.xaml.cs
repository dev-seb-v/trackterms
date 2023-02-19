using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using track_terms.Services;
using track_terms.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace track_terms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddAssessmentPage : ContentPage
	{
		public static int id;
		public List<string> Types = new List<string>()
		{
			"Objective",
			"Performance"
		};
		public AddAssessmentPage()
		{
			InitializeComponent();
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			TypePicker.ItemsSource = Types;
			id = HomePage.courseId;
		}

		private void cancelButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PopModalAsync();
		}

		async void AddAssessmentBtn_Clicked(object sender, EventArgs e)
		{
			string defaultNotesMsg = "Add Some Notes";
			if (string.IsNullOrEmpty(notesEntry.Text))
			{
				notesEntry.Text = defaultNotesMsg;
			}
			if (string.IsNullOrEmpty(nameEntry.Text))
			{
				await DisplayAlert("Missing Assessment Name", "Please Enter Name for Assessment", "Ok");
				return;
			}
			if (TypePicker.SelectedItem == null)
			{
				await DisplayAlert("Missing Assessment Type", "Please Select Type for Assessment", "Ok");
				return;
			}
			else
			{
				var alert = await DisplayAlert("Add Assessment", "Would You Like To Add?", "Yes" ,"No");
				if (alert)
				{
					int itemPicked = TypePicker.SelectedIndex;
					HelperClass.AddAssessment
						(
						 id,
						 nameEntry.Text,
						 Types[itemPicked].ToString(),
						 notesEntry.Text
						);
					await Navigation.PopModalAsync();
				}
				else { return; }
			}
			
		}
	}
}