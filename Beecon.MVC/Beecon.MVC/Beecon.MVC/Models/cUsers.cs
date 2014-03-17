using Beecon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beecon.MVC.Models
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