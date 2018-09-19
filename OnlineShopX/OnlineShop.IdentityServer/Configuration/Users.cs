using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace OnlineShop.IdentityServer.Configuration
{
    public class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Subject = "1",
                    Username = "Mena",
                    Password = "Password",
                    Claims = new Claim[]
                    {
                        new Claim(Constants.ClaimTypes.Name, "Mena Esezobor"),
                        new Claim(Constants.ClaimTypes.Email, "menaangel@yahoo.com"),
                        new Claim(Constants.ClaimTypes.PhoneNumber, "0790748324"),
                        new Claim(Constants.ClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(Constants.ClaimTypes.Address, "Alagomeji, yaba, Lagos"),
                        new Claim(Constants.ClaimTypes.BirthDate, "1998-12-25"),
                        new Claim(Constants.ClaimTypes.Role, "Admin"),
                    }
                },
                new InMemoryUser
                {
                    Subject = "2",
                    Username = "Sherlock",
                    Password = "Password",
                    Claims = new Claim[]
                    {
                        new Claim(Constants.ClaimTypes.Name, "Sherlock Holmes"),
                        new Claim(Constants.ClaimTypes.Email, "sholmes@yahoo.com"),
                        new Claim(Constants.ClaimTypes.PhoneNumber, "07029748324"),
                        new Claim(Constants.ClaimTypes.EmailVerified, "false", ClaimValueTypes.Boolean),
                        new Claim(Constants.ClaimTypes.Address, "yaba, Lagos"),
                        new Claim(Constants.ClaimTypes.BirthDate, "1987-2-2"),
                        new Claim(Constants.ClaimTypes.Role, "User")
                    }
                }
            };
        }
    }
}