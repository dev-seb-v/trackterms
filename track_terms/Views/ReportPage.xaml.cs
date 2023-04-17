using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using track_terms.Models;
using track_terms.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace track_terms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReportPage : ContentPage
	{
		int term_id;
		Term t = new Term();
		public ReportPage()
		{
			InitializeComponent();
			using (SQLiteConnection con = new SQLiteConnection(DB.databasePath))
			{
				con.CreateTable<Term>();
				List<Term> terms = con.Table<Term>().ToList();
				termPicker.ItemsSource = terms;
			}
		}

		private void termPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			greetingLabel.IsVisible = false;
			t = (Term)termPicker.SelectedItem;
			term_id = t.TermId;
			numClassesLabel.Text = DB.ReturnNumOfCourses(term_id).ToString();
			numClassesCompleteLabel.Text = DB.ReturnNumOfCompleted(term_id).ToString();
			daysLeftLabel.Text = (HelperClass.GetTermEnd(term_id) - DateTime.Today).TotalDays.ToString();
			classesLeftLabel.Text = DB.ReturnNumOfInComplete(term_id).ToString();
		}
	}
}