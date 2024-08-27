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
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Used to get RecoveryServices Vault properties
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesVaultProperty"), OutputType(typeof(VaultProperty))]
    public class GetAzureRmRecoveryServicesVaultProperties : RSBackupVaultCmdletBase
    {
        public override void ExecuteCmdlet()
        {
            try
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                // resx
                WriteWarning("The following CMK Encryption properties are deprecated: EncryptionAtRestType, SubscriptionId, LastUpdateStatus, Id, Name, Type, Location. Please avoid using these properties.");

                BackupResourceEncryptionConfigExtendedResource vaultEncryptionSetting = ServiceClientAdapter.GetVaultEncryptionConfig(resourceGroupName, vaultName);
                BackupResourceVaultConfigResource vaultConfigResource = ServiceClientAdapter.GetVaultProperty(vaultName, resourceGroupName);
                
                VaultProperty vaultProperty = new VaultProperty(vaultConfigResource.Properties, vaultEncryptionSetting);
                
                WriteObject(vaultProperty);
            }
            catch (Exception exception)
            {
                WriteExceptionError(exception);
            }
        }
    }
}
