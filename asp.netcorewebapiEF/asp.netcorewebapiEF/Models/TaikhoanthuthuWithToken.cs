using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp.netcorewebapiEF.Models
{
    public class TaikhoanthuthuWithToken:Taikhoanthuthu
    {
    
            public string AccessToken { get; set; }
            public string RefreshToken { get; set; }

            public TaikhoanthuthuWithToken(Taikhoanthuthu taikhoanthuthu)
            {
                this.MaTaiKhoai = taikhoanthuthu.MaTaiKhoai;
                this.TenTaiKhoai = taikhoanthuthu.TenTaiKhoai;
                this.MatKhau = taikhoanthuthu.MatKhau;
                this.TrangThai = taikhoanthuthu.TrangThai;
                
            }
        
    }
}
