using System;
using System.Collections.Generic;

#nullable disable

namespace asp.netcorewebapiEF.Models
{
    public partial class Nhaxuatban
    {
        public Nhaxuatban()
        {
            Saches = new HashSet<Sach>();
        }

        public string MaNhaXuatBan { get; set; }
        public string TenNhaXuatBan { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string DiaChiWebsite { get; set; }
        public string SoDienThoai { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
