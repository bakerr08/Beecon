using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Beecon.Models
{
	public class cUsers
	{
		List<cUser> oUsers;

		public List<cUser> Users
		{
			get { return oUsers; }
			set { oUsers = value; }
		}

		// Custom Constructor
		public cUsers()
		{
			oUsers = new List<cUser>();
		}
		public int Count
		{
			get { return oUsers.Count; }
		}
	}
}

