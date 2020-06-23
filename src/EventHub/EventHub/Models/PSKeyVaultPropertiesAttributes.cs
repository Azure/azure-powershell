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

    public class PSKeyVaultPropertiesAttributes
    {
        public const string DefaultClaimType = "SharedAccessKey";
        public const string DefaultClaimValue = "None";
        internal const string DefaultNamespaceAuthorizationRule = "RootManageSharedAccessKey";

        public PSKeyVaultPropertiesAttributes(KeyVaultProperties resKeyVaultProperties)
        {
            if (resKeyVaultProperties != null)
            {
                KeyName = resKeyVaultProperties.KeyName;
                KeyVaultUri = resKeyVaultProperties.KeyVaultUri;
                KeyVersion = resKeyVaultProperties.KeyVersion;
            };
        }

        /// <summary>
        /// Gets or sets name of the Key from KeyVault
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// Gets or sets uri of KeyVault
        /// </summary>
        public string KeyVaultUri { get; set; }

        /// <summary>
        /// Gets or sets key Version
        /// </summary>
        public string KeyVersion { get; set; }

    }
}
