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
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Gets recovery points created for the provided item protected by the recovery services vault
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupRecommendedArchivableRPGroup"), OutputType(typeof(RecoveryPointBase))] 
    public class GetAzureRmRecoveryServicesBackupRecommendedArchivableRPGroup : RSBackupVaultCmdletBase
    {
        /// <summary>
        /// Start time of Time range for which recovery point needs to be fetched
        /// </summary>
        [Parameter(Mandatory = false, 
            ValueFromPipeline = false, Position = 0, HelpMessage = ParamHelpMsgs.RecoveryPoint.StartDate)] 
        [ValidateNotNullOrEmpty]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// End time of Time range for which recovery points need to be fetched
        /// </summary>
        [Parameter(
            Mandatory = false,
            //ParameterSetName = DateTimeFilterParameterSet,
            ValueFromPipeline = false,
            Position = 1,
            HelpMessage = ParamHelpMsgs.RecoveryPoint.EndDate)]
        [ValidateNotNullOrEmpty]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Protected Item object for which recovery points need to be fetched
        /// </summary>
        [Parameter(
            Mandatory = true,
            //ParameterSetName = DateTimeFilterParameterSet,
            ValueFromPipeline = true,
            Position = 2,
            HelpMessage = ParamHelpMsgs.RecoveryPoint.Item)]
        [ValidateNotNullOrEmpty]
        public ItemBase Item { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                //Validate start time < end time
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                // initialize values to default
                DateTime rangeEnd = DateTime.UtcNow;
                DateTime rangeStart = rangeEnd.AddDays(-30);

                Dictionary<Enum, object> providerParameters = new Dictionary<Enum, object>();
                providerParameters.Add(VaultParams.VaultName, vaultName);
                providerParameters.Add(VaultParams.ResourceGroupName, resourceGroupName);
                providerParameters.Add(RecoveryPointParams.Item, Item);

                if (StartDate.HasValue && EndDate.HasValue)
                {
                    rangeStart = StartDate.Value;
                    rangeEnd = EndDate.Value;
                }
                // if only start date is given by user
                else if (StartDate.HasValue && EndDate.HasValue == false)
                {
                    rangeStart = StartDate.Value;
                    rangeEnd = rangeStart.AddDays(30);
                }
                // if only end date is given by user
                else if (EndDate.HasValue && StartDate.HasValue == false)
                {
                    rangeEnd = EndDate.Value;
                    rangeStart = rangeEnd.AddDays(-30);
                }

                //User want list of RPs between given time range
                WriteDebug(string.Format("ParameterSet = DateTimeFilterParameterSet. \n" +
                    "StartDate = {0} EndDate = {1}, Item.Name = {2}, Item.ContainerName = {3}",
                    rangeStart, rangeEnd, Item.Name, Item.ContainerName));
                if (rangeStart >= rangeEnd)
                {
                    throw new ArgumentException(Resources.RecoveryPointEndDateShouldBeGreater);
                }

                if (rangeStart.Kind != DateTimeKind.Utc || rangeEnd.Kind != DateTimeKind.Utc)
                {
                    throw new ArgumentException(Resources.GetRPErrorInputDatesShouldBeInUTC);
                }

                if (rangeStart > DateTime.UtcNow)
                {
                    throw new ArgumentException(
                        Resources.GetRPErrorStartTimeShouldBeLessThanUTCNow);
                }

                providerParameters.Add(RecoveryPointParams.StartDate, rangeStart);
                providerParameters.Add(RecoveryPointParams.EndDate, rangeEnd);

                if (Item.BackupManagementType == BackupManagementType.AzureVM)
                {
                    var rpList = GetMoveRecommendedRecoveryPoints(providerParameters); //psBackupProvider.ListRecoveryPoints();

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
            DateTime startDate = (DateTime)(ProviderData[RecoveryPointParams.StartDate]);
            DateTime endDate = (DateTime)(ProviderData[RecoveryPointParams.EndDate]);
            
            ItemBase item = ProviderData[RecoveryPointParams.Item] as ItemBase;

            Dictionary<UriEnums, string> uriDict = HelperUtils.ParseUri(item.Id);
            string containerUri = HelperUtils.GetContainerUri(uriDict, item.Id);
            string protectedItemName = HelperUtils.GetProtectedItemUri(uriDict, item.Id);

            TimeSpan duration = endDate - startDate;
            if (duration.TotalDays > 30)
            {
                throw new Exception(Resources.RestoreDiskTimeRangeError);
            }

            ServiceClientModel.ListRecoveryPointsRecommendedForMoveRequest moveRequest = new ServiceClientModel.ListRecoveryPointsRecommendedForMoveRequest();
            // moveRequest.ObjectType = ?? 
            // moveRequest.ExcludedRPList = ?? 

            List<ServiceClientModel.RecoveryPointResource> rpListResponse;
            rpListResponse = ServiceClientAdapter.GetMoveRecommendedRecoveryPoints(
                containerUri,
                protectedItemName,
                moveRequest,
                // queryFilter,                 
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            return RecoveryPointConversions.GetPSAzureRecoveryPoints(rpListResponse, item);
        }
    }
}
