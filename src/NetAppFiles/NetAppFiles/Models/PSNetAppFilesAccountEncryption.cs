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

using Microsoft.Azure.Commands.NetAppFiles.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    public class PSNetAppFilesAccountEncryption
    {
        /// <summary>
        /// Gets or sets the encryption keySource (provider). Possible values
        /// (case-insensitive):  Microsoft.NetApp, Microsoft.KeyVault. Possible
        /// values include: 'Microsoft.NetApp', 'Microsoft.KeyVault'
        /// </summary>
        public string KeySource { get; set; }

        /// <summary>
        /// Gets or sets properties provided by KeVault. Applicable if
        /// keySource is 'Microsoft.KeyVault'.
        /// </summary>
        public PSNetAppFilesKeyVaultProperties KeyVaultProperties { get; set; }

        /// <summary>
        /// Gets or sets identity used to authenticate to KeyVault. Applicable
        /// if keySource is 'Microsoft.KeyVault'.
        /// </summary>
        public PSEncryptionIdentity Identity { get; set; }
    }
}
