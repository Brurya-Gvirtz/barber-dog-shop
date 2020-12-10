using BarberShop.BL;
using BarberShop.Entities;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BarberShop.Providers
{
    public class ApplicationAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                byte[] passwordbyte = Convert.FromBase64String(context.Password.Replace(" ", "+"));
                string password = System.Text.Encoding.UTF8.GetString(passwordbyte);

                Customer customer = CustomerManager.FindCustomer(context.UserName, password);

                if (customer == null)
                {
                    context.SetError("Incorrect", "The customer name or password is incorrect.");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                //identity.AddClaim(new Claim(ClaimTypes.Role, trainer.Role));
                identity.AddClaim(new Claim(ClaimTypes.Name, customer.Name));
                identity.AddClaim(new Claim("UserName", customer.UserName));

                await Task.Run(() => context.Validated(identity));
                //context.Validated(identity);

            }
            catch (Exception e)
            {
                //nlog
                //DIManager.Container.Resolve<IBaseLogger>().Error("Login error", e);
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }
            return Task.FromResult<object>(null);
        }

    }
}