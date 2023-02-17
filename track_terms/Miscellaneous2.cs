using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using track_terms.Models;
using track_terms.Services;


namespace track_terms
{
	public class Miscellaneous2 : Course
	{
		public static List<string> ReturnCourseItems()
		{
			DB.Init();
			var allInstructorRecords = DB._dbConnection.Query<Instructor>("SELECT * FROM Instructor");
			List<string> strings = new List<string>();
			foreach (var instructor in allInstructorRecords)
			{
				strings.Add(instructor.InstructorName);
				Console.WriteLine(instructor.InstructorName);
			}

			return strings;
		}
	}
}
