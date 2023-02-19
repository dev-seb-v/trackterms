using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace track_terms.Models
{
	public class PerformanceAssessment : Assessment
	{
		[PrimaryKey, AutoIncrement]
		public int PerformanceId { get; set; }
		public int CourseId { get; set; }

		public PerformanceAssessment(int courseId, string name,  string notes)
		{
			CourseId = courseId;
			AssessmentName = name;
			AssessmentNotes = notes;
		}
	}
}
