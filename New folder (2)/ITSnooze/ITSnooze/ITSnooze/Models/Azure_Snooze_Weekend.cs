//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITSnooze.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Azure_Snooze_Weekend
    {
        public string Server { get; set; }
        public string AppTeam { get; set; }
        public Nullable<bool> Exception { get; set; }
        public Nullable<System.DateTime> SnoozeStart { get; set; }
        public Nullable<System.DateTime> SnoozeEnd { get; set; }
        public Nullable<bool> StartStatus { get; set; }
        public Nullable<bool> StopStatus { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedTime { get; set; }
        public int ID { get; set; }
    }
}
