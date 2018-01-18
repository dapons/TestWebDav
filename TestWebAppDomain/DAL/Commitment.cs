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
    
    public partial class Commitment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Commitment()
        {
            this.Fragments = new HashSet<Fragment>();
        }
    
        public int Id { get; set; }
        public int BranchId { get; set; }
        public System.DateTime CommitDate { get; set; }
        public string CommitComment { get; set; }
        public int CommitUserId { get; set; }
        public byte[] Version { get; set; }
    
        public virtual UserAccount UserAccount { get; set; }
        public virtual HeadBranch HeadBranch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fragment> Fragments { get; set; }
    }
}
