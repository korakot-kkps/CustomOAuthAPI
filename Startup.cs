using CustomOAuthAPI.OAuth.Attributes;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(CustomOAuthAPI.Startup))]

namespace CustomOAuthAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Enable CORS (Cross-Origin Resource Sharing)
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            // Configure OAuth
            var oAuthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true, // Only for development; use HTTPS in production!
                TokenEndpointPath = new PathString("/api/auth"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30), // Set the token expiration time
                Provider = new YourOAuthProvider(), // Implement your custom OAuth provider
            };

            // Enable OAuth in the app
            app.UseOAuthAuthorizationServer(oAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions()); 
        }
    }
}
