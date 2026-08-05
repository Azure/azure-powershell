// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Models;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.AuthScheme;
using Microsoft.Identity.Client.Extensibility;
using Microsoft.Identity.Client.SSHCertificates;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication.Factories
{
    public class SshCredentialFactory : ISshCredentialFactory
    {
        private const string AadSshLoginForLinuxServerAppId = "ce6ff14a-7fdc-4685-bbe0-f6afdfcfa8e0";

        private string CreateJwk(RSAParameters rsaKeyInfo, out string keyId)
        {
            string modulus = Base64UrlHelper.Encode(rsaKeyInfo.Modulus);
            string exp = Base64UrlHelper.Encode(rsaKeyInfo.Exponent);

            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(modulus + exp));
            StringBuilder hex = new StringBuilder(hash.Length * 2);
            for (int i = 0; i < hash.Length; ++i)
            {
                hex.AppendFormat("{0:x2}", hash[i]);
            }
            keyId = hex.ToString();
            Dictionary<string, object> jwk = new Dictionary<string, object>
            {
                { "kty", "RSA" },
                { "kid", keyId },
                { "n", modulus },
                { "e", exp }
            };

            return JsonConvert.SerializeObject(jwk);
        }

        public SshCredential GetSshCredential(IAzureContext context, RSAParameters rsaKeyInfo)
        {
            if (!AzureSession.Instance.TryGetComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, out PowerShellTokenCacheProvider tokenCacheProvider))
            {
                throw new NullReferenceException(Resources.AuthenticationClientFactoryNotRegistered);
            }

            string scope = GetAuthScope();
            List<string> scopes = new List<string>() { scope };
            var jwk = CreateJwk(rsaKeyInfo, out string keyId);

            switch (context.Account.Type)
            {
                case AzureAccount.AccountType.User:
                    return AcquireTokenForUser(tokenCacheProvider, context, scopes, jwk, keyId);
                case AzureAccount.AccountType.ServicePrincipal:
                    return AcquireTokenForServicePrincipal(tokenCacheProvider, context, scopes, jwk, keyId);
                default:
                    throw new InvalidOperationException(string.Format(Resources.UnsupportedAccountTypeForSshCertificate, context.Account.Type));
            }
        }

        private SshCredential AcquireTokenForUser(PowerShellTokenCacheProvider tokenCacheProvider, IAzureContext context, List<string> scopes, string jwk, string keyId)
        {
            var publicClient = tokenCacheProvider.CreatePublicClient(context.Environment.ActiveDirectoryAuthority, context.Tenant.Id);

            var account = publicClient.GetAccountAsync(context.Account.ExtendedProperties["HomeAccountId"])
                            .ConfigureAwait(false).GetAwaiter().GetResult();
            var result = publicClient.AcquireTokenSilent(scopes, account)
                        .WithSSHCertificateAuthenticationScheme(jwk, keyId)
                        .ExecuteAsync();
            var accessToken = result.ConfigureAwait(false).GetAwaiter().GetResult();

            return new SshCredential()
            {
                Credential = accessToken.AccessToken,
                ExpiresOn = accessToken.ExpiresOn,
            };
        }

        private SshCredential AcquireTokenForServicePrincipal(PowerShellTokenCacheProvider tokenCacheProvider, IAzureContext context, List<string> scopes, string jwk, string keyId)
        {
            string authority = context.Environment.ActiveDirectoryAuthority;
            string tenantId = context.Tenant.Id;
            string clientId = context.Account.Id;

            var confidentialClient = CreateConfidentialClientForServicePrincipal(tokenCacheProvider, authority, tenantId, clientId, context);

            var authExtension = new MsalAuthenticationExtension
            {
                AuthenticationOperation = new SshCertAuthOperation(keyId, jwk)
            };

            var result = confidentialClient.AcquireTokenForClient(scopes)
                        .WithForceRefresh(true)
                        .WithAuthenticationExtension(authExtension)
                        .ExecuteAsync()
                        .ConfigureAwait(false).GetAwaiter().GetResult();

            return new SshCredential()
            {
                Credential = result.AccessToken,
                ExpiresOn = result.ExpiresOn,
            };
        }

        private IConfidentialClientApplication CreateConfidentialClientForServicePrincipal(PowerShellTokenCacheProvider tokenCacheProvider, string authority, string tenantId, string clientId, IAzureContext context)
        {
            // Try certificate thumbprint first
            string thumbprint = context.Account.GetProperty(AzureAccount.Property.CertificateThumbprint);
            if (!string.IsNullOrEmpty(thumbprint))
            {
                var certificate = AzureSession.Instance.DataStore.GetCertificate(thumbprint);
                if (certificate != null)
                {
                    return tokenCacheProvider.CreateConfidentialClient(authority, tenantId, clientId, certificate);
                }
            }

            // Try certificate path
            string certificatePath = context.Account.GetProperty(AzureAccount.Property.CertificatePath);
            if (!string.IsNullOrEmpty(certificatePath))
            {
                SecureString certificatePassword = GetServicePrincipalSecureString(context, AzureAccount.Property.CertificatePassword);
                X509Certificate2 certificate = certificatePassword != null
                    ? new X509Certificate2(certificatePath, certificatePassword)
                    : new X509Certificate2(certificatePath);
                return tokenCacheProvider.CreateConfidentialClient(authority, tenantId, clientId, certificate);
            }

            // Try client secret
            string secret = context.Account.GetProperty(AzureAccount.Property.ServicePrincipalSecret);
            if (string.IsNullOrEmpty(secret))
            {
                SecureString secureSecret = GetServicePrincipalSecureString(context, AzureAccount.Property.ServicePrincipalSecret);
                if (secureSecret != null)
                {
                    secret = ConvertToPlainText(secureSecret);
                }
            }

            if (!string.IsNullOrEmpty(secret))
            {
                return tokenCacheProvider.CreateConfidentialClient(authority, tenantId, clientId, secret);
            }

            throw new InvalidOperationException(Resources.ServicePrincipalCredentialNotFound);
        }

        private SecureString GetServicePrincipalSecureString(IAzureContext context, string propertyName)
        {
            try
            {
                if (AzureSession.Instance.TryGetComponent(AzKeyStore.Name, out AzKeyStore keyStore))
                {
                    return keyStore.GetSecureString(new ServicePrincipalKey(propertyName, context.Account.Id, context.Tenant.Id));
                }
            }
            catch
            {
                // Key not found in store, return null
            }
            return null;
        }

        private static string ConvertToPlainText(SecureString secureString)
        {
            if (secureString == null)
            {
                return null;
            }
            var ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(secureString);
            try
            {
                return System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            }
        }

        private string GetAuthScope()
        {
            return $"{AadSshLoginForLinuxServerAppId}/.default";
        }

        /// <summary>
        /// Custom IAuthenticationOperation that instructs MSAL to request and accept
        /// SSH certificate token type instead of bearer tokens.
        /// This is the equivalent of WithSSHCertificateAuthenticationScheme for confidential client flows.
        /// </summary>
        private class SshCertAuthOperation : IAuthenticationOperation
        {
            private const string SshCertTokenType = "ssh-cert";
            private readonly string _jwk;

            public SshCertAuthOperation(string keyId, string jwk)
            {
                KeyId = keyId;
                _jwk = jwk;
            }

            public int TelemetryTokenType => 3;

            public string AuthorizationHeaderPrefix =>
                throw new InvalidOperationException("SSH certificates cannot be used as HTTP authorization headers.");

            public string AccessTokenType => SshCertTokenType;

            public string KeyId { get; }

            public IReadOnlyDictionary<string, string> GetTokenRequestParams()
            {
                return new Dictionary<string, string>
                {
                    { "token_type", SshCertTokenType },
                    { "req_cnf", _jwk }
                };
            }

            public void FormatResult(AuthenticationResult authenticationResult)
            {
                // no-op
            }
        }
    }
}
