using System;
using System.Collections.Generic;

#nullable disable

namespace asp.netcorewebapiEF.Models
{
    public partial class Taikhoanthuthu
    {
        public Taikhoanthuthu()
        {
            Phieumuons = new HashSet<Phieumuon>();
            RefreshTokens = new HashSet<RefreshToken>();
            Thedocgia = new HashSet<Thedocgium>();
        }

        public int MaTaiKhoai { get; set; }
        public string TenTaiKhoai { get; set; }
        public string MatKhau { get; set; }
        public string TrangThai { get; set; }

        public virtual ICollection<Phieumuon> Phieumuons { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<Thedocgium> Thedocgia { get; set; }
    }
}
