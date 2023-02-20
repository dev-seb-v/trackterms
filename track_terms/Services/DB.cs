using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;
using Xamarin.Essentials;

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
			HelperClass.AddObjAssessment(1, "Midterm Exam", "Study Chapter on Pruning", due);
			HelperClass.AddPerfAssessment(1, "Prune a Hawthorn", "Study Chapter 11", due);
		}

		public static void ClearData()
		{
			Init();

			_db.DropTable<Term>();
			_db.DropTable<Course>();
			_db.DropTable<Instructor>();
			_db.DropTable<ObjectiveAssessment>();
			_db.DropTable<PerformanceAssessment>();

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
	}
}
