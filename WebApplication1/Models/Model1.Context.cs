﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CraftEntities : DbContext
    {
        public CraftEntities()
            : base("name=CraftEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<memebre> memebres { get; set; }
        public virtual DbSet<projet> projets { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Admine> Admines { get; set; }
    }
}
