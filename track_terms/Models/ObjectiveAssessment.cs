using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace track_terms.Models
{
	public class ObjectiveAssessment : Assessment
	{
		[AutoIncrement, PrimaryKey]
		public int ObjectiveId { get; set; }
		public int CourseId { get; set; }

		public ObjectiveAssessment(int courseId, string name, string notes)
		{
			CourseId = courseId;
			AssessmentName = name;
			AssessmentNotes = notes;
		}
	}
}
