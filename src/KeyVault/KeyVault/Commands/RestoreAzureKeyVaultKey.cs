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

using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Restores the backup key into a vault
    /// </summary>
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKey", SupportsShouldProcess = true, DefaultParameterSetName = ByVaultNameParameterSet)]
    [OutputType(typeof(PSKeyVaultKey))]
    public class RestoreAzureKeyVaultKey : KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string ByVaultNameParameterSet = "ByVaultName";
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceIdParameterSet = "ByResourceId";
        private const string HsmByVaultNameParameterSet = "HsmByVaultName";
        private const string HsmByInputObjectParameterSet = "HsmByInputObject";
        private const string HsmByResourceIdParameterSet = "HsmByResourceId";

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

        [Parameter(Mandatory = true,
            ParameterSetName = HsmByVaultNameParameterSet,
            HelpMessage = "HSM name. Cmdlet constructs the FQDN of a managed HSM based on the name and currently selected environment.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string HsmName { get; set; }

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

        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = HsmByInputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "HSM object")]
        [ValidateNotNullOrEmpty]
        public PSManagedHsm HsmObject { get; set; }

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

        [Parameter(Mandatory = true,
            ParameterSetName = HsmByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Hsm Resource Id")]
        [ValidateNotNullOrEmpty]
        public string HsmResourceId { get; set; }

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
            NormalizeParameterSets();

            if (string.IsNullOrEmpty(HsmName))
            {
                RestoreKeyVaultKey();
            }
            else
            {
                RestoreHsmKey();
            }
        }

        private void NormalizeParameterSets()
        {
            if (InputObject != null)
            {
                VaultName = InputObject.VaultName;
            }
            if (ResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                VaultName = resourceIdentifier.ResourceName;
            }
            if (HsmObject != null)
            {
                HsmName = HsmObject.VaultName;
            }
            if (HsmResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(HsmResourceId);
                HsmName = resourceIdentifier.ResourceName;
            }
        }

        private void RestoreKeyVaultKey()
        {
            if (ShouldProcess(VaultName, Properties.Resources.RestoreKey))
            {
                var filePath = ResolveKeyPath(InputFile);

                var restoredKeyBundle = this.DataServiceClient.RestoreKey(VaultName, filePath);

                this.WriteObject(restoredKeyBundle);
            }
        }

        private string ResolveKeyPath(string filePath)
        {
            FileInfo keyFile = new FileInfo(this.ResolveUserPath(filePath));
            if (!keyFile.Exists)
            {
                throw new FileNotFoundException(string.Format(Resources.BackupKeyFileNotFound, filePath));
            }
            return keyFile.FullName;
        }

        private void RestoreHsmKey()
        {
            if (ShouldProcess(HsmName, Properties.Resources.RestoreKey))
            {
                var filePath = ResolveKeyPath(InputFile);

                var restoredKeyBundle = this.Track2DataClient.RestoreManagedHsmKey(HsmName, filePath);

                this.WriteObject(restoredKeyBundle);
            }
        }
    }
}
