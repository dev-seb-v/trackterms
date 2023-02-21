using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using track_terms.Services;

namespace track_terms.Models
{
	public class Bools
	{
		[PrimaryKey, AutoIncrement]
		public int BoolId { get; set; }
		public bool Name { get; set; }
		public bool CourseDates { get; set; }
		public bool CourseStatus { get; set; }
		public bool Instruct { get; set; }
		public bool OA { get; set; }
		public bool PA { get; set; }

		public Bools(bool name, bool dates, bool status, bool teach, bool O, bool P)
		{
			Name = name;
			CourseDates = dates;
			CourseStatus = status;
			Instruct = teach;
			OA = O;
			PA = P;
		}

		public Bools()
		{

		}
	}
}
