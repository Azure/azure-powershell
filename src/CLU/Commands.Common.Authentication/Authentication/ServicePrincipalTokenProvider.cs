﻿// ----------------------------------------------------------------------------------
// Copyright Microsoft Corporation
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using Commands.Common.Authentication.Properties;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    internal class ServicePrincipalTokenProvider : ITokenProvider
    {
        private static readonly TimeSpan expirationThreshold = TimeSpan.FromMinutes(5);
        private Func<string, byte[]> _getCertificate;

        public ServicePrincipalTokenProvider()
        {
            var dataStore = new DiskDataStore();
            _getCertificate = ((cert) => dataStore.GetCertificate(cert));
        }
        public ServicePrincipalTokenProvider(Func<String, byte[]> certificateFinder)
        {
            _getCertificate = certificateFinder;
        }
        public IAccessToken GetAccessToken(AdalConfiguration config, ShowDialog promptBehavior, string userId, string password,
            AzureAccount.AccountType credentialType)
        {
            if (credentialType == AzureAccount.AccountType.User)
            {
                throw new ArgumentException(string.Format(Resources.InvalidCredentialType, "User"), "credentialType");
            }
            return new ServicePrincipalAccessToken(config, AcquireTokenWithSecret(config, userId, password), (adalConfig, appId ) => this.RenewWithSecret(config, appId, password), userId);
        }

        public IAccessToken GetAccessTokenWithCertificate(
            AdalConfiguration config, 
            string clientId, 
            string certificateThumbprint, 
            string certificatePassword,
            AzureAccount.AccountType credentialType)
        {
            if (credentialType == AzureAccount.AccountType.User)
            {
                throw new ArgumentException(string.Format(Resources.InvalidCredentialType, "User"), nameof(credentialType));
            }
            return new ServicePrincipalAccessToken(
                config, 
                AcquireTokenWithCertificate(config, clientId, certificateThumbprint, certificatePassword), 
                (adalConfig, appId) => this.RenewWithCertificate(adalConfig, appId, certificateThumbprint, certificatePassword), 
                clientId);
        }

        private AuthenticationContext GetContext(AdalConfiguration config)
        {
            string authority = config.AdEndpoint + config.AdDomain;
            return new AuthenticationContext(authority, config.ValidateAuthority, config.TokenCache);
        }
		
        private AuthenticationResult AcquireTokenWithSecret(AdalConfiguration config, string appId, string appKey)
        {
            var credential = new ClientCredential(appId, appKey);
            var context = GetContext(config);
            return context.AcquireTokenAsync(config.ResourceClientUri, credential)
                          .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private AuthenticationResult AcquireTokenWithCertificate(
            AdalConfiguration config, 
            string appId,
            string thumbprint,
            string certificatePassword)
        {
            var certificate = _getCertificate(thumbprint);
            if (certificate == null)
            {
                throw new ArgumentException(string.Format(Resources.CertificateNotFoundInStore, thumbprint));
            }

            var context = GetContext(config);
            return context.AcquireTokenAsync(
                            config.ResourceClientUri, 
                            new ClientAssertionCertificate(appId, certificate, certificatePassword))
                          .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private AuthenticationResult RenewWithSecret(AdalConfiguration config, string appId, string appKey)
        {
            ServiceClientTracing.Information(Resources.SPNRenewTokenTrace, appId, config.AdDomain, config.AdEndpoint, 
                config.ClientId, config.ClientRedirectUri);
            return AcquireTokenWithSecret(config, appId, appKey);
        }

        private AuthenticationResult RenewWithCertificate(
            AdalConfiguration config, 
            string appId,
            string thumbprint,
            string certificatePassword)
        {
            ServiceClientTracing.Information(Resources.SPNRenewTokenTrace, appId, config.AdDomain, config.AdEndpoint, 
                config.ClientId, config.ClientRedirectUri);
            return AcquireTokenWithCertificate(config, appId, thumbprint, certificatePassword);
        }

        private class ServicePrincipalAccessToken : IAccessToken
        {
            internal readonly AdalConfiguration Configuration;
            internal AuthenticationResult AuthResult;
            private readonly Func<AdalConfiguration, string, AuthenticationResult> tokenRenewer;
            private readonly string appId;

            public ServicePrincipalAccessToken(AdalConfiguration configuration, AuthenticationResult authResult, Func<AdalConfiguration, string, AuthenticationResult> tokenRenewer, string appId)
            {
                Configuration = configuration;
                AuthResult = authResult;
                this.tokenRenewer = tokenRenewer;
                this.appId = appId;
            }

            public void AuthorizeRequest(Action<string, string> authTokenSetter)
            {
                if (IsExpired)
                {
                    AuthResult = tokenRenewer(Configuration, appId);
                }

                authTokenSetter(AuthResult.AccessTokenType, AuthResult.AccessToken);
            }

            public string UserId { get { return appId; } }
            public string AccessToken { get { return AuthResult.AccessToken; } }
            public LoginType LoginType { get { return LoginType.OrgId; } }
            public string TenantId { get { return this.Configuration.AdDomain; } }

            private bool IsExpired
            {
                get
                {
#if DEBUG
                    if (Environment.GetEnvironmentVariable("FORCE_EXPIRED_ACCESS_TOKEN") != null)
                    {
                        return true;
                    }
#endif

                    var expiration = AuthResult.ExpiresOn;
                    var currentTime = DateTimeOffset.UtcNow;
                    var timeUntilExpiration = expiration - currentTime;
                    ServiceClientTracing.Information(Resources.SPNTokenExpirationCheckTrace, expiration, currentTime, 
                        expirationThreshold, timeUntilExpiration);
                    return timeUntilExpiration < expirationThreshold;
                }
            }
        }
    }
}

