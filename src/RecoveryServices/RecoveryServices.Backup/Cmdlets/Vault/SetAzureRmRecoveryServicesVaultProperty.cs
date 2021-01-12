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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Used to set RecoveryServices Vault properties
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesVaultProperty", DefaultParameterSetName = AzureRSVaultSoftDelteParameterSet, SupportsShouldProcess = true), OutputType(typeof(BackupResourceVaultConfigResource))]
    public class SetAzureRmRecoveryServicesVaultProperty : RSBackupVaultCmdletBase
    {
        internal const string AzureRSVaultSoftDelteParameterSet = "AzureRSVaultSoftDelteParameterSet";
        internal const string AzureRSVaultCMKParameterSet = "AzureRSVaultCMKParameterSet";

        [Parameter(Mandatory = true, ValueFromPipeline = false, ParameterSetName = AzureRSVaultSoftDelteParameterSet)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Enable", "Disable")]
        public string SoftDeleteFeatureState { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = false, ParameterSetName = AzureRSVaultCMKParameterSet, HelpMessage = ParamHelpMsgs.Encryption.EncryptionKeyID)]
        [ValidateNotNullOrEmpty]
        public string EncryptionKeyId;

        [Parameter(Mandatory = true, ValueFromPipeline = false, ParameterSetName = AzureRSVaultCMKParameterSet, HelpMessage = ParamHelpMsgs.Encryption.KeyVaultSubscriptionId)]
        [ValidateNotNullOrEmpty]
        public string KeyVaultSubscriptionId;

        [Parameter(Mandatory = false, ValueFromPipeline = false, ParameterSetName = AzureRSVaultCMKParameterSet, HelpMessage = ParamHelpMsgs.Encryption.InfrastructureEncryption)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter InfrastructureEncryption;

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                try
                {
                    ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                    string vaultName = resourceIdentifier.ResourceName;
                    string resourceGroupName = resourceIdentifier.ResourceGroupName;

                    if (SoftDeleteFeatureState != null)
                    {
                        BackupResourceVaultConfigResource currentConfig = ServiceClientAdapter.GetVaultProperty(vaultName, resourceGroupName);

                        BackupResourceVaultConfigResource param = new BackupResourceVaultConfigResource();
                        param.Properties = new BackupResourceVaultConfig();
                        param.Properties.SoftDeleteFeatureState = SoftDeleteFeatureState + "d";
                        param.Properties.EnhancedSecurityState = currentConfig.Properties.EnhancedSecurityState;
                        BackupResourceVaultConfigResource result = ServiceClientAdapter.SetVaultProperty(vaultName, resourceGroupName, param);
                        WriteObject(result.Properties);
                    }
                    else if (EncryptionKeyId != null)
                    {
                        BackupResourceEncryptionConfigResource vaultEncryptionSettings = ServiceClientAdapter.GetVaultEncryptionConfig(resourceGroupName, vaultName);

                        vaultEncryptionSettings.Properties.EncryptionAtRestType = "CustomerManaged";
                        vaultEncryptionSettings.Properties.KeyUri = EncryptionKeyId;
                        if (InfrastructureEncryption.IsPresent)
                        {
                            vaultEncryptionSettings.Properties.InfrastructureEncryptionState = "Enabled";
                        }
                        vaultEncryptionSettings.Properties.SubscriptionId = KeyVaultSubscriptionId;
                        vaultEncryptionSettings.Properties.LastUpdateStatus = null;
                        var response = ServiceClientAdapter.UpdateVaultEncryptionConfig(resourceGroupName, vaultName, vaultEncryptionSettings);
                    }
                }
                catch (Exception exception)
                {
                    WriteExceptionError(exception);
                }
            }, ShouldProcess(VaultId, VerbsCommon.Set));
        }
    }
}
