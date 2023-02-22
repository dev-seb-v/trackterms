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

			HelperClass.AddObjAssessment(Int32.Parse(termIdEntry.Text), objAssessmentNameEntry.Text, ObjNotesEntry.Text, objAssessmentDueDatePicker.Date);
			HelperClass.AddPerfAssessment(Int32.Parse(termIdEntry.Text), perfAssessmentNameEntry.Text, PerfNotesEntry.Text, perfAssessmentDueDatePicker.Date);
			// add course
			DB.AddCourse(Int32.Parse(termIdEntry.Text), status.status, titleEntry.Text, startPicker.Date, endPicker.Date, i.InstructorId);

			Shell.Current.GoToAsync("HomePage");
		}

	}
}