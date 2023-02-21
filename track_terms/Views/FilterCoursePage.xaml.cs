using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace track_terms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FilterCoursePage : ContentPage
	{
		public FilterCoursePage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}
		public void NameToggle_Toggled(object sender, ToggledEventArgs e)
		{
			Switch CourseName = this.FindByName<Switch>("NameToggle");
		}
		private void DateToggle_Toggled(object sender, ToggledEventArgs e)
		{

		}

		private void CourseToggle_Toggled(object sender, ToggledEventArgs e)
		{

		}

		private void InstructorToggle_Toggled(object sender, ToggledEventArgs e)
		{

		}

		private void OAToggle_Toggled(object sender, ToggledEventArgs e)
		{

		}

		private void PAToggle_Toggled(object sender, ToggledEventArgs e)
		{

		}

		private async void SaveButton_Clicked(object sender, EventArgs e)
		{
		   await Navigation.PopModalAsync();
		}
	}
}