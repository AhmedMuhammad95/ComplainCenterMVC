//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetworkComplainCenter
{
    using System;
    using System.Collections.Generic;
    
    public partial class Complain
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> ComputerId { get; set; }
        public Nullable<int> LocationId { get; set; }
        public Nullable<int> AssignedTo { get; set; }
        public Nullable<System.DateTime> ResolvedDate { get; set; }
        public Nullable<int> ResolvedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> ComplainDate { get; set; }
        public Nullable<int> ComplainedBy { get; set; }
    
        public virtual ComplainStatus ComplainStatus { get; set; }
        public virtual Computer Computer { get; set; }
        public virtual Location Location { get; set; }
        public virtual User Assignee { get; set; }
        public virtual User Resolver { get; set; }
        public virtual User Updater { get; set; }
        public virtual User Complainer { get; set; }
    }
}
