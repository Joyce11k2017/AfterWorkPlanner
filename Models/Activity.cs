//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AfterWorkPlanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Activity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activity()
        {
            this.ActivityUserMappings = new HashSet<ActivityUserMapping>();
        }
    
        public int activity_id { get; set; }

        [DisplayName("Activity Name")]
        public string activity_name { get; set; }

        [DisplayName("Time Limit")]
        public Nullable<decimal> time_limit { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityUserMapping> ActivityUserMappings { get; set; }
    }
}
