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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.Azure.OData;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Registers container from the recovery services vault.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupProtectableContainer", DefaultParameterSetName = GetProtectableContainerParamSet), OutputType(typeof(ProtectableContainerResource))]
    public class GetAzureRmRecoveryServicesBackupProtectableContainer
        : RSBackupVaultCmdletBase
    {
        internal const string GetProtectableContainerParamSet = "GetProtectableContainer";     

        /// <summary>
        /// List of supported BackupManagementTypes for this cmdlet. Used in help text creation.
        /// </summary>
        private const string validBackupManagementTypes = "AzureWorkload";

        /// <summary>
        /// List of supported WorkloadTypes for this cmdlet. Used in help text creation.
        /// </summary>
        private const string validWorkloadTypes = "MSSQL";

        /// <summary>
        /// Azure Vm Id.
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ParameterSetName = GetProtectableContainerParamSet,
            HelpMessage = ParamHelpMsgs.Container.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// The backup management type of the container(s) to be fetched.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1,
            HelpMessage = ParamHelpMsgs.Common.BackupManagementType + validBackupManagementTypes)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("AzureWorkload")]
        public Models.BackupManagementType BackupManagementType = Models.BackupManagementType.AzureWorkload;

        /// <summary>
        /// Workload type of the item to be returned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2,
            HelpMessage = ParamHelpMsgs.Common.WorkloadType + validWorkloadTypes)]
        [ValidateSet("MSSQL")]
        [ValidateNotNullOrEmpty]
        public Models.WorkloadType WorkloadType = Models.WorkloadType.MSSQL;

        /// <summary>
        /// whether to refresh containers or not
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, HelpMessage = "use this parameter to decide to refresh or not to refresh containers")]                
        public Boolean Refresh = false;

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {   
                base.ExecuteCmdlet();

                string containerName = (ResourceId != null) ? ResourceId.Split('/')[8] : null;

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string vaultResourceGroupName = resourceIdentifier.ResourceGroupName;

                AzureWorkloadProviderHelper AzureWorkloadProviderHelper = new AzureWorkloadProviderHelper(ServiceClientAdapter);
                List<ProtectableContainerResource> protectableContainers = AzureWorkloadProviderHelper.GetProtectableContainer(vaultName, vaultResourceGroupName, containerName, Refresh);
                WriteObject(protectableContainers);
            });
        }
    }
}
