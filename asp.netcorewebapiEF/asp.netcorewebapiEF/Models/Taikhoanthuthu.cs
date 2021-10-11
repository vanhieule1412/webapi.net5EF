using System;
using System.Collections.Generic;

#nullable disable

namespace asp.netcorewebapiEF.Models
{
    public partial class Taikhoanthuthu
    {
        public Taikhoanthuthu()
        {
            Docgia = new HashSet<Docgium>();
            Phieumuons = new HashSet<Phieumuon>();
            Taikhoandocgia = new HashSet<Taikhoandocgium>();
            Thedocgia = new HashSet<Thedocgium>();
        }

        public int MaTaiKhoai { get; set; }
        public string TenTaiKhoai { get; set; }
        public string MatKhau { get; set; }
        public string TrangThai { get; set; }
        public string MaThuThu { get; set; }

        public virtual Thuthu MaThuThuNavigation { get; set; }
        public virtual ICollection<Docgium> Docgia { get; set; }
        public virtual ICollection<Phieumuon> Phieumuons { get; set; }
        public virtual ICollection<Taikhoandocgium> Taikhoandocgia { get; set; }
        public virtual ICollection<Thedocgium> Thedocgia { get; set; }
    }
}
