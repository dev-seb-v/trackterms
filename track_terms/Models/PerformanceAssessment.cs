using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace track_terms.Models
{
	public class PerformanceAssessment 
	{
		[PrimaryKey, AutoIncrement]
		public int PerformanceId { get; set; }
		public int CourseId { get; set; }
		public string PerfAssessName { get; set; }
		public string PerfAssessNotes { get; set; }
		public DateTime DueDate { get; set; }
		public string PerfAssessOutput => $"{PerfAssessName} is due on {DueDate.ToShortDateString()}{Environment.NewLine}" +
			$"{PerfAssessNotes}";
		public PerformanceAssessment(int id, string name, string notes, DateTime due)
		{
			CourseId = id;
			PerfAssessName = name;
			PerfAssessNotes = notes;
			DueDate = due;
		}

		public PerformanceAssessment()
		{

		}
	}
}
