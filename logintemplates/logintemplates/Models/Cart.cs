//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace logintemplates.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cart
    {
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    
        public virtual tblproduct tblproduct { get; set; }
    }
}