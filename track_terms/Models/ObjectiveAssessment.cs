using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace track_terms.Models
{
	public class ObjectiveAssessment
	{
		[AutoIncrement, PrimaryKey]
		public int ObjectiveId { get; set; }
		public int CourseId { get; set; }
		public string ObjAssessName { get; set; }
		public string ObjAssessNotes { get; set; }
		public DateTime DueDate { get; set; }


		public string ObjAssessOutput => $"{ObjAssessName} is due on {DueDate.ToShortDateString()}" +
			$" {Environment.NewLine} {ObjAssessNotes} ";
		public ObjectiveAssessment(int id, string name, string notes, DateTime due)
		{
			CourseId = id;
			ObjAssessName = name;
			ObjAssessNotes = notes;
			DueDate = due;
		}

		public ObjectiveAssessment()
		{
		}
	}
	}
