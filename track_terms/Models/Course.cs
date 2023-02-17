using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using track_terms.Services;


namespace track_terms.Models
{
	public class Course
	{
		public int TermId { get; set; }

		[PrimaryKey, AutoIncrement]
		public int CourseId { get; set; }
		public string CourseName { get; set; }
		public string Status { get; set; }
		public DateTime CourseStart { get; set; }
		public DateTime CourseEnd { get; set; }
		public int InstructorId { get; set; }
		public int AssessmentId { get; set; }

		public string startOutput => $"Starts on {CourseStart.ToShortDateString()}";
		public string endOutput => $"Ends on {CourseEnd.ToShortDateString()}";
		public string CourseOutput => $"{CourseName} {Status} {Environment.NewLine} {CourseStart} {CourseEnd}";

		public Course(int TermId, string status, string name, DateTime start, DateTime end, int instruct_id, int assess_id)
		{
			this.TermId = TermId;
			Status = status;
			CourseName = name;
			CourseStart = start;
			CourseEnd = end;
			InstructorId = instruct_id;
			AssessmentId = assess_id;
		}

		public Course() { }

		//constructor without assessment
		public Course(int TermId, string status, string name, DateTime start, DateTime end, int instruct_id)
		{
			this.TermId = TermId;
			Status = status;
			CourseName = name;
			CourseStart = start;
			CourseEnd = end;
			InstructorId = instruct_id;
		}

	}
}
