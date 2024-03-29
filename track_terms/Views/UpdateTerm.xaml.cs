﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using track_terms.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace track_terms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UpdateTerm : ContentPage
	{
		int id = ViewTerms.termId;
		public UpdateTerm()
		{
			InitializeComponent();
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			nameEntry.Text = DB.GetTermName(id);
			startDatePicker.Date = DB.GetTermStart(id);
			endDatePicker.Date = DB.GetTermEnd(id);
		}

		private void cancelButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PopModalAsync();
		}
		private void saveTermButton_Clicked(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(nameEntry.Text))
			{
				DisplayAlert("Term Name", "Please enter a name for term", "Ok");
				return;
			}
			if (startDatePicker.Date > endDatePicker.Date)
			{
				DisplayAlert("Invalid Date", "The end of the term cannot be before the start", "Ok");
				return;
			}
			else
			{
				DB.UpdateTerm(id, nameEntry.Text, startDatePicker.Date, endDatePicker.Date);
				(Application.Current).MainPage = new AppShell();
			}

		}
	}
}