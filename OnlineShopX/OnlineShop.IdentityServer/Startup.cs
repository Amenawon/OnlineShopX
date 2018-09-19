using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;
using OnlineShop.IdentityServer;
using OnlineShop.IdentityServer.Configuration;


[assembly: OwinStartup(typeof(Startup))]
namespace OnlineShop.IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var factory = new IdentityServerServiceFactory()
               .UseInMemoryScopes(Scopes.Get())
               .UseInMemoryClients(Clients.Get())
               .UseInMemoryUsers(Users.Get());

            var options = new IdentityServerOptions
            {
                RequireSsl = false,
                Factory = factory,
                SigningCertificate = Certificate.Load()
            };

            //setting up the Owin for the Identity Server
            app.Map("/auth", idsrvapp =>
            {
                idsrvapp.UseIdentityServer(options);
            });
        }
}