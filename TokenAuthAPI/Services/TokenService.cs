﻿using TokenAuthAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TokenAuthAPI.Service
{
    public class TokenService : ITokenService
    {
        private TimeSpan Expiryduraation = new TimeSpan(20, 30, 0);
        public string BuildToken(string key, string issuer, IEnumerable<string> audience, string username, User user)
        {
            var claims = new List<Claim>
            {
            new Claim("username",user.Username!=null?user.Username:""),
            new Claim("password",user.Password!=null?user.Password:""),
            new Claim("UserType",user.UserType!=null?user.UserType:"")
            };
            claims.AddRange(audience.Select(aud => new Claim(JwtRegisteredClaimNames.Aud, aud)));
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims, expires: DateTime.Now.Add(Expiryduraation), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
