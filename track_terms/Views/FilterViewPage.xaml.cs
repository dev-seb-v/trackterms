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
	public partial class FilterViewPage : ContentPage
	{
		public FilterViewPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			Bools B = new Bools();
			DateToggle.IsToggled = B.CourseDates;
			NameToggle.IsToggled = B.Name;
		}

		private void NameToggle_Toggled(Object sender, EventArgs a)
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
		
		private void DateToggle_Toggled(Object sender, EventArgs a)
		{
			if (DateToggle.IsToggled == false)
			{
				DB.UpdateDatesBool(1, false);
				Bools B = DB.GetBool(1);
				CourseStartLabel.IsVisible = B.CourseDates;
				CourseEndLabel.IsVisible = B.CourseDates;
				return;
			}
			if (DateToggle.IsToggled == true)
			{
				DB.UpdateDatesBool(1, true);
				Bools B = DB.GetBool(1);
				CourseStartLabel.IsVisible = B.CourseDates;
				CourseEndLabel.IsVisible = B.CourseDates;
				return;
			}
		}

		private void CourseStatusToggle_Toggled(Object sender, EventArgs a)
		{ 
		
		}

		private void InstructorToggle_Toggled(Object sender, EventArgs a)

		{

		}
		private void OAToggle_Toggled(Object sender, EventArgs a)
		{

		}

		private void PAToggle_Toggled(Object sender, EventArgs a)
		{

		}

		private void Button_Clicked(Object sender, EventArgs a)
		{
			Navigation.PopModalAsync();
		}
		private void SaveViewButton_Clicked(Object sender, EventArgs a)
		{
			Navigation.PopModalAsync();
		}
	}
}