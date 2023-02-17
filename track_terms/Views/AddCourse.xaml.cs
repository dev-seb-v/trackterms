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
			// add instructor, then add course with the id
			Instructor i = new Instructor(instructorEntry.Text, InstructorPhone.Text, InstructorEmailEntry.Text);

			// use of generic method to add instructor type
			DB.AddItem<Instructor>(i);

			var status = statusPicker.SelectedItem as Status;

			// add course without assessment
			DB.AddCourse( Int32.Parse(termIdEntry.Text), status.status,  titleEntry.Text, startPicker.Date, endPicker.Date, i.InstructorId);

			Shell.Current.GoToAsync("HomePage");
		}
	}
}