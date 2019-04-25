// ----------------------------------------------------------------------------------
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

using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Identity.Client;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.Generic;
using System.Security;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    internal class ServicePrincipalTokenProvider : ITokenProvider
    {
        private static readonly TimeSpan expirationThreshold = TimeSpan.FromMinutes(5);
        private Func<IServicePrincipalKeyStore> _getKeyStore;
        private IServicePrincipalKeyStore _keyStore;

        public IServicePrincipalKeyStore KeyStore
        {
            get
            {
                if (_keyStore == null)
                {
                    _keyStore = _getKeyStore();
                }

                return _keyStore;
            }
            set
            {
                _keyStore = value;
            }
        }

        public ServicePrincipalTokenProvider()
        {
        }

        public ServicePrincipalTokenProvider(Func<IServicePrincipalKeyStore> getKeyStore)
        {
            _getKeyStore = getKeyStore;
        }

        public IAccessToken GetAccessToken(
            AdalConfiguration config,
            string promptBehavior,
			Action<string> promptAction,
            string userId,
            SecureString password,
            string credentialType)
        {
            if (credentialType == AzureAccount.AccountType.User)
            {
                throw new ArgumentException(string.Format(Resources.InvalidCredentialType, "User"), "credentialType");
            }
            return new ServicePrincipalAccessToken(config, AcquireTokenWithSecret(config, userId, password), this.RenewWithSecret, userId);
        }

        public IAccessToken GetAccessTokenWithCertificate(
            AdalConfiguration config,
            string clientId,
            string certificateThumbprint,
            string credentialType)
        {
            if (credentialType == AzureAccount.AccountType.User)
            {
                throw new ArgumentException(string.Format(Resources.InvalidCredentialType, "User"), "credentialType");
            }
            return new ServicePrincipalAccessToken(
                config,
                AcquireTokenWithCertificate(config, clientId, certificateThumbprint),
                (adalConfig, appId) => this.RenewWithCertificate(adalConfig, appId, certificateThumbprint), clientId);
        }

        private AuthenticationResult AcquireTokenWithSecret(AdalConfiguration config, string appId, SecureString appKey)
        {
            if (appKey == null)
            {
                return RenewWithSecret(config, appId);
            }

            StoreAppKey(appId, config.AdDomain, appKey);
            var clientId = appId ?? config.ClientId;
            var authority = config.AdEndpoint + config.AdDomain;
            var redirectUri = config.ResourceClientUri;
            var confidentialClient = SharedTokenCacheClientFactory.CreateConfidentialClient(clientId: clientId, authority: authority, redirectUri: redirectUri, clientSecret: appKey);
            var scopes = new string[] { config.ResourceClientUri + "/.default" };
            return confidentialClient.AcquireTokenForClient(scopes)
                                        .ExecuteAsync()
                                        .ConfigureAwait(false)
                                        .GetAwaiter()
                                        .GetResult();
        }

        private AuthenticationResult AcquireTokenWithCertificate(
            AdalConfiguration config,
            string appId,
            string thumbprint)
        {
            var certificate = AzureSession.Instance.DataStore.GetCertificate(thumbprint);
            if (certificate == null)
            {
                throw new ArgumentException(string.Format(Resources.CertificateNotFoundInStore, thumbprint));
            }

            var clientId = appId ?? config.ClientId;
            var authority = config.AdEndpoint + config.AdDomain;
            var redirectUri = config.ResourceClientUri;
            var confidentialClient = SharedTokenCacheClientFactory.CreateConfidentialClient(clientId: clientId, authority: authority, redirectUri: redirectUri, certificate: certificate);
            var scopes = new string[] { config.ResourceClientUri + "/.default" };
            return confidentialClient.AcquireTokenForClient(scopes).ExecuteAsync()
                                        .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private AuthenticationResult RenewWithSecret(AdalConfiguration config, string appId)
        {
            TracingAdapter.Information(Resources.SPNRenewTokenTrace, appId, config.AdDomain, config.AdEndpoint,
                config.ClientId, config.ClientRedirectUri);
                var appKey = LoadAppKey(appId, config.AdDomain);
                if (appKey == null)
                {
                    throw new KeyNotFoundException(string.Format(Resources.ServiceKeyNotFound, appId));
                }
                return AcquireTokenWithSecret(config, appId, appKey);
        }

        private AuthenticationResult RenewWithCertificate(
            AdalConfiguration config,
            string appId,
            string thumbprint)
        {
            TracingAdapter.Information(
                Resources.SPNRenewTokenTrace,
                appId,
                config.AdDomain,
                config.AdEndpoint,
                config.ClientId,
                config.ClientRedirectUri);
            return AcquireTokenWithCertificate(config, appId, thumbprint);
        }

        private SecureString LoadAppKey(string appId, string tenantId)
        {
            return KeyStore.GetKey(appId, tenantId);
        }

        private void StoreAppKey(string appId, string tenantId, SecureString appKey)
        {
            KeyStore.SaveKey(appId, tenantId, appKey);
        }

        private class ServicePrincipalAccessToken : IRenewableToken
        {
            internal readonly AdalConfiguration Configuration;
            internal AuthenticationResult AuthResult;
            private readonly Func<AdalConfiguration, string, AuthenticationResult> tokenRenewer;
            private readonly string appId;

            public ServicePrincipalAccessToken(
                AdalConfiguration configuration,
                AuthenticationResult authResult,
                Func<AdalConfiguration, string, AuthenticationResult> tokenRenewer,
                string appId)
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

                authTokenSetter("Bearer", AuthResult.AccessToken);
            }

            public string UserId { get { return appId; } }

            public string AccessToken { get { return AuthResult.AccessToken; } }

            public string LoginType { get { return Common.Authentication.LoginType.OrgId; } }

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
                    TracingAdapter.Information(
                        Resources.SPNTokenExpirationCheckTrace,
                        expiration,
                        currentTime,
                        expirationThreshold,
                        timeUntilExpiration);
                    return timeUntilExpiration < expirationThreshold;
                }
            }

            public DateTimeOffset ExpiresOn { get { return AuthResult.ExpiresOn; } }
        }
    }
}