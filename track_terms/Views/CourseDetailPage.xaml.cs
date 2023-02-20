using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using track_terms.Services;
using Plugin.LocalNotifications;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace track_terms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CourseDetailPage : ContentPage
	{
		public CourseDetailPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			int id = HomePage.courseId;
			int teacherId = HelperClass.GetInstructorId(id);
			CourseNameLabel.Text = HelperClass.returnCourseName(id);
			CourseStartLabel.Text = HelperClass.returnStartOuput(id);
			CourseEndLabel.Text = HelperClass.returnEndOutput(id);
			CourseStatusLabel.Text = HelperClass.getStatus(id);
			InstructorNameLabel.Text = HelperClass.GetInstructorName(teacherId);
			InstructorPhoneLabel.Text = HelperClass.GetInstructorPhone(teacherId);
			InstructorEmailLabel.Text = HelperClass.GetInstructorEmail(teacherId);
			ObjAssessmentLabel.Text = HelperClass.GetObjAssessOutput(id);
			PerfAssessmentLabel.Text = HelperClass.GetPerfAssessOutput(id);
			
		}

		private void EditCourseButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new UpdateCourse());
		}

		private async void DeleteCourseBtn_Clicked(object sender, EventArgs e)
		{
			var answer = await DisplayAlert("Delete Course", "Do you want to delete the course", "Yes", "No");

			if (answer)
			{
				DB.RemoveCourse(HomePage.courseId);
				await Shell.Current.GoToAsync("HomePage");
			}
			else { return; }
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			Shell.Current.GoToAsync("HomePage");
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
		}

		private void editAssessmentBtn_Clicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new EditAssessmentPage());

		}
	}
}