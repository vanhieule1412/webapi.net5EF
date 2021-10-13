using System;
using System.Collections.Generic;

#nullable disable

namespace asp.netcorewebapiEF.Models
{
    public partial class Taikhoandocgium
    {
        public Taikhoandocgium()
        {
            Thedocgia = new HashSet<Thedocgium>();
        }

        public int MaTaiKhoaiDocGia { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string TrangThai { get; set; }

        public virtual ICollection<Thedocgium> Thedocgia { get; set; }
    }
}
