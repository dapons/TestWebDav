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
    
    public partial class UserAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserAccount()
        {
            this.Commitments = new HashSet<Commitment>();
            this.FragBranches = new HashSet<FragBranch>();
            this.FragLocks = new HashSet<FragLock>();
            this.FragReviews = new HashSet<FragReview>();
            this.FragReviewInProgresses = new HashSet<FragReviewInProgress>();
            this.GrolReleaseValidations = new HashSet<GrolReleaseValidation>();
            this.HeadBranches = new HashSet<HeadBranch>();
            this.HeadBranches1 = new HashSet<HeadBranch>();
            this.News = new HashSet<News>();
            this.UserAccounts2License = new HashSet<UserAccounts2License>();
            this.WorkingBranches = new HashSet<WorkingBranch>();
            this.WorkingBranches1 = new HashSet<WorkingBranch>();
        }
    
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Login { get; set; }
        public bool IsAdmin { get; set; }
        public bool CanCertify { get; set; }
        public int WorkingBranchId { get; set; }
        public byte[] Version { get; set; }
        public bool IsActivated { get; set; }
        public System.DateTime ActiveFrom { get; set; }
        public Nullable<System.DateTime> ActiveTo { get; set; }
        public byte[] Hash { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commitment> Commitments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FragBranch> FragBranches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FragLock> FragLocks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FragReview> FragReviews { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FragReviewInProgress> FragReviewInProgresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrolReleaseValidation> GrolReleaseValidations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HeadBranch> HeadBranches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HeadBranch> HeadBranches1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<News> News { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAccounts2License> UserAccounts2License { get; set; }
        public virtual WorkingBranch WorkingBranch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkingBranch> WorkingBranches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkingBranch> WorkingBranches1 { get; set; }
    }
}
