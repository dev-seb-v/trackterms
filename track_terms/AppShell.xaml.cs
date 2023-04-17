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
			Routing.RegisterRoute("HomePage", typeof(HomePage));
			Routing.RegisterRoute("HomePage/AddTerm", typeof(AddTerm));
			Routing.RegisterRoute("HomePage/AddCourse", typeof(AddCourse));
			Routing.RegisterRoute("HomePage/ViewTerms", typeof(ViewTerms));
			Routing.RegisterRoute("HomePage/CourseDetailPage", typeof(CourseDetailPage));
			Routing.RegisterRoute("HomePage/ForTesting", typeof(ForTesting));
			Routing.RegisterRoute("HomePage/UpdateCourse", typeof(UpdateCourse));
			Routing.RegisterRoute("HomePage/ReportPage", typeof(ReportPage));
			Routing.RegisterRoute("HomePage/SearchPage", typeof(SearchPage));
			Routing.RegisterRoute("AppShell/HomePage", typeof(AppShell));
			Routing.RegisterRoute("HomePage/ViewTerms/UpdateTerm", typeof(UpdateTerm));
		}

	}
}
