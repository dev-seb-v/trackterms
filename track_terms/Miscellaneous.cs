using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using track_terms.Models;
using track_terms.Services;

namespace track_terms
{
	public class Miscellaneous : Instructor
	{
		public static string ReturnInstructorName(int id) 
		{
			DB.Init();
			var rowData = DB._db.Table<Instructor>().FirstOrDefault(i => i.InstructorId == id);

			if (rowData != null)
			{
				return rowData.InstructorName;
			}
			else { return "not found"; }
		}

	}
}
