//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestWebAppDomain.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class HeadBranch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HeadBranch()
        {
            this.Commitments = new HashSet<Commitment>();
            this.FragBranches = new HashSet<FragBranch>();
            this.FragLocks = new HashSet<FragLock>();
            this.HeadBranch1 = new HashSet<HeadBranch>();
            this.WorkingBranches = new HashSet<WorkingBranch>();
        }
    
        public int Id { get; set; }
        public byte BranchStateId { get; set; }
        public string Name { get; set; }
        public Nullable<int> SourceId { get; set; }
        public bool IsClosed { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string CreationComment { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
        public string DeletionComment { get; set; }
        public int CreationUserId { get; set; }
        public Nullable<int> DeletionUserId { get; set; }
        public byte[] Version { get; set; }
    
        public virtual BranchState BranchState { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commitment> Commitments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FragBranch> FragBranches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FragLock> FragLocks { get; set; }
        public virtual UserAccount UserAccount { get; set; }
        public virtual UserAccount UserAccount1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HeadBranch> HeadBranch1 { get; set; }
        public virtual HeadBranch HeadBranch2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkingBranch> WorkingBranches { get; set; }
    }
}
