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
			toggleMenu.IsVisible = false;

			Bools B = DB.GetBool(1);
			CourseNameLabel.IsVisible = B.Name;
			nameSectionLabel.IsVisible = B.Name;
			NameToggle.IsToggled = B.Name;

			CourseStartLabel.IsVisible = B.CourseDates;
			CourseEndLabel.IsVisible = B.CourseDates;
			DateToggle.IsToggled = B.CourseDates;

			CourseStatusLabel.IsVisible = B.CourseStatus;
			statusSectionLabel.IsVisible = B.CourseStatus;
			CourseStatusToggle.IsToggled = B.CourseStatus;

			InstructorEmailLabel.IsVisible = B.Instruct;
			InstructorNameLabel.IsVisible = B.Instruct;
			InstructorPhoneLabel.IsVisible = B.Instruct;
			InstructorToggle.IsToggled = B.Instruct;

			//OAsectionLabel.IsVisible = B.OA;
			//ObjAssessmentLabel.IsVisible = B.OA;
			OAToggle.IsToggled = B.OA;
			OAstackLayout.IsVisible = B.OA;

			//PAsectionLabel.IsVisible = B.PA;
			//PerfAssessmentLabel.IsVisible = B.PA;
			PAToggle.IsToggled = B.PA;
			PAstackLayout.IsVisible = B.PA;

			base.OnAppearing();
			//toggleMenu.IsVisible = false;
			int id = HomePage.courseId;
			int teacherId = DB.GetInstructorId(id);
			CourseNameLabel.Text = DB.returnCourseName(id);
			CourseStartLabel.Text = DB.returnStartOuput(id);
			CourseEndLabel.Text = DB.returnEndOutput(id);
			CourseStatusLabel.Text = DB.getStatus(id);
			InstructorNameLabel.Text = DB.GetInstructorName(teacherId);
			InstructorPhoneLabel.Text = DB.GetInstructorPhone(teacherId);
			InstructorEmailLabel.Text = DB.GetInstructorEmail(teacherId);
			ObjAssessmentNameLabel.Text = DB.GetObjAssessName(id);
			ObjAssessmentDateLabel.Text = DB.GetObjAssessDate(id).ToString();
			ObjAssessmentNoteLabel.Text = DB.GetObjAssessNotes(id);
			PerfAssessmentNameLabel.Text = DB.GetPerfAssessName(id);
			PerfAssessmentDateLabel.Text = DB.GetPerfAssessDate(id).ToString();
			PerfAssessmentNoteLabel.Text = DB.GetPerfAssessNotes(id);
			string start = DB.returnStartOuput(id);
			string end = DB.returnEndOutput(id);
			string OA = DB.GetObjAssessOutput(id);
			string PA = DB.GetPerfAssessOutput(id);
			List<string> messages = new List<string>() {start, end, OA, PA };
			string masterMessage = String.Join(Environment.NewLine, messages);
			CrossLocalNotifications.Current.Show("Course Alert", $"{masterMessage}", 101, DateTime.Now.AddSeconds(1));
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
			if (DateToggle.IsToggled == false)
			{
				DB.UpdateDatesBool(1, false);
				Bools B = DB.GetBool(1);
				CourseStartLabel.IsVisible = B.Name;
				CourseEndLabel.IsVisible = B.Name;
				return;
			}
			if (DateToggle.IsToggled == true)
			{
				DB.UpdateDatesBool(1, true);
				Bools B = DB.GetBool(1);
				CourseStartLabel.IsVisible = B.Name;
				CourseEndLabel.IsVisible = B.Name;

				return;
			}
		}
		private void CourseStatusToggle_Toggled(object sender, ToggledEventArgs e)
		{
			if (CourseStatusToggle.IsToggled == false)
			{
				DB.UpdateStatusBool(1, false);
				Bools B = DB.GetBool(1);
				statusSectionLabel.IsVisible = B.CourseStatus;
				CourseStatusLabel.IsVisible = B.CourseStatus;
				return;
			}
			if (CourseStatusToggle.IsToggled == true)
			{
				DB.UpdateStatusBool(1, true);
				Bools B = DB.GetBool(1);
				statusSectionLabel.IsVisible = B.CourseStatus;
				CourseStatusLabel.IsVisible = B.CourseStatus;
				return;
			}
		}
		private void InstructorToggle_Toggled(object sender, ToggledEventArgs e)
		{
			if (InstructorToggle.IsToggled == false)
			{
				DB.UpdateInstructorBool(1, false);
				Bools B = DB.GetBool(1);
				InstructorEmailLabel.IsVisible = B.Instruct;
				InstructorNameLabel.IsVisible = B.Instruct;
				InstructorPhoneLabel.IsVisible = B.Instruct;
				return;
			}
			if (CourseStatusToggle.IsToggled == true)
			{
				DB.UpdateInstructorBool(1, true);
				Bools B = DB.GetBool(1);
				InstructorEmailLabel.IsVisible = B.Instruct;
				InstructorNameLabel.IsVisible = B.Instruct;
				InstructorPhoneLabel.IsVisible = B.Instruct;
				return;
			}
		}
		private void OAToggle_Toggled(object sender, ToggledEventArgs e)
		{
			if (OAToggle.IsToggled == false)
			{
				DB.UpdateOABool(1, false);
				Bools B = DB.GetBool(1);
				OAsectionLabel.IsVisible = B.OA;
				//ObjAssessmentLabel.IsVisible = B.OA;
				OAstackLayout.IsVisible = B.OA;
				return;
			}
			if (CourseStatusToggle.IsToggled == true)
			{
				DB.UpdateOABool(1, true);
				Bools B = DB.GetBool(1);
				OAsectionLabel.IsVisible = B.OA;
				//ObjAssessmentLabel.IsVisible = B.OA;
				PAstackLayout.IsVisible = B.OA;
				return;
			}
		}
		private void PAToggle_Toggled(object sender, ToggledEventArgs e)
		{
			if (PAToggle.IsToggled == false)
			{
				DB.UpdatePABool(1, false);
				Bools B = DB.GetBool(1);
				//PAsectionLabel.IsVisible = B.PA;
				//PerfAssessmentLabel.IsVisible = B.PA;
				PAstackLayout.IsVisible = B.PA;
				return;
			}
			if (PAToggle.IsToggled == true)
			{
				DB.UpdatePABool(1, true);
				Bools B = DB.GetBool(1);
				//PAsectionLabel.IsVisible = B.PA;
				//PerfAssessmentLabel.IsVisible = B.PA;
				PAstackLayout.IsVisible = B.PA;
				return;
			}
		}
		private void filterViewBtn_Clicked(object sender, EventArgs e)
		{
			toggleMenu.IsVisible = true;
			DisplayAlert("Filters", "Scroll to Bottom", "Ok");
		}
		private void SaveViewButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new CourseDetailPage());
		}

	}
}