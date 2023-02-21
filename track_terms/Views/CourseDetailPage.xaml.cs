using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using track_terms.Services;
using Plugin.LocalNotifications;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using track_terms.Models;
using SQLite;

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
			Bools B = DB.GetBool(1);
			CourseNameLabel.IsVisible = B.Name;
			nameSectionLabel.IsVisible = B.Name;
			NameToggle.IsToggled = B.Name;

			CourseStartLabel.IsVisible = B.CourseDates;
			CourseEndLabel.IsVisible = B.CourseDates;
			//DateToggle.IsToggled = B.CourseDates;



			base.OnAppearing();
			//toggleMenu.IsVisible = false;
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
			string perfText = PerfAssessmentLabel.Text;
			string objText = ObjAssessmentLabel.Text;
			CrossLocalNotifications.Current.Show("Assessments", $"{perfText}{objText}", 101, DateTime.Now.AddSeconds(5));
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
		private void NameToggle_Toggled(object sender, ToggledEventArgs e)
		{
			if (NameToggle.IsToggled == false)
			{
				DB.UpdateNameBool(1, false);
				Bools B = DB.GetBool(1);
				CourseNameLabel.IsVisible = B.Name;
				nameSectionLabel.IsVisible = B.Name;
				return;
			}
			if (NameToggle.IsToggled == true)
			{
				DB.UpdateNameBool(1, true);
				Bools B = DB.GetBool(1);
				CourseNameLabel.IsVisible = B.Name;
				nameSectionLabel.IsVisible = B.Name;
				return;
			}
		}

		private void DateToggle_Toggled(object sender, ToggledEventArgs e)
		{

			
			//CourseStartLabel.IsVisible = IcanSeeTheDates;
			//CourseEndLabel.IsVisible = IcanSeeTheDates;
		}

		private void CourseStatusToggle_Toggled(object sender, ToggledEventArgs e)
		{

		}

		private void InstructorToggle_Toggled(object sender, ToggledEventArgs e)
		{


			//InstructorNameLabel.IsVisible = IcanSeeTheTeacher;
			//InstructorEmailLabel.IsVisible = IcanSeeTheTeacher;
			//InstructorPhoneLabel.IsVisible = IcanSeeTheTeacher;
			//InstructorSectionLabel.IsVisible = IcanSeeTheTeacher;
		}

		private void OAToggle_Toggled(object sender, ToggledEventArgs e)
		{


			//ObjAssessmentLabel.IsVisible = IcanSeeTheOA;
			//OAsectionLabel.IsVisible = IcanSeeTheOA;
		}

		private void PAToggle_Toggled(object sender, ToggledEventArgs e)
		{


			//PerfAssessmentLabel.IsVisible = IcanSeeThePA;
			//PAsectionLabel.IsVisible = IcanSeeThePA;
		}

		private void filterViewBtn_Clicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new FilterViewPage());
		}

		private void SaveViewButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new CourseDetailPage());
		}
	}
}