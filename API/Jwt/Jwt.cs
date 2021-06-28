using API.Context;
using API.Jwt;
using API.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Jwt
{
    public class Jwt
    {
        public IConfiguration _configuration;
        private readonly MyContext myContext;

        public Jwt()
        {
        }

        public Jwt(IConfiguration configuration, MyContext myContext)
        {
            _configuration = configuration;
            this.myContext = myContext;
        }

        public string GenJwt(IQueryable<JwtVM> jwtVMs)
        {
            var claims = new List<Claim>();
            var index = 0;
            foreach (var item in jwtVMs)
            {
                if (index == 0) claims.Add(new Claim("Email", item.Email));
                claims.Add(new Claim(ClaimTypes.Role, item.Role));
                index++;
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"], 
                claims, 
                expires: DateTime.UtcNow.AddDays(1), 
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IQueryable<JwtVM> GetDataLogin(LoginVM login)
        {

            var data = from em in myContext.Employees
                       join acc in myContext.Accounts on em.NIK equals acc.NIK
                       join accrole in myContext.AccountRoles on acc.NIK equals accrole.AccountNIK
                       join role in myContext.Roles on accrole.RoleId equals role.RoleId
                       where em.NIK == login.NIK || em.Email == login.NIK
                       select new JwtVM(em.Email, role.RoleName);
            return data;
        }
    }
}
