using System;
using System.Collections.Generic;

#nullable disable

namespace asp.netcorewebapiEF.Models
{
    public partial class Khu
    {
        public Khu()
        {
            Kes = new HashSet<Ke>();
        }

        public string MaKhu { get; set; }
        public string TenKhu { get; set; }

        public virtual ICollection<Ke> Kes { get; set; }
    }
}
