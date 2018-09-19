using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.IdentityServer.Configuration
{
    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new[]
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                new Scope
                {
                    Name = "AdminManagement",
                    DisplayName = "Admin Management",
                    Type = ScopeType.Resource,
                    Emphasize = false,
                    ScopeSecrets = new List<Secret>
                    {
                        new Secret("santiago".Sha256())
                    }
                },
                new Scope
                {
                    Name = "PaymentManagement",
                    DisplayName = "Payment Management",
                    Type = ScopeType.Resource,
                    Emphasize = false,
                    ScopeSecrets = new List<Secret>
                    {
                        new Secret("sandro".Sha256())
                    }
                },
                new Scope
                {
                    Name = "UserManagement",
                    DisplayName = "User Management",
                    Type = ScopeType.Identity,
                    Emphasize = false,
                    ScopeSecrets = new List<Secret>
                    {
                        new Secret("alexsandro".Sha256())
                    }
                }

            };
        }
    }
}