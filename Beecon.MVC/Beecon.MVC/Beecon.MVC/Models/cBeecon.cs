using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beecon.MVC.Models
{
    public class cBeecon
    {
        #region Beecon Properties

        int beeconID;

        public int BeeconID
        {
            get { return beeconID; }
            set { beeconID = value; }
        }
        string beeconLongitude;

        public string BeeconLongitude
        {
            get { return beeconLongitude; }
            set { beeconLongitude = value; }
        }
        string beeconLatitude;

        public string BeeconLatitude
        {
            get { return beeconLatitude; }
            set { beeconLatitude = value; }
        }
        string beeconDescription;

        public string BeeconDescription
        {
            get { return beeconDescription; }
            set { beeconDescription = value; }
        }
        DateTime beeconDateCreated;

        public DateTime BeeconDateCreated
        {
            get { return beeconDateCreated; }
            set { beeconDateCreated = value; }
        }
        DateTime beeconDateExpired;

        public DateTime BeeconDateExpired
        {
            get { return beeconDateExpired; }
            set { beeconDateExpired = value; }
        }
        int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        string beeconContentURL;

        public string BeeconContentURL
        {
            get { return beeconContentURL; }
            set { beeconContentURL = value; }
        }
        int beeconPrivacyTypeID;

        public int BeeconPrivacyTypeID
        {
            get { return beeconPrivacyTypeID; }
            set { beeconPrivacyTypeID = value; }
        }

        #endregion


    }
}