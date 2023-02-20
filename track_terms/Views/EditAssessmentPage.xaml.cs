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
		public EditAssessmentPage()
		{
			InitializeComponent();
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			
		}
		private void CancelButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PopModalAsync();
		}

		private void DeleteObjAssessmentButton_Clicked(object sender, EventArgs e)
		{
			HelperClass.SetObjAssessmentToEmpty(id);
			Navigation.PopModalAsync();
		}

		private void DeletePerfAssessmentButton_Clicked(object sender, EventArgs e)
		{
			HelperClass.SetPerfAssessmentToEmpty(id);
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
				HelperClass.UpdateObjAssessment(
					id,
					objAssessmentNameEntry.Text,
					"none",
					objAssessmentDueDatePicker.Date
					);
				Navigation.PopModalAsync();
			}
			else
			{
				HelperClass.UpdateObjAssessment(
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
				HelperClass.UpdatePerfAssessment(
					id,
					perfAssessmentNameEntry.Text,
					"none",
					perfAssessmentDueDatePicker.Date
					);
				Navigation.PopModalAsync();
			}
			else
			{
				HelperClass.UpdatePerfAssessment(
						id,
					perfAssessmentNameEntry.Text,
					PerfNotesEntry.Text,
					perfAssessmentDueDatePicker.Date
						);
				Navigation.PopModalAsync();
			}
		}
	}
}