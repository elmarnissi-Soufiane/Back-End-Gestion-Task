//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Job
    {
        public int IdJ { get; set; }
        public Nullable<int> IdP { get; set; }
        public string IdM { get; set; }
        public Nullable<int> IdT { get; set; }
    
        public virtual memebre memebre { get; set; }
        public virtual projet projet { get; set; }
        public virtual Task Task { get; set; }
    }
}
