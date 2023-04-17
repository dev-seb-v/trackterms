using System;


using Xamarin.Forms;

using Xamarin.Forms.Xaml;

using track_terms.Services;
using track_terms.Models;

namespace track_terms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCourse : ContentPage
	{
		public AddCourse()
		{
			InitializeComponent();
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			Title = DB.GrabTermName(HomePage.term_id);
			termIdEntry.Text = HomePage.term_id.ToString();

			Status s = new Status();

			OAstackLayout.IsVisible = false;
			PAstackLayout.IsVisible = false;

			statusPicker.ItemsSource = s.statuses;
		}
		private void saveCourseBtn_Clicked(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(titleEntry.Text))
			{
				DisplayAlert("Course Title", "Please enter a valid course title", "Ok");
				return;
			}
			if (statusPicker.SelectedItem == null)
			{
				DisplayAlert("Course Status", "Please select a status", "Ok");
				return;
			}
			if (startPicker.Date == null)
			{
				DisplayAlert("Start Date", "Please select a start date", "Ok");
				return;
			}
			if (endPicker.Date == null)
			{
				DisplayAlert("End Date", "Please select an end date", "Ok");
				return;
			}
			if (startPicker.Date > endPicker.Date)
			{
				DisplayAlert("Invalid Date", "The end of the course cannot be before the start", "Ok");
				return;
			}
			if (string.IsNullOrEmpty(instructorEntry.Text))
			{
				DisplayAlert("Instructor Name", "Please enter a valid instructor name", "Ok");
				return;
			}
			if (string.IsNullOrEmpty(InstructorEmailEntry.Text))
			{
				DisplayAlert("Instructor Email", "Please enter a valid instructor email", "Ok");
				return;
			}
			if (string.IsNullOrEmpty(InstructorPhone.Text))
			{
				DisplayAlert("Instructor Phone Number", "Please enter a valid phone number", "Ok");
				return;
			}
			// add instructor, then add course with the id
			Instructor i = new Instructor(instructorEntry.Text, InstructorPhone.Text, InstructorEmailEntry.Text);

			// use of generic method to add instructor type
			DB.AddItem<Instructor>(i);

			var status = statusPicker.SelectedItem as Status;

			// add course
			DB.AddCourse(Int32.Parse(termIdEntry.Text), status.status, titleEntry.Text, startPicker.Date, endPicker.Date, i.InstructorId);
			// need to use CourseId to Add Assessments (Bug Found!)
			
			if (OAtoggle.IsToggled)
			{
				// created a method to grab the course id using the course name
				DB.AddObjAssessment(DB.GetCourseId(titleEntry.Text), objAssessmentNameEntry.Text, ObjNotesEntry.Text, objAssessmentDueDatePicker.Date);
			}
			if (!OAtoggle.IsToggled)
			{
				// created a method to grab the course id using the course name
				DB.AddObjAssessment(DB.GetCourseId(titleEntry.Text), "Add Assessment", String.Empty, DateTime.Now);
			}
			if (PAtoggle.IsToggled)
			{
				DB.AddPerfAssessment(DB.GetCourseId(titleEntry.Text), perfAssessmentNameEntry.Text, PerfNotesEntry.Text, perfAssessmentDueDatePicker.Date);
			}
			// If user does not add assessments manually, placeholder assessments will be added for the user to edit later
			if (!PAtoggle.IsToggled)
			{
				// created a method to grab the course id using the course name
				DB.AddPerfAssessment(DB.GetCourseId(titleEntry.Text), "Add Assessment", String.Empty, DateTime.Now);
			}



			Shell.Current.GoToAsync("HomePage");
		}

		private void PAtoggle_Toggled(object sender, ToggledEventArgs e)
		{
			if (PAtoggle.IsToggled)
			{
				PAstackLayout.IsVisible = true;
			}

			if (!PAtoggle.IsToggled)
			{
				PAstackLayout.IsVisible = false;
			}
		}

		private void OAtoggle_Toggled(object sender, ToggledEventArgs e)
		{
			if (OAtoggle.IsToggled)
			{
				OAstackLayout.IsVisible = true;
			}

			if (!OAtoggle.IsToggled)
			{
				OAstackLayout.IsVisible = false;
			}
		}
	}
}