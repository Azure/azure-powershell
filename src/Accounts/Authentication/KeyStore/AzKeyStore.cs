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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public class AzKeyStore : IDisposable
    {
        public const string Name = "AzKeyStore";
        private static readonly IDictionary<IKeyStoreKey, SecureString> _credentials = new Dictionary<IKeyStoreKey, SecureString>();

        [Obsolete("The constructor is deprecated. Will read key from encryted storage later.", false)]
        public AzKeyStore(IAzureContextContainer profile)
        {
            if (profile != null && profile.Accounts != null)
            {
                foreach (var account in profile.Accounts)
                {
                    if (account != null && account.ExtendedProperties.ContainsKey(AzureAccount.Property.ServicePrincipalSecret))
                    {
                        IKeyStoreKey keyStoreKey = new ServicePrincipalKey(AzureAccount.Property.ServicePrincipalSecret, account.Id
                            , account.GetTenants().FirstOrDefault());
                        var servicePrincipalSecret = account.ExtendedProperties[AzureAccount.Property.ServicePrincipalSecret];
                        _credentials[keyStoreKey] = servicePrincipalSecret.ConvertToSecureString();
                    }
                }
            }
        }

        public void ClearCache()
        {
            _credentials.Clear();
        }

        public void Dispose()
        {
            ClearCache();
        }

        public void SaveKey(IKeyStoreKey key, SecureString value)
        {
            _credentials[key] = value;
        }

        public SecureString GetKey(IKeyStoreKey key)
        {
            if (_credentials.ContainsKey(key))
            {
                return _credentials[key];
            }
            return null;
        }

        public bool DeleteKey(IKeyStoreKey key)
        {
            return _credentials.Remove(key);
        }
    }
}
