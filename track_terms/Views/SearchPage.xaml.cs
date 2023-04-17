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
	public partial class SearchPage : ContentPage
	{
		int term_id;
		Term t = new Term();
		public SearchPage()
		{
			InitializeComponent();
			using (SQLiteConnection con = new SQLiteConnection(DB.databasePath))
			{
				con.CreateTable<Term>();
				List<Term> terms = con.Table<Term>().ToList();
				termPicker.ItemsSource = terms;
			}
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			HomePage hp = new HomePage();
		}
		private void searchBtn_Clicked(object sender, EventArgs e)
		{
			if (courseNameEntry.Text == "")
			{
				DisplayAlert("Error", "Please enter a class",  "Ok");
			}
			else
			{
				try
				{
					courseOutputLabel.Text = DB.GetCourseName(courseNameEntry.Text);
				}
				catch 
				{
					DisplayAlert("Not found", "Check spelling. Search is case sensitive", "Ok");
					(Application.Current).MainPage = new AppShell();
				}
			
			}
		}

		private void termPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			t = (Term)termPicker.SelectedItem;
			term_id = t.TermId;
		}
	}
}