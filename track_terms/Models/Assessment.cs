using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace track_terms.Models
{
	public class Assessment
	{
		[PrimaryKey, AutoIncrement]
		public int AssessmentId { get; set; }
		public string AssessmentName { get; set; }
		public DateTime AssessmentStart { get; set; }
		public DateTime AssessmentEnd { get; set; }
		public string AssessmentType { get; set; }
		public string AssessmentNotes { get; set; }

	}
}
