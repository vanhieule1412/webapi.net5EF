using System;
using System.Collections.Generic;

#nullable disable

namespace asp.netcorewebapiEF.Models
{
    public partial class Theloai
    {
        public Theloai()
        {
            Saches = new HashSet<Sach>();
        }

        public string MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }
        public string MoTaTheLoai { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
