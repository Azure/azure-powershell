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

using Microsoft.Azure.Management.EventHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.EventHub.Models
{

    public class PSEncryptionAttributes
    {
        public const string DefaultClaimType = "SharedAccessKey";
        public const string DefaultClaimValue = "None";
        internal const string DefaultNamespaceAuthorizationRule = "RootManageSharedAccessKey";

        public PSEncryptionAttributes(Encryption resEncryption)
        {
            if (resEncryption != null)
            {
                KeyVaultProperties = resEncryption.KeyVaultProperties;
                KeySource = resEncryption.KeySource;
            };
        }

        /// <summary>
        /// Gets or sets properties of KeyVault
        /// </summary>
        public IList<KeyVaultProperties> KeyVaultProperties { get; set; }

        /// <summary>
        /// Gets or sets enumerates the possible value of keySource for
        /// Encryption. Possible values include: 'Microsoft.KeyVault'
        /// </summary>
        public KeySource? KeySource { get; set; }

    }
}
