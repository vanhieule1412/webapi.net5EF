using System;
using System.Collections.Generic;

#nullable disable

namespace asp.netcorewebapiEF.Models
{
    public partial class Thedocgium
    {
        public Thedocgium()
        {
            Phieumuons = new HashSet<Phieumuon>();
        }

        public string MaTheDocGia { get; set; }
        public DateTime NgayTheDuocTao { get; set; }
        public DateTime NgayTheDuocGiaHan { get; set; }
        public string TenDocGia { get; set; }
        public DateTime? NamSinh { get; set; }
        public int? MaTaiKhoaiDocGia { get; set; }
        public int? MaTaiKhoai { get; set; }

        public virtual Taikhoandocgium MaTaiKhoaiDocGiaNavigation { get; set; }
        public virtual Taikhoanthuthu MaTaiKhoaiNavigation { get; set; }
        public virtual ICollection<Phieumuon> Phieumuons { get; set; }
    }
}
