using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using track_terms.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace track_terms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditAssessmentPage : ContentPage
	{
		public int id = HomePage.courseId;
		public List<string> typeOfAssessments = new List<string>()
		{ 
			"Objective",
			"Performance"
		};
		public EditAssessmentPage()
		{
			InitializeComponent();
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			AssessmentPicker.ItemsSource = typeOfAssessments;
			AssessmentPicker.SelectedIndex = 0;

			objAssessmentNameEntry.Text = DB.GetObjAssessName(id);
			objAssessmentDueDatePicker.Date = DB.GetObjAssessDate(id);
			ObjNotesEntry.Text = DB.GetObjAssessNotes(id);

			perfAssessmentNameEntry.Text = DB.GetPerfAssessName(id);
			perfAssessmentDueDatePicker.Date = DB.GetPerfAssessDate(id);
			PerfNotesEntry.Text = DB.GetPerfAssessNotes(id);
		}
		private void CancelButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PopModalAsync();
		}

		private void DeleteObjAssessmentButton_Clicked(object sender, EventArgs e)
		{
			DB.SetObjAssessmentToEmpty(id);
			Navigation.PopModalAsync();
		}

		private void DeletePerfAssessmentButton_Clicked(object sender, EventArgs e)
		{
			DB.SetPerfAssessmentToEmpty(id);
			Navigation.PopModalAsync();
		}

		private void UpdateObjAssessmentButton_Clicked(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(objAssessmentNameEntry.Text))
			{
				DisplayAlert("Invalid Assessment Name", "Please Enter a Name", "Ok");
				return;
			}
			if (objAssessmentDueDatePicker.Date == null)
			{
				DisplayAlert("Due Date Error", "Please Enter a Due Date", "Ok");
				return;
			}
			if (string.IsNullOrEmpty(ObjNotesEntry.Text))
			{
				DB.UpdateObjAssessment(
					id,
					objAssessmentNameEntry.Text,
					"none",
					objAssessmentDueDatePicker.Date
					);
				Navigation.PopModalAsync();
			}
			else
			{
				DB.UpdateObjAssessment(
						id,
						objAssessmentNameEntry.Text,
						ObjNotesEntry.Text,
						objAssessmentDueDatePicker.Date
						);
				Navigation.PopModalAsync();
			}

		}

		private void UpdatePerfAssessmentButton_Clicked(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(perfAssessmentNameEntry.Text))
			{
				DisplayAlert("Invalid Assessment Name", "Please Enter a Name", "Ok");
				return;
			}
			if (perfAssessmentDueDatePicker.Date == null)
			{
				DisplayAlert("Due Date Error", "Please Enter a Due Date", "Ok");
				return;
			}
			if (string.IsNullOrEmpty(PerfNotesEntry.Text))
			{
				PerfNotesEntry.Text = "add notes";
			}
			else
			{
				DB.UpdatePerfAssessment(
						id,
					perfAssessmentNameEntry.Text,
					PerfNotesEntry.Text,
					perfAssessmentDueDatePicker.Date
						);
				Navigation.PopModalAsync();
			}
		}

		private void AssessmentPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (AssessmentPicker.SelectedIndex == 0)
			{
				OAstackLayout.IsVisible = true;
				PAstackLayout.IsVisible = false;
			}
			if (AssessmentPicker.SelectedIndex == 1)
			{
				PAstackLayout.IsVisible = true;
				OAstackLayout.IsVisible = false;
			}
		}
	}
}