//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCKÜTÜPHANE.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Ceza
    {
        public int CezaID { get; set; }
        public Nullable<int> ÜYE { get; set; }
        public Nullable<int> HAREKET { get; set; }
        public Nullable<System.DateTime> BAŞLANGIÇ { get; set; }
        public Nullable<System.DateTime> BİTİŞ { get; set; }
        public Nullable<decimal> PARA { get; set; }
    
        public virtual Tbl_Hareket Tbl_Hareket { get; set; }
        public virtual Tbl_Üye Tbl_Üye { get; set; }
    }
}
