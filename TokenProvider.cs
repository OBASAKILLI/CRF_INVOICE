
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using ECAN_INVOICE.Interfaces;
using ECAN_INVOICE.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ECAN_INVOICE.Utils;

namespace ECAN_INVOICE
{
    public class TokenProvider
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TokenProvider(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<EmailSendStatus> LoginUser(string strUserName, string password)
        {
            EmailSendStatus statusmessage = new EmailSendStatus();
            try {             
                Users user = await GetUserDetails(strUserName, password);

                if (user != null)
                {
                        var key = Encoding.ASCII.GetBytes("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv");

                        var JWToken = new JwtSecurityToken(
                            issuer: "",
                            audience: "",
                            claims: GetUserClaims(user),
                            notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                            expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,

                            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        );
                        var token = new JwtSecurityTokenHandler().WriteToken(JWToken);

                        // return token;
                        //  HttpContext.Session.SetString("JWToken", token);
                        // Session.SessionExtensions.Set("JWToken", token);

                        _httpContextAccessor.HttpContext.Session.SetString("JWToken", token);
                        statusmessage.status = true;
                        statusmessage.message = user.id.ToString();
                  
                }
                else
                {
                    statusmessage.status = false;
                    statusmessage.message = "Wrong User Credentials..";

                }
            }
            catch (Exception e)
            {
                statusmessage.status = false;
                statusmessage.message = e.Message;
            }
            return statusmessage;
        }

        public async Task<Users> GetUserDetails(string strUserName, string password)
        {
            return await _unitOfWork.UserRepository.Login(strUserName, password);

        }

        private IEnumerable<Claim> GetUserClaims(Users user)
        {
            List<Claim> claims = new List<Claim>();
            Claim _claim;
            _claim = new Claim(ClaimTypes.Name, user.id.ToString());
            claims.Add(_claim);
        
            _claim = new Claim(ClaimTypes.MobilePhone, " 0799092727" );
            claims.Add(_claim);
          
            return claims.AsEnumerable<Claim>();
        }
    }
}
