//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TradITAM
{
    using System;
    using System.Collections.Generic;
    
    public partial class history
    {
        public int history_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public string detail { get; set; }
        public Nullable<System.DateTime> history_timestamp { get; set; }
        public Nullable<int> history_type { get; set; }
    
        public virtual user_login user_login { get; set; }
    }
}
