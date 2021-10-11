using System;
using System.Collections.Generic;

#nullable disable

namespace asp.netcorewebapiEF.Models
{
    public partial class Phieumuon
    {
        public Phieumuon()
        {
            Chitietphieumuons = new HashSet<Chitietphieumuon>();
        }

        public string MaPhieuMuon { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTraDukien { get; set; }
        public bool TrangThai { get; set; }
        public double? TienPhatTong { get; set; }
        public bool? DaTra { get; set; }
        public int? MaTaiKhoai { get; set; }
        public string MaTheDocGia { get; set; }

        public virtual Taikhoanthuthu MaTaiKhoaiNavigation { get; set; }
        public virtual Thedocgium MaTheDocGiaNavigation { get; set; }
        public virtual ICollection<Chitietphieumuon> Chitietphieumuons { get; set; }
    }
}
