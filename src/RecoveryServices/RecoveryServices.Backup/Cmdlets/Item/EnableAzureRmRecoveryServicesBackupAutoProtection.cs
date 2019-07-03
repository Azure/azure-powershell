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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Enable auto protection of an item with the recovery services vault. 
    /// </summary>
    [Cmdlet("Enable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupAutoProtection", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class EnableAzureRmRecoveryServicesBackupAutoProtection : RSBackupVaultCmdletBase
    {
        /// <summary>
        /// Item that needs to be auto protected
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = ParamHelpMsgs.ProtectableItem.ItemObject)]
        [ValidateNotNullOrEmpty]
        public ProtectableItemBase InputItem { get; set; }

        /// <summary>
        /// Backup management type of the items to be returned.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, HelpMessage = ParamHelpMsgs.Common.BackupManagementType)]
        [ValidateNotNullOrEmpty]
        public Models.BackupManagementType BackupManagementType { get; set; }

        /// <summary>
        /// Backup management type of the items to be returned.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, HelpMessage = ParamHelpMsgs.Common.WorkloadType)]
        [ValidateNotNullOrEmpty]
        public Models.WorkloadType WorkloadType { get; set; }

        /// <summary>
        /// Policy to be associated with this item as part of the protection operation.
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, HelpMessage = ParamHelpMsgs.Policy.ProtectionPolicy)]
        [ValidateNotNullOrEmpty]
        public PolicyBase Policy { get; set; }

        /// <summary>
        /// Return the result for auto protection
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Return the result for auto protection.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                string shouldProcessName = InputItem.Id;

                string protectedItemUri = "";
                if (ShouldProcess(shouldProcessName, VerbsLifecycle.Enable))
                {
                    Dictionary<UriEnums, string> keyValueDict =
                    HelperUtils.ParseUri(InputItem.Id);

                    protectedItemUri = HelperUtils.GetProtectableItemUri(
                        keyValueDict, InputItem.Id);

                    AzureRecoveryServiceVaultProtectionIntent properties = new AzureRecoveryServiceVaultProtectionIntent();
                    properties.BackupManagementType = ServiceClientModel.BackupManagementType.AzureWorkload;
                    properties.ItemId = InputItem.Id;
                    properties.PolicyId = Policy.Id;
                    ProtectionIntentResource serviceClientRequest = new ProtectionIntentResource()
                    {
                        Properties = properties
                    };
                    bool isAutoProtectionSuccessful = false;
                    try
                    {
                        var itemResponse = ServiceClientAdapter.CreateOrUpdateProtectionIntent(
                        GetGuid ?? Guid.NewGuid().ToString(),
                        serviceClientRequest,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName);
                        isAutoProtectionSuccessful = true;
                    }
                    catch
                    {

                    }
                    if (PassThru.IsPresent)
                    {
                        WriteObject(isAutoProtectionSuccessful);
                    }
                }
            });
        }
    }
}
