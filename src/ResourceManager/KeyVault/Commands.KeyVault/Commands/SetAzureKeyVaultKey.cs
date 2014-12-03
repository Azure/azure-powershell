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
using System.Management.Automation;
using Microsoft.Azure.Commands.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault.Cmdlets
{
    /// <summary>
    /// Update attribute of a key vault key.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureKeyVaultKey")]
    [OutputType(typeof(KeyBundle))]
    public class SetAzureKeyVaultKey : KeyVaultCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ValidateNotNullOrEmpty]
        public string VaultName
        {
            get;
            set;
        }

        /// <summary>
        /// key name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [ValidateNotNullOrEmpty]
        [Alias("KeyName")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// If present, enable a key if value is true. 
        /// Disable a key if value is false.
        /// If not present, no change on current key enabled/disabled state.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "If present, enable a key if value is true. Disable a key if value is false. If not present, no change on current key enabled/disabled state.")]
        public bool? Enable
        {
            get;
            set;
        }

        /// <summary>
        /// Key expires time in UTC time
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The expiration time of a key in UTC time. If not present, no change on current key expiration time.")]
        public DateTime? Expires
        {
            get;
            set;
        }

        /// <summary>
        /// The UTC time before which key can't be used 
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The UTC time before which key can't be used. If not present, no change on current key NotBefore attribute")]
        public DateTime? NotBefore
        {
            get;
            set;
        }

        /// <summary>
        /// Key operations 
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The operations that can be performed with the key. If not present, no change on current key permitted operations.")]
        public string[] KeyOps
        {
            get;
            set;
        }

        #endregion

        public override void ExecuteCmdlet()
        {
            try
            {
                KeyAttributes attributes = new KeyAttributes
                {
                    Enabled = this.Enable,
                    Expires = this.Expires,
                    NotBefore = this.NotBefore,
                    KeyOps = this.KeyOps
                };

                WriteObject(DataServiceClient.SetKey(VaultName, Name, attributes));
            }
            catch (Exception ex)
            {
                this.WriteErrorDetails(ex);
            }
        }
    }
}
