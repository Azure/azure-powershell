﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

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

        // can remove this param in breaking release 
        [Parameter(Mandatory = false, ValueFromPipeline = false, ParameterSetName = AzureRSVaultCMKParameterSet, HelpMessage = ParamHelpMsgs.Encryption.KeyVaultSubscriptionId)]
        [ValidateNotNullOrEmpty]
        public string KeyVaultSubscriptionId;

        [Parameter(Mandatory = false, ValueFromPipeline = false, ParameterSetName = AzureRSVaultCMKParameterSet, HelpMessage = ParamHelpMsgs.Encryption.InfrastructureEncryption)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter InfrastructureEncryption;

        // make this parameter mandatory in breaking release
        [Parameter(Mandatory = false, ValueFromPipeline = false, ParameterSetName = AzureRSVaultCMKParameterSet, HelpMessage = ParamHelpMsgs.Encryption.UseSystemAssignedIdentity)]
        [ValidateNotNullOrEmpty]
        public Boolean UseSystemAssignedIdentity = true;

        [Parameter(Mandatory = false, ValueFromPipeline = false, ParameterSetName = AzureRSVaultCMKParameterSet, HelpMessage = ParamHelpMsgs.Encryption.UserAssignedIdentity)]
        [ValidateNotNullOrEmpty]
        public string UserAssignedIdentity;

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
                        BackupResourceEncryptionConfigResource vaultEncryptionSettings = new BackupResourceEncryptionConfigResource();                        
                        vaultEncryptionSettings.Properties = new BackupResourceEncryptionConfig();

                        PatchVault patchVault = new PatchVault();
                        patchVault.Properties = new VaultProperties();
                        VaultPropertiesEncryption vaultEncryption = new VaultPropertiesEncryption();
                        vaultEncryption.KeyVaultProperties = new CmkKeyVaultProperties();
                        vaultEncryption.KekIdentity = new CmkKekIdentity();

                        vaultEncryption.KeyVaultProperties.KeyUri = EncryptionKeyId;

                        if (InfrastructureEncryption.IsPresent)
                        {
                            vaultEncryption.InfrastructureEncryption = "Enabled";
                        }
                        
                        vaultEncryption.KekIdentity.UseSystemAssignedIdentity = UseSystemAssignedIdentity;

                        if(!UseSystemAssignedIdentity && (UserAssignedIdentity == null || UserAssignedIdentity == ""))
                        {
                            throw new ArgumentException(Resources.IdentityIdRequiredForCMK);
                        }
                        else if (!UseSystemAssignedIdentity)
                        {
                            vaultEncryption.KekIdentity.UserAssignedIdentity = UserAssignedIdentity;
                        }

                        patchVault.Properties.Encryption = vaultEncryption;                                               
                        
                        ServiceClientAdapter.UpdateRSVault(resourceGroupName, vaultName, patchVault);
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
