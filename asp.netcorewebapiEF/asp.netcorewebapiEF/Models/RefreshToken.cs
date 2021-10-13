using System;
using System.Collections.Generic;

#nullable disable

namespace asp.netcorewebapiEF.Models
{
    public partial class RefreshToken
    {
        public int MaTaiKhoai { get; set; }
        public string Token { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int TokenId { get; set; }

        public virtual Taikhoanthuthu MaTaiKhoaiNavigation { get; set; }
    }
}
