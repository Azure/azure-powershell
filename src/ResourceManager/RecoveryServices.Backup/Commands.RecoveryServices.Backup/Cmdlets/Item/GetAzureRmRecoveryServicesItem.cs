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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Get list of items
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmRecoveryServicesBackupItem"), OutputType(typeof(AzureRmRecoveryServicesBackupItemBase))]
    public class GetAzureRmRecoveryServicesBackupItem : RecoveryServicesBackupCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsg.Item.Container)]
        [ValidateNotNullOrEmpty]
        public AzureRmRecoveryServicesBackupContainerBase Container { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsg.Item.AzureVMName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsg.Item.ProtectionStatus)]
        [ValidateNotNullOrEmpty]
        public ItemProtectionStatus ProtectionStatus { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsg.Item.Status)]
        [ValidateNotNullOrEmpty]
        public ItemProtectionState ProtectionState { get; set; }

        [Parameter(Mandatory = true, HelpMessage = ParamHelpMsg.Common.WorkloadType)]
        [ValidateNotNullOrEmpty]
        public WorkloadType WorkloadType { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                PsBackupProviderManager providerManager = new PsBackupProviderManager(new Dictionary<System.Enum, object>()
                {
                    {ItemParams.Container, Container},
                    {ItemParams.AzureVMName, Name},
                    {ItemParams.ProtectionStatus, ProtectionStatus},
                    {ItemParams.ProtectionState, ProtectionState},
                    {ItemParams.WorkloadType, WorkloadType},
                }, HydraAdapter);

                IPsBackupProvider psBackupProvider = providerManager.GetProviderInstance(WorkloadType,
                    (Container as AzureRmRecoveryServicesBackupManagementContext).BackupManagementType);
                var itemModels = psBackupProvider.ListProtectedItems();

                if (itemModels.Count == 1)
                {
                    WriteObject(itemModels.First());
                }
                else
                {
                    WriteObject(itemModels, enumerateCollection: true);
                }
            });
        }
    }
}
