using System;
using System.Collections.Generic;

#nullable disable

namespace asp.netcorewebapiEF.Models
{
    public partial class Docgium
    {
        public Docgium()
        {
            Taikhoandocgia = new HashSet<Taikhoandocgium>();
        }

        public string MaDocGia { get; set; }
        public string TenDocGia { get; set; }
        public DateTime NamSinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string GioiTinh { get; set; }
        public string Cmnd { get; set; }
        public string DiaChi { get; set; }
        public int MaTaiKhoai { get; set; }

        public virtual Taikhoanthuthu MaTaiKhoaiNavigation { get; set; }
        public virtual ICollection<Taikhoandocgium> Taikhoandocgia { get; set; }
    }
}
