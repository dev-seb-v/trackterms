using System;
using track_terms.Services;

namespace TestingServices
{
	class Program
	{
		static void Main(string[] args)

		{
			bool match = TestCourseOutput();
			if (match)
			{
				Console.WriteLine("Test Passes!");
			}
			else
			{
				Console.WriteLine("Test Fails!");
			}
		}

		public static bool TestCourseOutput()
		{
			var termName = DB.GetTermName(1);

			string term = "Spring 2023";

			if (termName == term)
			{
				return true;
			}
			else return false;
		}
	}
}
