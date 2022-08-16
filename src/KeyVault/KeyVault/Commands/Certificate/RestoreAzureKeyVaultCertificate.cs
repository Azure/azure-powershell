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

using System.IO;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Restores a certificate from a backup file into a vault 
    /// </summary>
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultCertificate",SupportsShouldProcess = true,DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType(typeof(PSKeyVaultCertificate))]
    public class RestoreAzureKeyVaultCertificate : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByVaultNameParameterSet = "ByVaultName";
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceIdParameterSet = "ByResourceId";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = ByVaultNameParameterSet,
                   HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// KeyVault object
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = ByInputObjectParameterSet,
                   ValueFromPipeline = true,
                   HelpMessage = "KeyVault object")]
        [ValidateNotNullOrEmpty]
        public PSKeyVault InputObject { get; set; }

        /// <summary>
        /// KeyVault ResourceId
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 0,
                   ParameterSetName = ByResourceIdParameterSet,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "KeyVault Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// The input file in which the backup blob is stored
        /// </summary>
        [Parameter(Mandatory = true,
                   Position = 1,
                   HelpMessage = "Input file. The input file containing the backed-up blob")]
        [ValidateNotNullOrEmpty]
        public string InputFile { get; set; }

        #endregion Input Parameter Definitions

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
            }
            else if (ResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                VaultName = resourceIdentifier.ResourceName;
            }

            if (ShouldProcess(VaultName, Properties.Resources.RestoreCertificate))
            {
                var resolvedFilePath = this.ResolveUserPath(InputFile);

                if (!AzureSession.Instance.DataStore.FileExists(resolvedFilePath))
                {
                    throw new FileNotFoundException(string.Format(Resources.BackupFileNotFound, resolvedFilePath));
                }

                var restoredCertificate = this.DataServiceClient.RestoreCertificate(VaultName, resolvedFilePath);

                this.WriteObject(restoredCertificate);
            }
        }
    }
}
