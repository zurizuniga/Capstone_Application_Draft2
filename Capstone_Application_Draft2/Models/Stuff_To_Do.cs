//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capstone_Application_Draft2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stuff_To_Do
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stuff_To_Do()
        {
            this.Custom_User_List = new HashSet<Custom_User_List>();
        }
    
        public int Stuff_To_Do_ID { get; set; }
        public int Months_Until_ID { get; set; }
        public string Todo_Items { get; set; }
        public string Description { get; set; }
        public string User_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Custom_User_List> Custom_User_List { get; set; }
        public virtual Months_Until Months_Until { get; set; }
        public virtual Userinfo Userinfo { get; set; }
    }
}
