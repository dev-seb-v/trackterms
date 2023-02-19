using System;
using System.Collections.Generic;
using System.Text;
using Plugin.LocalNotifications;


namespace track_terms.Models
{
	public class Assessment
	{
		// TODO trying to incorporate assessment into course

		public string AssessmentName { get; set; }
		public string AssessmentNotes { get; set; }

		// main constructor
		public Assessment(int courseId, string name, string type, string notes)
		{
			AssessmentName = name;
			AssessmentNotes = notes;
		}

		public Assessment()
		{
		}
	}
}
