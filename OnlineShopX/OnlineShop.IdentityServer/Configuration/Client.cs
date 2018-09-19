using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Models;

namespace OnlineShop.IdentityServer.Configuration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientName = "Deva",
                    Enabled = false,
                    AllowAccessToAllScopes = false,
                    ClientId = "admin.deva",
                    AccessTokenLifetime = 86400,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    Flow = Flows.Implicit,
                    AllowedScopes = new List<string>
                    {
                        "AdminManagement", "PaymentManagement","UserManagement"
                    },
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("sadio".Sha256())
                    }
                },
                new Client
                {
                    ClientName = "alley",
                    Enabled = true,
                    AllowAccessToAllScopes = true,
                    ClientId = "admin.alley",
                    AccessTokenLifetime = 86400,
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    Flow = Flows.ResourceOwner,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("solo".Sha256())
                    }
                }
            };
        }
    }
}