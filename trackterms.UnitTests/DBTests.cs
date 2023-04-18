using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using track_terms.Services;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.IO;
using System.Collections.Generic;
using track_terms.Models;


namespace trackterms.UnitTests
{
	[TestClass]
	public class DBTests
	{
		[TestMethod]
		public void GetTermName_PassTermId_ReturnsTermName()
		{
			// Arrange
			string termName = "Spring 2023";
			//Act
			string result = DB.GetTermName(1);
			// Assert
			Assert.Equals(termName, result);
		}
	}
}
