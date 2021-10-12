using asp.netcorewebapiEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp.netcorewebapiEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SachController : ControllerBase
    {
        private Models.UngDungQuanLyThuVienContext dc = new Models.UngDungQuanLyThuVienContext();
        [HttpGet]
        public ActionResult<IEnumerable<Sach>> GetAllSach()
        {
            return dc.Saches.ToList();
        }
    }
}
