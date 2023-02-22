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
		public static void AddObjAssessment(int id, string name, string notes, DateTime due)
		{

			ObjectiveAssessment OA = new ObjectiveAssessment()
			{
				CourseId = id,
				ObjAssessName = name,
				ObjAssessNotes = notes,
				DueDate = due
			};
			DB.Init();
			DB._db.Insert(OA);
		}

		public static void AddPerfAssessment(int id, string name, string notes, DateTime due)
		{

			PerformanceAssessment PA = new PerformanceAssessment()
			{
				CourseId = id,
				PerfAssessName = name,
				PerfAssessNotes = notes,
				DueDate = due
		};
			DB.Init();
			DB._db.Insert(PA);
		}

		public static string GetObjAssessOutput(int id)
		{
			
			DB.Init();
			var rowData = DB._db.Table<ObjectiveAssessment>().FirstOrDefault(i => i.CourseId == id);

			if (rowData != null)
			{
				return rowData.ObjAssessOutput;
			}
			else
			{
				// will return generic date if not found in table
				return "not found";
			}
		}

		public static string GetPerfAssessOutput(int id)
		{

			DB.Init();
			var rowData = DB._db.Table<PerformanceAssessment>().FirstOrDefault(i => i.CourseId == id);

			if (rowData != null)
			{
				return rowData.PerfAssessOutput;
			}
			else
			{
				// will return generic date if not found in table
				return "not found";
			}
		}

		public static void SetObjAssessmentToEmpty(int id) 
		{
			DB.Init();

			var Query = DB._db.Table<ObjectiveAssessment>().Where(i => i.CourseId == id).FirstOrDefault();

			DateTime date = new DateTime();
			if (Query != null)
			{
				Query.ObjAssessName = "none";
				Query.ObjAssessNotes = "none";
				Query.DueDate = date;
			}

			DB._db.Update(Query);

		}

		public static void SetPerfAssessmentToEmpty(int id)
		{
			DB.Init();

			var Query = DB._db.Table<PerformanceAssessment>().Where(i => i.CourseId == id).FirstOrDefault();

			DateTime date = new DateTime();
			if (Query != null)
			{
				Query.PerfAssessName = "none";
				Query.PerfAssessNotes = "none";
				Query.DueDate = date;
			}

			DB._db.Update(Query);

		}
		public static void UpdateObjAssessment(int id, string name, string notes, DateTime due)
		{
			DB.Init();
			var Query = DB._db.Table<ObjectiveAssessment>().Where(i => i.CourseId == id).FirstOrDefault();
			if (Query != null)
			{
				Query.ObjAssessName = name;
				Query.ObjAssessNotes = notes;
				Query.DueDate = due;
			}
			DB._db.Update(Query);
		}
		public static void UpdatePerfAssessment(int id, string name, string notes, DateTime due)
		{
			DB.Init();
			var Query = DB._db.Table<PerformanceAssessment>().Where(i => i.CourseId == id).FirstOrDefault();
			if (Query != null)
			{
				Query.PerfAssessName = name;
				Query.PerfAssessNotes = notes;
				Query.DueDate = due;
			}
			DB._db.Update(Query);
		}
		public static string GetObjAssessName(int id)
		{
			DB.Init();
			var rowData = DB._db.Table<ObjectiveAssessment>().FirstOrDefault(i => i.CourseId == id);
			if (rowData != null)
			{
				return rowData.ObjAssessName;
			}
			else
			{
				// will return generic date if not found in table
				return "not found";
			}
		}

		public static DateTime GetObjAssessDate(int id)
		{
			DB.Init();
			var rowData = DB._db.Table<ObjectiveAssessment>().FirstOrDefault(i => i.CourseId == id);

			if (rowData != null)
			{
				return rowData.DueDate;
			}
			else
			{
				// will return generic date if not found in table
				return DateTime.MinValue;
			}
		}
		public static string GetObjAssessNotes(int id)
		{
			DB.Init();
			var rowData = DB._db.Table<ObjectiveAssessment>().FirstOrDefault(i => i.CourseId == id);

			if (rowData != null)
			{
				return rowData.ObjAssessNotes;
			}
			else
			{
				// will return generic date if not found in table
				return "not found";
			}

		}
		public static string GetPerfAssessNotes(int id)
		{
			DB.Init();
			var rowData = DB._db.Table<PerformanceAssessment>().FirstOrDefault(i => i.CourseId == id);

			if (rowData != null)
			{
				return rowData.PerfAssessNotes;
			}
			else
			{
				// will return generic date if not found in table
				return "not found";
			}

		}
		public static DateTime GetPerfAssessDate(int id)
		{
			DB.Init();
			var rowData = DB._db.Table<PerformanceAssessment>().FirstOrDefault(i => i.CourseId == id);

			if (rowData != null)
			{
				return rowData.DueDate;
			}
			else
			{
				// will return generic date if not found in table
				return DateTime.MinValue;
			}
		}
		public static string GetPerfAssessName(int id)
		{
			DB.Init();
			var rowData = DB._db.Table<PerformanceAssessment>().FirstOrDefault(i => i.CourseId == id);
			if (rowData != null)
			{
				return rowData.PerfAssessName;
			}
			else
			{
				// will return generic date if not found in table
				return "not found";
			}
		}
	}
}
