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
    
    public partial class Custom_User_List
    {
        public int Custom_List_ID { get; set; }
        public string User_ID { get; set; }
        public int Stuff_to_do_ID { get; set; }
        public int Status_ID { get; set; }
    
        public virtual Progress_Status Progress_Status { get; set; }
        public virtual Userinfo Userinfo { get; set; }
        public virtual Stuff_To_Do Stuff_To_Do { get; set; }
    }
}
