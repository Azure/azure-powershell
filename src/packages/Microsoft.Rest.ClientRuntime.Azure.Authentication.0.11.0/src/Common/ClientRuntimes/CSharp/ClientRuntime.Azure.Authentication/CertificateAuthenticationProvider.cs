﻿using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Rest.Azure.Authentication
{
    public class CertificateAuthenticationProvider : IApplicationAuthenticationProvider
    {
        private Func<string, Task<ClientAssertionCertificate>> _assertionProvider;

        public CertificateAuthenticationProvider(X509Certificate2 certificate)
        {
            this._assertionProvider = (s) => Task.FromResult(new ClientAssertionCertificate(s, certificate));
        }

        /// <summary>
        /// Create an application authenticator using a certificate provider
        /// </summary>
        /// <param name="provider"></param>
        public CertificateAuthenticationProvider(Func<string, Task<ClientAssertionCertificate>> provider)
        {
            this._assertionProvider = provider;
        }

        public async Task<AuthenticationResult> AuthenticateAsync(string clientId, string audience, IdentityModel.Clients.ActiveDirectory.AuthenticationContext context)
        {
            var certificate = await this._assertionProvider(clientId).ConfigureAwait(false);
            return await context.AcquireTokenAsync(audience, certificate);
        }
    }
}
