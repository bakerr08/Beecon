using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beecon.MVC.Models;

namespace Beecon.MVC.DAL
{
    public class BeeconInitializer
    {
        public void Seed(BeeconDBEntitiesBOB context)
        {
            string email = "test@beecon.com";
            string password = "test";        

            if (email == null)
            {
                User.createUser(email, password);
                var user = context.Users.SingleOrDefault(u => u.Email == email);
                context.SaveChanges();
            }
           
        }
    }
}