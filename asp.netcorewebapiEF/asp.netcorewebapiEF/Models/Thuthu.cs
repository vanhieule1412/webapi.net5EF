using System;
using System.Collections.Generic;

#nullable disable

namespace asp.netcorewebapiEF.Models
{
    public partial class Thuthu
    {
        public Thuthu()
        {
            Taikhoanthuthus = new HashSet<Taikhoanthuthu>();
        }

        public string MaThuThu { get; set; }
        public string TenThuThu { get; set; }
        public DateTime NamSinh { get; set; }
        public string SoDienThoai { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string Cmnd { get; set; }

        public virtual ICollection<Taikhoanthuthu> Taikhoanthuthus { get; set; }
    }
}
