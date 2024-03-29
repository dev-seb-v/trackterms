﻿using System;
using track_terms.Models;
using track_terms.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace track_terms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UpdateCourse : ContentPage
	{
		Status  S = new Status();
		public static string status;
		public static int id;
		public static int teacherId;
		public UpdateCourse()
		{
			InitializeComponent();
		}
		protected override void OnAppearing()
		{

			base.OnAppearing();

			id = HomePage.courseId;
			teacherId = DB.GetInstructorId(id);
			CourseNameEntry.Text = DB.returnCourseName(id);
			StartPicker.Date = DB.GetCourseStart(id);
			EndPicker.Date = DB.GetCourseEnd(id);
			StatusPicker.ItemsSource = S.statuses;
			instructorEntry.Text = DB.GetInstructorName(teacherId);
			InstructorPhone.Text = DB.GetInstructorPhone(teacherId);
			InstructorEmailEntry.Text = DB.GetInstructorEmail(teacherId);
		}

		private void saveCourseBtn_Clicked(object sender, EventArgs e)
		{

			if (!TextValidated() || !ObjectsValidated())
			{
				DisplayAlert("Missing Item", "Please check for missing item", "OK");
				return;
			}
			if (StartPicker.Date > EndPicker.Date)
			{
				DisplayAlert("Invalid Date", "The end of the course cannot be before the start", "Ok");
				return;
			}
			else 
			{
				var status = StatusPicker.SelectedItem as Status;
				DB.UpdateCourse(
					id,
					teacherId,
					instructorEntry.Text,
					InstructorPhone.Text,
					InstructorEmailEntry.Text,
					CourseNameEntry.Text,
					status.status,
					StartPicker.Date,
					EndPicker.Date
					);
				Navigation.PopModalAsync();
			}
		}

		private bool TextValidated()
		{
			if (String.IsNullOrEmpty(instructorEntry.Text) ||
				String.IsNullOrEmpty(InstructorPhone.Text) ||
				String.IsNullOrEmpty(InstructorEmailEntry.Text) ||
				String.IsNullOrEmpty(CourseNameEntry.Text))
			{
				return false;
			}

			else
			{
				return true;
			}
		}

		private bool ObjectsValidated()
		{
			if (StatusPicker.SelectedItem == null ||
				StartPicker.Date == null ||
				EndPicker.Date == null)
			{
				return false;
			}

			else 
			{
				return true;
			}
		}
	}
}