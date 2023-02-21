using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace track_terms.Models
{
	public class Instructor 
	{
		[PrimaryKey, AutoIncrement]
		public int InstructorId { get; set; }
		public string InstructorName { get; set; }
		public string InstructorPhoneNum { get; set; }
		public string InstructorEmail { get; set; }

		public List<Instructor> instructors = new List<Instructor>();



		public Instructor(string name, string phone, string email)
		{
			InstructorName = name;
			InstructorPhoneNum = phone;
			InstructorEmail = email;
		}
		// override constructor 
		public Instructor()
		{
			LoadInstructors();
		}

		private void LoadInstructors()
		{
			Instructor a = new Instructor("Nathaniel Richards", "888-100-1000", "Kang@TVA.org");
			Instructor b = new Instructor("Charles Xavier", "888-100-1001", "Xavier@X-Corporation.org");
			Instructor c = new Instructor("Bruce Banner", "888-100-1002", "Bruce@StarkIndustries.org");
			Instructor d = new Instructor("Tony Stark", "888-100-1003", "Tony@StarkIndustries.org");
			Instructor e = new Instructor("Stan Lee", "888-100-1004", "Stanley@excelsior.org");

			instructors.Add(a);
			instructors.Add(b);
			instructors.Add(c);
			instructors.Add(d);
			instructors.Add(e);
		}
	}
}
