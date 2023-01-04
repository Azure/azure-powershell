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
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    public class PSNetAppFilesKeyVaultProperties
    {
        /// <summary>
        /// Gets UUID v4 used to identify the Azure Key Vault configuration
        /// </summary>
        public string KeyVaultId { get; set; }

        /// <summary>
        /// Gets or sets the Uri of KeyVault.
        /// </summary>
        public string KeyVaultUri { get; set; }

        /// <summary>
        /// Gets or sets the name of KeyVault key.
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of KeyVault.
        /// </summary>
        public string KeyVaultResourceId { get; set; }

        /// <summary>
        /// Gets status of the KeyVault connection. Possible values include:
        /// 'Created', 'InUse', 'Deleted', 'Error', 'Updating'
        /// </summary>
        public string Status { get; set; }

    }
}
