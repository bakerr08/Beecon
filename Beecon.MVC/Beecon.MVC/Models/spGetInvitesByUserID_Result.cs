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
    
    public partial class spGetInvitesByUserID_Result
    {
        public int InviteID { get; set; }
        public int UserID { get; set; }
        public int UserIDSentTo { get; set; }
        public bool Accepted { get; set; }
        public bool Rejected { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
    }
}
