using System;
using System.Collections.Generic;

#nullable disable

namespace asp.netcorewebapiEF.Models
{
    public partial class Chitietphieumuon
    {
        public int MaMuonTra { get; set; }
        public string MaSach { get; set; }
        public string MaPhieuMuon { get; set; }
        public DateTime? NgayTraThat { get; set; }
        public double? TienPhat { get; set; }
        public string TinhTrang { get; set; }
        public int SoLuongSachMuon { get; set; }

        public virtual Phieumuon MaPhieuMuonNavigation { get; set; }
        public virtual Sach MaSachNavigation { get; set; }
    }
}
