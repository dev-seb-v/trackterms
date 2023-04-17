using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;

using track_terms.Models;

namespace track_terms.Services
{
	public static class DB
	{
		public static SQLiteConnection _db;
		public static SQLiteConnection _dbConnection;
		public static string databasePath = Path.Combine(FileSystem.AppDataDirectory, "TermTracker.db");

		public static void Init()
		{
			if (_db != null)
			{
				return;
			}

			var databasePath = Path.Combine(FileSystem.AppDataDirectory, "TermTracker.db");

			_db = new SQLiteConnection(databasePath);
			_dbConnection = new SQLiteConnection(databasePath);

			_db.CreateTable<Term>();
			_db.CreateTable<Course>();
			_db.CreateTable<Instructor>();
			_db.CreateTable<PerformanceAssessment>();
			_db.CreateTable<ObjectiveAssessment>();
			_db.CreateTable<Bools>();
		}

		#region Terms methods

		public static void AddTerm(String name, DateTime start, DateTime end)
		{
			Init();
			Models.Term term = new Models.Term()
			{
				TermName = name,
				TermStart = start,
				TermEnd = end
			};

			_db.Insert(term);

			var id = term.TermId;
		}

		public static void RemoveTerm(int id)
		{
			Init();

			_db.Delete<Term>(id);
		}

		public static List<Term> ReadTerms(int termId)
		{
			Init();

			var terms = _db.Table<Term>().Where(i => i.TermId == termId).ToList();
			return terms;
		}

		public static void UpdateTerm(int id, String name, DateTime start, DateTime end)
		{
			Init();

			var termQuery = _db.Table<Term>().Where(i => i.TermId == id).FirstOrDefault();

			if (termQuery != null)
			{
				termQuery.TermName = name;
				termQuery.TermStart = start;
				termQuery.TermEnd = end;
			}

			_db.Update(termQuery);
		}


		#endregion

		#region Course methods

		#endregion

		#region Load data methods

		public static void LoadData()
		{
			Init();
			AddBool();
			Status s = new Status();
			string status = "In Progress";
			string startofTerm = "2023/01/01";
			string endOfTerm = "2023/06/30";
			string dueDate = "2023/04/15";
			DateTime start = Convert.ToDateTime(startofTerm);
			DateTime end = Convert.ToDateTime(endOfTerm);
			DateTime due = Convert.ToDateTime(dueDate);
			DB.AddInstructor("Sebastian Valenzuela", "909-316-99548", "svale59@wgu.edu");
			DB.AddTerm("Spring 2023", start, end);
			DB.AddCourse(1, status, "History of Ornamental Hedges", start, end, 1);
			DB.AddObjAssessment(1, "Midterm Exam", "Study Chapter on Pruning", due);
			DB.AddPerfAssessment(1, "Prune a Hawthorn", "Study Chapter 11", due);
		}

		public static void ClearData()
		{
			Init();

			_db.DropTable<Term>();
			_db.DropTable<Course>();
			_db.DropTable<Instructor>();
			_db.DropTable<ObjectiveAssessment>();
			_db.DropTable<PerformanceAssessment>();
			_db.DropTable<Bools>();

			_db = null;
			_dbConnection = null;
		}

		public static void LoadDataSql()
		{
			Init();

		}

		#endregion

		#region 

		public static string GrabTermName(int id)
		{
			Init();
			var rowData = _db.Table<Term>().FirstOrDefault(i => i.TermId == id);

			if (rowData != null)
			{
				return rowData.TermName;
			}
			else { return "not found"; }
		}

		// need the object<Term> for example to be generic, string tableId (TermId), int id, datarow wanting to return
		

		//Looping through table records
		public static void LoopingTermTable()
		{

			Init();

			var allTerms = _dbConnection.Query<Term>("SELECT * FROM Term");

			foreach (var term in allTerms)
			{
				Console.WriteLine("Name" + term.TermName);
			}

		}

		public static List<Term> GetNotificationsTerms()
		{
			Init();

			var allTermRecords = _dbConnection.Query<Term>("SELECT * FROM Term");

			return allTermRecords;
		}

		#endregion

		#region Instructor methods
		public static void AddInstructor(String name, String phone, String email)
		{
			Init();

			Instructor i = new Instructor()
			{
				InstructorName = name,
				InstructorPhoneNum = phone,
				InstructorEmail = email

			};


			_db.Insert(i);

			var id = i.InstructorId ;
		}


		#endregion

		#region generic methods
		public static void AddItem<T>(T item)
		{
			Init();
			_db.Insert(item);
		}

		#endregion

		#region Course Methods

		public static void AddCourse(int id, string status, string name, DateTime start, DateTime end, int instructor_id) 
		{
			Course course = new Course()
			{ 
				TermId = id,
				Status = status,
				CourseName = name,
				CourseStart = start,
				CourseEnd = end,
				InstructorId = instructor_id
			};

			Init();
			_db.Insert(course);
		}

		public static List<Course> ReadCourses(int termId)
		{
			Init();

			var courses = _db.Table<Course>().Where(i => i.TermId == termId).ToList();
			return courses;
		}

		public static List<Course> ReadSpecificCourse(int cId)
		{
			Init();

			var courses = _db.Table<Course>().Where(i => i.CourseId == cId).ToList();
			return courses;
		}

		public static void RemoveCourse(int id)
		{
			Init();

			_db.Delete<Course>(id);
		}

		#endregion
		public static void AddBool()
		{
			Bools B = new Bools(true, true, true, true, true, true);
			DB.Init();
			DB._db.Insert(B);
		}

		public static void UpdateNameBool (int id, bool change)
		{
			Init();

			var Query = _db.Table<Bools>().Where(i => i.BoolId == id).FirstOrDefault();

			if (Query != null)
			{
				Query.Name = change;
			}

			_db.Update(Query);
		}

		public static void UpdateDatesBool(int id, bool change)
		{
			Init();

			var Query = _db.Table<Bools>().Where(i => i.BoolId == id).FirstOrDefault();

			if (Query != null)
			{
				Query.CourseDates = change;
			}

			_db.Update(Query);
		}

		public static void UpdateStatusBool(int id, bool change)
		{
			Init();

			var Query = _db.Table<Bools>().Where(i => i.BoolId == id).FirstOrDefault();

			if (Query != null)
			{
				Query.CourseStatus = change;
			}

			_db.Update(Query);
		}

		public static void UpdateInstructorBool(int id, bool change)
		{
			Init();

			var Query = _db.Table<Bools>().Where(i => i.BoolId == id).FirstOrDefault();

			if (Query != null)
			{
				Query.Instruct = change;
			}

			_db.Update(Query);
		}

		public static void UpdateOABool(int id, bool change)
		{
			Init();

			var Query = _db.Table<Bools>().Where(i => i.BoolId == id).FirstOrDefault();

			if (Query != null)
			{
				Query.OA = change;
			}

			_db.Update(Query);
		}

		public static void UpdatePABool(int id, bool change)
		{
			Init();

			var Query = _db.Table<Bools>().Where(i => i.BoolId == id).FirstOrDefault();

			if (Query != null)
			{
				Query.PA = change;
			}

			_db.Update(Query);
		}

		public static Bools GetBool(int id)
		{

			DB.Init();
			Bools b = DB._db.Table<Bools>().FirstOrDefault(i => i.BoolId == id);

			if (b != null)
			{
				return b;
			}
			else
			{
				// will return generic date if not found in table
				return null;
			}
		}

		public static int ReturnNumOfCourses(int termId)
		{
			Init();
			int count = 0;
			var courses = _db.Table<Course>().Where(i => i.TermId == termId).ToList();

			courses.ForEach(delegate (Course c)
			{
				count++;
			});
			return count;
		}

		public static int ReturnNumOfCompleted(int termId)
		{
			Init();
			int count = 0;
			var courses = _db.Table<Course>().Where(i => i.TermId == termId).ToList();

			for (int i = 0; i < courses.Count; i++)
			{
				if (courses[i].Status == "Completed")
				{
					count++;
				}
			}
			return count;
		}
		public static int ReturnNumOfInComplete(int termId)
		{
			Init();
			int count = 0;
			var courses = _db.Table<Course>().Where(i => i.TermId == termId).ToList();

			for (int i = 0; i < courses.Count; i++)
			{
				if (courses[i].Status != "Completed")
				{
					count++;
				}
			}
			return count;
		}

		public static string GetCourseName(string name)
		{
			Init();
			var query = _db.Query<Course>("select CourseName from Course where CourseName = ?", name);

			if (query != null)
			{
				return query[0].CourseName.ToString() + "  Found!";
			}
			else
			{
				return "not found";

			}
				
		}

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

		public static string SearchForCourseName(int id, string course)
		{
			DB.Init();

			var rowData = DB._db.Table<Course>().FirstOrDefault(i => i.TermId == id);

			if (rowData.CourseName == course)
			{
				return course;
			}
			else { return "Course not found"; }
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

		public static int GetCourseId(string CourseName)
		{
			DB.Init();
			// passing in an object of type Course and the Course Name 
			var query = DB._db.Query<Course>("select CourseId from Course where CourseName = ?", CourseName);

			if (query != null)
			{
				// return the courseid
				return query[0].CourseId;
			}
			else
			{
				return -999;
			}
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

		public static string GetTermName(int id)
		{
			DB.Init();
			var rowData = DB._db.Table<Term>().FirstOrDefault(i => i.TermId == id);
			if (rowData != null)
			{
				return rowData.TermName;
			}
			else
			{
				// will return generic date if not found in table
				return "not found";
			}
		}
		public static DateTime GetTermStart(int id)
		{
			DB.Init();
			var rowData = DB._db.Table<Term>().FirstOrDefault(i => i.TermId == id);
			if (rowData != null)
			{
				return rowData.TermStart;
			}
			else
			{
				// will return generic date if not found in table
				return DateTime.MinValue;
			}
		}
		public static DateTime GetTermEnd(int id)
		{
			DB.Init();
			var rowData = DB._db.Table<Term>().FirstOrDefault(i => i.TermId == id);
			if (rowData != null)
			{
				return rowData.TermEnd;
			}
			else
			{
				// will return generic date if not found in table
				return DateTime.MinValue;
			}
		}

	}
}
