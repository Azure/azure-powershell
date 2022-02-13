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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Gets recovery points created for the provided item protected by the recovery services vault
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupRecommendedArchivableRPGroup"), OutputType(typeof(RecoveryPointBase))] 
    public class GetAzureRmRecoveryServicesBackupRecommendedArchivableRPGroup : RSBackupVaultCmdletBase
    {
        /// <summary>
        /// Protected Item object for which recovery points need to be fetched
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            Position = 2,
            HelpMessage = ParamHelpMsgs.RecoveryPoint.Item)]
        [ValidateNotNullOrEmpty]
        public ItemBase Item { get; set; }

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
                providerParameters.Add(RecoveryPointParams.Item, Item);

                if (Item.BackupManagementType == BackupManagementType.AzureVM)
                {
                    var rpList = GetMoveRecommendedRecoveryPoints(providerParameters);

                    WriteDebug(string.Format("RPCount in Response = {0}", rpList.Count));
                    WriteObject(rpList, enumerateCollection: true);
                }
                else
                {
                    throw new ArgumentException(Resources.ArchiveRecommendationNotSupported);
                }                
            });            
        }

        private List<RecoveryPointBase> GetMoveRecommendedRecoveryPoints(Dictionary<Enum, object> ProviderData)
        {
            string vaultName = (string)ProviderData[VaultParams.VaultName];
            string resourceGroupName = (string)ProviderData[VaultParams.ResourceGroupName];
            ItemBase item = ProviderData[RecoveryPointParams.Item] as ItemBase;

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            ServiceClientModel.ListRecoveryPointsRecommendedForMoveRequest moveRequest = new ServiceClientModel.ListRecoveryPointsRecommendedForMoveRequest();

            List<ServiceClientModel.RecoveryPointResource> rpListResponse;
            rpListResponse = ServiceClientAdapter.GetMoveRecommendedRecoveryPoints(
                containerUri,
                protectedItemName,
                moveRequest,               
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            return RecoveryPointConversions.GetPSAzureRecoveryPoints(rpListResponse, item);
        }
    }
}
