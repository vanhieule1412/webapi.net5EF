using System;
using System.Collections.Generic;

#nullable disable

namespace asp.netcorewebapiEF.Models
{
    public partial class Sach
    {
        public Sach()
        {
            Chitietphieumuons = new HashSet<Chitietphieumuon>();
        }

        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public int SoLuong { get; set; }
        public string TacGia { get; set; }
        public int NamXuatBan { get; set; }
        public string NguoiDich { get; set; }
        public string MaTheLoai { get; set; }
        public string MaNhaXuatBan { get; set; }
        public string MaKe { get; set; }
        public string NoiDungTomTat { get; set; }
        public string HinhAnh { get; set; }
        public double? Gia { get; set; }

        public virtual Ke MaKeNavigation { get; set; }
        public virtual Nhaxuatban MaNhaXuatBanNavigation { get; set; }
        public virtual Theloai MaTheLoaiNavigation { get; set; }
        public virtual ICollection<Chitietphieumuon> Chitietphieumuons { get; set; }
    }
}
