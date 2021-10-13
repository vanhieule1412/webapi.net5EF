using asp.netcorewebapiEF.Models;
using IdentityServer4.Models;
using Jose;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace asp.netcorewebapiEF.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaikhoanthuthuController : ControllerBase
    {
        private Models.UngDungQuanLyThuVienContext dc = new Models.UngDungQuanLyThuVienContext();
        private readonly JWTSettings _jwtsettings;

        public TaikhoanthuthuController(IOptions<JWTSettings> jwtsettings)
        {
            _jwtsettings = jwtsettings.Value;
        }

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
        [HttpGet("Login")]
        public ActionResult<Taikhoanthuthu> Login([FromBody] Taikhoanthuthu taikhoanthuthu)
        {
            taikhoanthuthu = dc.Taikhoanthuthus.Where(x => x.TenTaiKhoai == taikhoanthuthu.TenTaiKhoai && x.MatKhau == x.MatKhau).FirstOrDefault();
            TaikhoanthuthuWithToken taikhoanthuthuwithtoken = new TaikhoanthuthuWithToken(taikhoanthuthu);
            if (taikhoanthuthuwithtoken == null)
            {
                return NotFound();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.Secretkey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, Convert.ToString(taikhoanthuthu.MaTaiKhoai))

                }),
                Expires = DateTime.UtcNow.AddMonths(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            taikhoanthuthuwithtoken.AccessToken = tokenHandler.WriteToken(token);
            return taikhoanthuthuwithtoken;

        }
        // POST: api/Users
        [HttpPost("Registertkthuthu")]
        public async Task<ActionResult<TaikhoanthuthuWithToken>> Registertkthuthu([FromBody] Taikhoanthuthu taikhoanthuthu)
        {
            dc.Taikhoanthuthus.Add(taikhoanthuthu);
            await dc.SaveChangesAsync();

            //load role for registered user
            taikhoanthuthu = await dc.Taikhoanthuthus
                                        .Where(u => u.MaTaiKhoai == taikhoanthuthu.MaTaiKhoai).FirstOrDefaultAsync();

            TaikhoanthuthuWithToken taikhoanthuthuWithToken = null;

            if (taikhoanthuthu != null)
            {
                Models.RefreshToken refreshToken = GenerateRefreshToken();
                taikhoanthuthu.RefreshTokens.Add(refreshToken);
                await dc.SaveChangesAsync();

                taikhoanthuthuWithToken = new TaikhoanthuthuWithToken(taikhoanthuthu);
                taikhoanthuthuWithToken.RefreshToken = refreshToken.Token;
            }

            if (taikhoanthuthuWithToken == null)
            {
                return NotFound();
            }

            //sign your token here here..
            taikhoanthuthuWithToken.AccessToken = GenerateAccessToken(taikhoanthuthu.MaTaiKhoai);
            return taikhoanthuthuWithToken;
        }
        private string GenerateAccessToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.Secretkey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Convert.ToString(userId))
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        private Models.RefreshToken GenerateRefreshToken()
        {
                Models.RefreshToken refreshToken = new Models.RefreshToken();

                var randomNumber = new byte[32];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(randomNumber);
                    refreshToken.Token = Convert.ToBase64String(randomNumber);
                }
                refreshToken.ExpiryDate = DateTime.UtcNow.AddMonths(6);

                return refreshToken;
            }

        }
}
