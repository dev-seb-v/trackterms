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
	public partial class ViewTerms : ContentPage
	{
		public static int termId;
		public ViewTerms()
		{
			InitializeComponent();
		}

		protected override void OnDisappearing()
		{
			// kept getting an error that the home page object didn't exist when
			// this page was closed so added instantiation of home page
			base.OnDisappearing();
			HomePage homePage = new HomePage();
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			TermView.ItemsSource = null;
			using (SQLiteConnection con = new SQLiteConnection(DB.databasePath))
			{
				con.CreateTable<Course>();
				List<Term> terms = con.Table<Term>().ToList();
				TermView.ItemsSource = terms;
			}
			if (TermView.SelectedItem == null)
			{
				DeleteTermButton.IsEnabled = false;
			}
		}

		private void CancelButton_Clicked(object sender, EventArgs e)
		{
			Shell.Current.GoToAsync("HomePage");
		}

		private void TermView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			termId = (e.CurrentSelection.FirstOrDefault() as Term).TermId;
			DeleteTermButton.IsEnabled = true;
		}
		private void DeleteTermButton_Clicked(object sender, EventArgs e)
		{
			DB.RemoveTerm(termId);
			Navigation.PushAsync(new HomePage());
		}
	}
}