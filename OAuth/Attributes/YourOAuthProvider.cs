using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;


namespace CustomOAuthAPI.OAuth.Attributes
{
    public class YourOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // For simplicity, we accept all clients (not recommended for production!)
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // Validate the user's credentials (e.g., check against a database)
            using (var princContext = new PrincipalContext(ContextType.Domain, "phatrasec"))
            {
                //UserPrincipal user = new UserPrincipal(princContext, context.UserName, context.Password, true); //
                UserPrincipal user = new UserPrincipal(princContext, "", "", true); //Test   

                if (user != null)
                {
                    // custom request parameters
                    var form = await context.Request.ReadFormAsync();
                    var role = form["role"];

                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim(type: "UserName", value: user.SamAccountName));
                    // You can add more claims based on user roles or additional information
                    identity.AddClaim(new Claim(ClaimTypes.Role, role ?? ""));  
                    identity.AddClaim(new Claim(ClaimTypes.Email, user.EmailAddress ?? ""));
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.Name ?? ""));

                    context.Validated(identity);
                }
                else
                {
                    context.SetError("invalid_grant", "The username or password is incorrect.");
                    context.Rejected();
                }
            }
        }
    }
}