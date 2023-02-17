using System;
using System.Collections.Generic;
using System.Text;

namespace track_terms.Models
{
	class Status
	{
		public string status { get; set; }

		public List<Status> statuses = new List<Status>();
		public Status()
		{
			statuses.Add(new Status("Planning To Take"));
			statuses.Add(new Status("In Progress"));
			statuses.Add(new Status("Completed"));
		}

		public Status(string s)
		{
			status = s;
		}
	}
}
