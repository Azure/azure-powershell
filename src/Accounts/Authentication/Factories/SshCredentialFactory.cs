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
using Microsoft.Azure.Commands.Common.Authentication.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Identity.Client.SSHCertificates;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication.Factories
{
    public class SshCredentialFactory : ISshCredentialFactory
    {

        private readonly Dictionary<string, string> CloudToScope = new Dictionary<string, string>()
        {
            { "azurecloud", "https://pas.windows.net/CheckMyAccess/Linux/.default" },
            { "azurechinacloud", "https://pas.chinacloudapi.cn/CheckMyAccess/Linux/.default" },
            { "azureusgovernment", "https://pasff.usgovcloudapi.net/CheckMyAccess/Linux/.default" },
        };

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

            var publicClient = tokenCacheProvider.CreatePublicClient();
            string cloudName = context.Environment.Name.ToLower();
            string scope = CloudToScope.GetValueOrDefault(cloudName, null);
            if (scope == null)
            {
                throw new Exception(string.Format("Unsupported cloud {0}. Supported clouds include AzureCloud,AzureChinaCloud,AzureUSGovernment.", cloudName));
            }
            List<string> scopes = new List<string>() { scope };
            var jwk = CreateJwk(rsaKeyInfo, out string keyId);

            var account = publicClient.GetAccountAsync(context.Account.ExtendedProperties["HomeAccountId"])
                            .ConfigureAwait(false).GetAwaiter().GetResult();
            var result = publicClient.AcquireTokenSilent(scopes, account)
                        .WithSSHCertificateAuthenticationScheme(jwk, keyId)
                        .ExecuteAsync();
            var accessToken = result.ConfigureAwait(false).GetAwaiter().GetResult();

            var resultToken = new SshCredential()
            {
                Credential = accessToken.AccessToken,
                ExpiresOn = accessToken.ExpiresOn,
            };
            return resultToken;
        }
    }
}
