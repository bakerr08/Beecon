using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;

namespace Beecon.MVC.Models
{
    public partial class User
    {
        public enum UserCreateStatus
        {
            Success,
            UserExists,
            Error
        };


        //creates a user if there isn't one. BOB
        public static UserCreateStatus createUser(string email, string password)
        {
            try
            {
                var membership = (SimpleMembershipProvider)Membership.Provider;
                if (membership.GetUser(email, false) == null)
                {
                    membership.CreateUserAndAccount(email, password);
                    return UserCreateStatus.Success;
                }
                else
                {
                    return UserCreateStatus.UserExists;
                }
            }
            catch (Exception)
            {
                return UserCreateStatus.Error;
            }
            
        }
    }
}