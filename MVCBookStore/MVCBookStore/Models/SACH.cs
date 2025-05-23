//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCBookStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SACH
    {
        public SACH()
        {
            this.CTDATHANGs = new HashSet<CTDATHANG>();
            this.VIETSACHes = new HashSet<VIETSACH>();
        }
    
        public int Masach { get; set; }
        public string Tensach { get; set; }
        public string Donvitinh { get; set; }
        public Nullable<decimal> Dongia { get; set; }
        public string Mota { get; set; }
        public string Hinhminhhoa { get; set; }
        public Nullable<int> MaCD { get; set; }
        public Nullable<int> MaNXB { get; set; }
        public Nullable<System.DateTime> Ngaycapnhat { get; set; }
        public Nullable<int> Soluongban { get; set; }
        public Nullable<int> solanxem { get; set; }
    
        public virtual CHUDE CHUDE { get; set; }
        public virtual ICollection<CTDATHANG> CTDATHANGs { get; set; }
        public virtual NHAXUATBAN NHAXUATBAN { get; set; }
        public virtual ICollection<VIETSACH> VIETSACHes { get; set; }
    }
}
