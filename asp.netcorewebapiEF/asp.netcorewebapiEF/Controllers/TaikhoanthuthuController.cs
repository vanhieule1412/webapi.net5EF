using asp.netcorewebapiEF.Models;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        //[HttpGet("Login")]
        //public ActionResult<Taikhoanthuthu> Login([FromBody] Taikhoanthuthu taikhoanthuthu)
        //{
        //    taikhoanthuthu = dc.Taikhoanthuthus.Include(x => x.TenTaiKhoai).Where(x => x.TenTaiKhoai == taikhoanthuthu.TenTaiKhoai && x.MatKhau == taikhoanthuthu.MatKhau).FirstOrDefault();
        //    Taikhoanthuthu taikhoanthuthuwithtoken = new Taikhoanthuthu(taikhoanthuthu);
        //    if (taikhoanthuthuwithtoken == null)
        //    {
        //        return NotFound();
        //    }

        //    //var tokenHandler = new JwtSecurityTokenHandler();
        //    //var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
        //    //var tokenDescriptor = new SecurityTokenDescriptor
        //    //{
        //    //    Subject=new System.Security.Claims.ClaimsIdentity(new Claim[] { 
        //    //        new Claim(ClaimTypes.Name, taikhoanthuthu.TenTaiKhoai)

        //    //    }),
        //    //    Expires=DateTime.UtcNow.AddMonths(6),
        //    //    SigningCredentials =new SigningCredentials(new SymmetricSecurityKey(key),
        //    //    SecurityAlgorithms.HmacSha256Signature)
        //    //};
        //    //var token = tokenHandler.CreateToken(tokenDescriptor);
        //    //taikhoanthuthuwithtoken.TrangThai = tokenHandler.WriteToken(token);
        //    return taikhoanthuthuwithtoken;

        //}
        //// POST: api/Users
        //[HttpPost("Registertkthuthu")]
        //public async Task<ActionResult<Taikhoanthuthu>> Registertkthuthu([FromBody] Taikhoanthuthu taikhoanthuthu)
        //{
        //    dc.Taikhoanthuthus.Add(taikhoanthuthu);
        //    await dc.SaveChangesAsync();

        //    //load role for registered user
        //    taikhoanthuthu = await dc.Taikhoanthuthus
        //                                .Where(u => u.TenTaiKhoai == taikhoanthuthu.TenTaiKhoai).FirstOrDefaultAsync();

        //    Taikhoanthuthu taikhoanthuthuWithToken = null;

        //    if (taikhoanthuthu != null)
        //    {
        //        RefreshToken refreshToken = GenerateRefreshToken();
        //        taikhoanthuthu.Phieumuons.Add(refreshToken);
        //        await _context.SaveChangesAsync();

        //        userWithToken = new UserWithToken(user);
        //        userWithToken.RefreshToken = refreshToken.Token;
        //    }

        //    if (userWithToken == null)
        //    {
        //        return NotFound();
        //    }

        //    //sign your token here here..
        //    userWithToken.AccessToken = GenerateAccessToken(user.UserId);
        //    return userWithToken;
        //}
        //private RefreshToken GenerateRefreshToken()
        //{
        //    RefreshToken refreshToken = new RefreshToken();

        //    var randomNumber = new byte[32];
        //    using (var rng = RandomNumberGenerator.Create())
        //    {
        //        rng.GetBytes(randomNumber);
        //        refreshToken.Token = Convert.ToBase64String(randomNumber);
        //    }
        //    refreshToken.ExpiryDate = DateTime.UtcNow.AddMonths(6);

        //    return refreshToken;
        //}

    }
}
