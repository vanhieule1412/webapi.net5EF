using asp.netcorewebapiEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp.netcorewebapiEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheLoaiController : ControllerBase
    {
        private Models.UngDungQuanLyThuVienContext dc = new Models.UngDungQuanLyThuVienContext();
        [HttpGet]
        public ActionResult<IEnumerable<Theloai>> GetAllTheloai()
        {
            //get all Theloai
            return dc.Theloais.ToList();
        }
        //Get: api/theloaidetail/id
        [HttpGet("GetTheloaiDetails/{id}")]
        public async Task<ActionResult<Theloai>> GetTheloaiDetails(string id)
        {
            //Explicit Loading
            var theloaier = await dc.Theloais.SingleAsync(x => x.MaTheLoai == id);
            dc.Entry(theloaier).Collection(x => x.Saches).Load();//xem những quyển sách có thể loại mình muốn
            dc.Entry(theloaier).Collection(x => x.Saches).Query().Include(x => x.Chitietphieumuons).Load();//xem những quyển sách đã cho mượn chưa
            //get Theloai by id
            if (dc.Theloais == null)
            {
                return NotFound();
            }
            else
            {
                //Eager Loading
                //return dc.Theloais
                //    .Include(x => x.Saches)
                //        .ThenInclude(sach =>sach.Chitietphieumuons)
                //    .Where(x => x.MaTheLoai == id).FirstOrDefault();             
                return theloaier;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Theloai> GetTheloai(string id)
        {
            //get Theloai by id
            if (dc.Theloais == null)
            {
                return NotFound();
            }
            else
            {
                return dc.Theloais.FirstOrDefault(x => x.MaTheLoai == id);
            }
        }

        //Post: api/theloaidetail
        //[HttpPost("PostTheloaiDetails/")]
        //public ActionResult<Theloai> PostTheloaiDetails(Theloai theloai)
        //{
        //    //get Theloai by id
        //    var a = new Models.Theloai
        //    {
        //        MaTheLoai = theloai.MaTheLoai,
        //        TenTheLoai = theloai.TenTheLoai,
        //        MoTaTheLoai = theloai.MoTaTheLoai,
                
        //        //Saches = theloai.Saches.Select(x => new Models.Sach
        //        //{
        //        //    MaSach = x.MaSach,
        //        //    TenSach = x.TenSach,
        //        //    SoLuong = x.SoLuong,
        //        //    Gia = x.Gia,
        //        //}).ToList()
        //    };

        //    dc.Theloais.Add(a);
        //    dc.SaveChanges();

        //    return dc.Theloais
        //        .Include(x => x.Saches)
        //            .ThenInclude(sach => sach.Chitietphieumuons)
        //        .Where(x => x.MaTheLoai == theloai.MaTheLoai).FirstOrDefault();
        //}

        [HttpPost]
        public async Task<ActionResult<Theloai>> PostTheloai(Theloai theloai)
        {
            dc.Theloais.Add(theloai);
            await dc.SaveChangesAsync();
            return CreatedAtAction("GetTheloai", new { id = theloai.MaTheLoai }, theloai);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTheloai(string id, Theloai theloai)
        {
            if (id != theloai.MaTheLoai)
            {
                return BadRequest();
            }
            //update theloai
            dc.Entry(theloai).State = EntityState.Modified;

            try
            {

                await dc.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheloaiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction("GetAllTheloai");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(string id)
        {
            var a = await dc.Theloais.FindAsync(id);
            if (a == null)
            {
                return NotFound();
            }
            else
            {
                dc.Theloais.Remove(a);
                await dc.SaveChangesAsync();
                return RedirectToAction("GetAllTheloai");
            }
        }
        private bool TheloaiExists(string id)
        {
            return dc.Theloais.Any(e => e.MaTheLoai == id);
        }
    }
}

