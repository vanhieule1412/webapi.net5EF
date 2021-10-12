using asp.netcorewebapiEF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp.netcorewebapiEF.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaikhoanthuthuController : ControllerBase
    {
        private Models.UngDungQuanLyThuVienContext dc = new Models.UngDungQuanLyThuVienContext();
        [HttpGet]
        public ActionResult<IEnumerable<Taikhoanthuthu>> Getalltkthuthu()
        {
            return dc.Taikhoanthuthus.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Taikhoanthuthu> Gettkthuthu(int id)
        {
            if (dc.Taikhoanthuthus == null)
            {
                return NotFound();
            }
            else
            {
                return dc.Taikhoanthuthus.FirstOrDefault(x => x.MaTaiKhoai == id);
            }
        }
        //GET: api/Taikhoanthuthu
        [HttpGet("GetTaikhoanthuthu")]
        public ActionResult<Taikhoanthuthu> GetTaikhoanthuthu()
        {
            string tentaikhoan = HttpContext.User.Identity.Name;
            var tentk = dc.Taikhoanthuthus.Where(x => x.TenTaiKhoai == tentaikhoan).FirstOrDefault();

            tentk.MatKhau = null;
            if (tentk == null)
            {
                return NotFound();
            }
            else
                return tentk;
        }

    }
}
