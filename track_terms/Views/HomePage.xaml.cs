using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using track_terms.Models;
using track_terms.Services;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace track_terms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public static int term_id;
		public static int courseId;
		public static Term t;
		public HomePage()
		{
			InitializeComponent();
			using (SQLiteConnection con = new SQLiteConnection(DB.databasePath))
			{
				con.CreateTable<Term>();
				List<Term> terms = con.Table<Term>().ToList();
				termPicker.ItemsSource = terms;
			}
			if (termPicker.SelectedItem == null)
			{
				GoToAddCourse.IsEnabled = false;
			}
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			termPicker.SelectedIndex = -1;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
		}

		private void GoToAddCourse_Clicked(object sender, EventArgs e)
		{
			Shell.Current.GoToAsync("AddCourse");
		}
		private void termPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			t = (Term)termPicker.SelectedItem;
			term_id = t.TermId;
			GoToAddCourse.IsEnabled = true;

			CourseView.ItemsSource = DB.ReadCourses(term_id);
		}

		private void CourseView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			courseId = (e.CurrentSelection.FirstOrDefault() as Course).CourseId;
			//Shell.Current.GoToAsync("ViewCourse");
			Navigation.PushAsync(new CourseDetailPage());
		}

	}
}