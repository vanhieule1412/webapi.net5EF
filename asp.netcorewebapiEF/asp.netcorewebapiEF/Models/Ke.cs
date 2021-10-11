using System;
using System.Collections.Generic;

#nullable disable

namespace asp.netcorewebapiEF.Models
{
    public partial class Ke
    {
        public Ke()
        {
            Saches = new HashSet<Sach>();
        }

        public string MaKe { get; set; }
        public string TenKe { get; set; }
        public string MaKhu { get; set; }

        public virtual Khu MaKhuNavigation { get; set; }
        public virtual ICollection<Sach> Saches { get; set; }
    }
}
