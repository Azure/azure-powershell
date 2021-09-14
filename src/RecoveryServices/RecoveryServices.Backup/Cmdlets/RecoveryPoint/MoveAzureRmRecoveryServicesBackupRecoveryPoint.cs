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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Gets recovery points created for the provided item protected by the recovery services vault
    /// </summary>
    [Cmdlet("Move", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupRecoveryPoint", SupportsShouldProcess = true), OutputType(typeof(RecoveryPointBase))]
    public class MoveAzureRmRecoveryServicesBackupRecoveryPoint : RSBackupVaultCmdletBase
    {
        /// <summary>
        /// Recovery point to be moved to Archive Tier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0,
             HelpMessage = ParamHelpMsgs.RecoveryPoint.ArchivableRP)] 
        [ValidateNotNullOrEmpty]
        public RecoveryPointBase RecoveryPoint { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = false, Position = 1,
            HelpMessage = ParamHelpMsgs.RecoveryPoint.SourceTier)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("VaultStandard")]
        public RecoveryPointTier SourceTier { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = false, Position = 2,
            HelpMessage = ParamHelpMsgs.RecoveryPoint.DestinationTier)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("VaultArchive")]
        public RecoveryPointTier DestinationTier { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                Dictionary<Enum, object> providerParameters = new Dictionary<Enum, object>();
                providerParameters.Add(VaultParams.VaultName, vaultName);
                providerParameters.Add(VaultParams.ResourceGroupName, resourceGroupName);
                providerParameters.Add(RecoveryPointParams.RecoveryPointId, RecoveryPoint.Id);
                providerParameters.Add(RecoveryPointParams.SourceTier, SourceTier);
                providerParameters.Add(RecoveryPointParams.TargetTier, DestinationTier);

                MoveRecoveryPoint(providerParameters);
            }, ShouldProcess(RecoveryPoint.Id, VerbsCommon.Move));
        }

        private void MoveRecoveryPoint(Dictionary<Enum, object> ProviderData)
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            string recoveryPointId = (string)ProviderData[RecoveryPointParams.RecoveryPointId];
            RecoveryPointTier SourceTier = (RecoveryPointTier)ProviderData[RecoveryPointParams.SourceTier];
            RecoveryPointTier TargetTier = (RecoveryPointTier)ProviderData[RecoveryPointParams.TargetTier];

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(recoveryPointId);
            string containerUri = HelperUtils.GetContainerUri(uriDict, recoveryPointId);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, recoveryPointId);

            recoveryPointId = uriDict[UriEnums.RecoveryPoints];

            ServiceClientModel.MoveRPAcrossTiersRequest moveRPAcrossTiersRequest = new ServiceClientModel.MoveRPAcrossTiersRequest();
            moveRPAcrossTiersRequest.SourceTierType = RecoveryPointConversions.GetServiceClientRecoveryPointTier(SourceTier);
            moveRPAcrossTiersRequest.TargetTierType = RecoveryPointConversions.GetServiceClientRecoveryPointTier(TargetTier);
            
            var response = ServiceClientAdapter.MoveRecoveryPoint(
                containerUri,
                protectedItemName,
                moveRPAcrossTiersRequest,
                recoveryPointId,
                vaultName,
                resourceGroupName
                );

            HandleCreatedJob(
                   response,
                   Resources.MoveRPOperation,
                   vaultName: vaultName,
                   resourceGroupName: resourceGroupName);           
        }
    }
}
