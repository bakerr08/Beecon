//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Beecon.MVC.Models
{
    using System;
    
    public partial class spGetAllTag_Result
    {
        public int TagID { get; set; }
        public string TagLongitude { get; set; }
        public string TagLatitude { get; set; }
        public string TagDescription { get; set; }
        public Nullable<System.DateTime> TagDateCreated { get; set; }
        public Nullable<System.DateTime> TagExpired { get; set; }
        public int UserID { get; set; }
        public string TagContent_URL { get; set; }
        public int PrivacyTypeID { get; set; }
    }
}
