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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
#if NETSTANDARD
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
#endif
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    /// <summary>
    /// Helper class to store service principal keys and retrieve them
    /// from the Windows Credential Store.
    /// </summary>
    public class AzureRmServicePrincipalKeyStore : IServicePrincipalKeyStore
    {
        public const string Name = "ServicePrincipalKeyStore";
        private IDictionary<string, SecureString> _credentials { get; set; }

        public AzureRmServicePrincipalKeyStore() : this(null) { }

        public AzureRmServicePrincipalKeyStore(IAzureContextContainer profile)
        {
            _credentials = new Dictionary<string, SecureString>();
            if (profile != null && profile.Accounts != null)
            {
                foreach (var account in profile.Accounts)
                {
                    if (account != null && account.ExtendedProperties.ContainsKey(AzureAccount.Property.ServicePrincipalSecret))
                    {
                        var appId = account.Id;
                        var tenantId = account.GetTenants().FirstOrDefault();
                        var key = CreateKey(appId, tenantId);
                        var servicePrincipalSecret = account.ExtendedProperties[AzureAccount.Property.ServicePrincipalSecret];
                        _credentials[key] = ConvertToSecureString(servicePrincipalSecret);
                    }
                }
            }
        }

        public void SaveKey(string appId, string tenantId, SecureString serviceKey)
        {
            var key = CreateKey(appId, tenantId);
            _credentials[key] = serviceKey;
        }

        public SecureString GetKey(string appId, string tenantId)
        {
            IntPtr pCredential = IntPtr.Zero;
            try
            {
                var key = CreateKey(appId, tenantId);
                return _credentials[key];

            }
            catch
            {
                // we could be running in an environment that does not have credentials store
            }

            return null;
        }


        public void DeleteKey(string appId, string tenantId)
        {
            try
            {
                var key = CreateKey(appId, tenantId);
                _credentials.Remove(key);
            }
            catch
            {
            }
        }

        private string CreateKey(string appId, string tenantId)
        {
            return $"{appId}_{tenantId}";
        }

        internal SecureString ConvertToSecureString(string password)
        {
            if (password == null)
                throw new ArgumentNullException("password");

            var securePassword = new SecureString();

            foreach (char c in password)
                securePassword.AppendChar(c);

            securePassword.MakeReadOnly();
            return securePassword;
        }
    }
}