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
using Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault.Cmdlets
{
    [Cmdlet(VerbsCommon.Remove, "AzureKeyVaultKey", 
        SupportsShouldProcess = true, 
        ConfirmImpact = ConfirmImpact.High)]
    [OutputType(typeof(KeyBundle))]
    public class RemoveAzureKeyVaultKey : KeyVaultCmdletBase
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
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter(Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Cmdlet does not return object by default. If this switch is specified, return a bool to enable pipeline.")]
        public SwitchParameter PassThru { get; set; }

        #endregion
        public override void ExecuteCmdlet()
        {
            try
            {
                KeyBundle keyBundle = null;
                ConfirmOperation(
                    Resources.RemoveKeyWhatIfMessage,
                    Name,
                    Resources.RemoveKeyWarning,
                    Force.IsPresent,
                    () => { keyBundle = DataServiceClient.DeleteKey(VaultName, Name); });
                
                if (PassThru.IsPresent)
                {
                    WriteObject(keyBundle);
                }
            }
            catch (Exception ex)
            {
                this.WriteErrorDetails(ex);
            }
        }
      
    }
}
