//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace login
{
    using System;
    using System.Collections.Generic;
    
    public partial class item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public item()
        {
            this.fix_history = new HashSet<fix_history>();
            this.require_history = new HashSet<require_history>();
        }
    
        public string item_id { get; set; }
        public string brand { get; set; }
        public string series { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<bool> is_active { get; set; }
        public Nullable<System.DateTime> insurance_start { get; set; }
        public Nullable<System.DateTime> insurance_end { get; set; }
        public Nullable<int> type_id { get; set; }
        public string staff_id { get; set; }
        public string supplier_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fix_history> fix_history { get; set; }
        public virtual staff staff { get; set; }
        public virtual supplier supplier { get; set; }
        public virtual item_type item_type { get; set; }
        public virtual pc pc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<require_history> require_history { get; set; }
    }
}