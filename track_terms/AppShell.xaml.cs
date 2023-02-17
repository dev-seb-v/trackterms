using System;
using System.Collections.Generic;
using Xamarin.Forms;
using track_terms.Views;

namespace track_terms
{
	public partial class AppShell : Xamarin.Forms.Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
			Routing.RegisterRoute("HomePage/AddTerm", typeof(AddTerm));
			Routing.RegisterRoute("HomePage/AddCourse", typeof(AddCourse));
			Routing.RegisterRoute("HomePage/ViewTerms", typeof(ViewTerms));
			Routing.RegisterRoute("HomePage/ViewCourse", typeof(CourseDetailPage));
			Routing.RegisterRoute("HomePage/ForTesting", typeof(ForTesting));
			Routing.RegisterRoute("HomePage/UpdateCourse", typeof(UpdateCourse));
		}

		protected override bool OnBackButtonPressed()
		{
			return true;			
		}
	}
}
