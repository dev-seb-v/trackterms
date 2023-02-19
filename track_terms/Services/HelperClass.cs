using System;
using System.Collections.Generic;
using System.Text;
using track_terms.Models;
using track_terms.Services;
using System.Linq;

namespace track_terms.Services
{
	public static class HelperClass
	{

		public static string returnCourseName(int id)
		{
			DB.Init();

			var rowData = DB._db.Table<Course>().FirstOrDefault(i => i.CourseId == id);

			if (rowData != null)
			{
				return rowData.CourseName;
			}
			else { return "not found"; }

		}

		public static string returnStartOuput(int id)
		{
			DB.Init();

			var rowData = DB._db.Table<Course>().FirstOrDefault(i => i.CourseId == id);

			if (rowData != null)
			{
				return rowData.startOutput;
			}
			else { return "not found"; }

		}
		public static string returnEndOutput(int id)
		{
			DB.Init();

			var rowData = DB._db.Table<Course>().FirstOrDefault(i => i.CourseId == id);

			if (rowData != null)
			{
				return rowData.endOutput;
			}
			else { return "not found"; }

		}

		//public static IEnumerable<CourseStatus> status(Course course)
		//{
		//	DB.Init();
		//	return DB._dbConnection.Query<CourseStatus>("select StatusDescription from CourseStatus where StatusId = ?", course.CourseId);
		//}

		//public static string getStatus(IEnumerable<CourseStatus> status, int id) 
		//{
		//	return status.First(s => s.StatusId == id).StatusDescription;
		//}

		public static string getStatus(int id)
		{
			DB.Init();
			var rowData = DB._db.Table<Course>().FirstOrDefault(i => i.CourseId == id);

			if (rowData != null)
			{
				return rowData.Status;
			}
			else { return "not found"; }
		}

		public static int GetInstructorId(int id)
		{
			DB.Init();
			var rowData = DB._db.Table<Course>().FirstOrDefault(i => i.CourseId == id);

			if (rowData != null)
			{
				return rowData.InstructorId;
			}
			else { return 0; }
		}

		public static string GetInstructorName(int id)
		{
			DB.Init();
			var rowData = DB._db.Table<Instructor>().FirstOrDefault(i => i.InstructorId == id);

			if (rowData != null)
			{
				return rowData.InstructorName;
			}
			else { return "not found"; }
		}

		public static string GetInstructorPhone(int id)
		{
			DB.Init();
			var rowData = DB._db.Table<Instructor>().FirstOrDefault(i => i.InstructorId == id);

			if (rowData != null)
			{
				return rowData.InstructorPhoneNum;
			}
			else { return "not found"; }
		}

		public static string GetInstructorEmail(int id)
		{
			DB.Init();
			var rowData = DB._db.Table<Instructor>().FirstOrDefault(i => i.InstructorId == id);

			if (rowData != null)
			{
				return rowData.InstructorEmail;
			}
			else { return "not found"; }
		}

		public static DateTime GetCourseStart(int id)
		{
			DateTime d = DateTime.Now;
			DB.Init();
			var rowData = DB._db.Table<Course>().FirstOrDefault(i => i.CourseId == id);

			if (rowData != null)
			{
				return rowData.CourseStart;
			}
			else
			{
				// will return generic date if not found in table
				return d;
			}
		}
		public static DateTime GetCourseEnd(int id)
		{
			DateTime d = DateTime.Now;
			DB.Init();
			var rowData = DB._db.Table<Course>().FirstOrDefault(i => i.CourseId == id);

			if (rowData != null)
			{
				return rowData.CourseEnd;
			}
			else
			{
				// will return generic date if not found in table
				return d;
			}
		}

		public static void UpdateCourse(int id, int instructorId, string instructorName, string number, string email, String name, String status, DateTime start, DateTime end)
		{
			DB.Init();

			var CourseQuery = DB._db.Table<Course>().Where(i => i.CourseId == id).FirstOrDefault();
			var InstructorQuery = DB._db.Table<Instructor>().Where(i => i.InstructorId == instructorId).FirstOrDefault();

			if (InstructorQuery != null)
			{
				InstructorQuery.InstructorName = instructorName;
				InstructorQuery.InstructorPhoneNum = number;
				InstructorQuery.InstructorEmail = email;
			}

			if (CourseQuery != null)
			{
				CourseQuery.CourseName = name;
				CourseQuery.Status = status;
				CourseQuery.CourseStart = start;
				CourseQuery.CourseEnd = end;
			}

			DB._db.Update(InstructorQuery);
			DB._db.Update(CourseQuery);

		}

		public static void AddAssessment(int courseId, string name, string type, string notes)
		{
			DB.Init();
			Assessment A = new Assessment()
			{
				CourseId = courseId,
				AssessmentName = name,
				AssessmentNotes = notes
			};

			DB._db.Insert(A); 

			var id = A.AssessmentId;
		}

		public static string GetAssessmentInfo(int id)
		{
			DB.Init();
			var rowData = DB._db.Table<Assessment>().FirstOrDefault(i => i.CourseId == id);

			if (rowData != null)
			{
				return rowData.AssessmentName;
			}
			else { return "not found"; }
		}
	}
}
