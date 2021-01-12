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
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Gets recovery points created for the provided item protected by the recovery services vault
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupRecoveryPoint", DefaultParameterSetName = NoFilterParameterSet), OutputType(typeof(RecoveryPointBase))]
    public class GetAzureRmRecoveryServicesBackupRecoveryPoint : RSBackupVaultCmdletBase
    {
        internal const string DateTimeFilterParameterSet = "DateTimeFilter";
        internal const string NoFilterParameterSet = "NoFilterParameterSet";
        internal const string RecoveryPointIdParameterSet = "RecoveryPointId";

        /// <summary>
        /// Start time of Time range for which recovery point needs to be fetched
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = DateTimeFilterParameterSet,
            ValueFromPipeline = false, Position = 0, HelpMessage = ParamHelpMsgs.RecoveryPoint.StartDate)]
        [ValidateNotNullOrEmpty]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// End time of Time range for which recovery points need to be fetched
        /// </summary>
        [Parameter(
            Mandatory = false,
            ParameterSetName = DateTimeFilterParameterSet,
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
            ParameterSetName = DateTimeFilterParameterSet,
            ValueFromPipeline = true,
            Position = 2,
            HelpMessage = ParamHelpMsgs.RecoveryPoint.Item)]
        [Parameter(
            Mandatory = true,
            ParameterSetName = RecoveryPointIdParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = ParamHelpMsgs.RecoveryPoint.Item)]
        [Parameter(
            Mandatory = true,
            ParameterSetName = NoFilterParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = ParamHelpMsgs.RecoveryPoint.Item)]
        [ValidateNotNullOrEmpty]
        public ItemBase Item { get; set; }

        /// <summary>
        /// Recovery point Id for which detail is needed
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = RecoveryPointIdParameterSet,
            ValueFromPipeline = false, Position = 1, HelpMessage = ParamHelpMsgs.RecoveryPoint.RecoveryPointId)]
        [ValidateNotNullOrEmpty]
        public string RecoveryPointId { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = RecoveryPointIdParameterSet,
            ValueFromPipeline = false,
            Position = 2,
            HelpMessage = ParamHelpMsgs.RecoveryPoint.KeyFileDownloadLocation)]
        [ValidateNotNullOrEmpty]
        public string KeyFileDownloadLocation { get; set; }

        /// <summary>
        /// Switch param to filter RecoveryPoints based on secondary region (Cross Region Restore).
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Common.UseSecondaryReg)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter UseSecondaryRegion { get; set; }

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
                providerParameters.Add(CRRParams.UseSecondaryRegion, UseSecondaryRegion.IsPresent);
                

                if (ParameterSetName == DateTimeFilterParameterSet ||
                    ParameterSetName == NoFilterParameterSet)
                {
                    // if both start and end date are given by user
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
                    if (string.Compare(Item.BackupManagementType.ToString(),
                        BackupManagementType.AzureWorkload.ToString()) == 0)
                    {
                        providerParameters.Add(RecoveryPointParams.RestorePointQueryType, "FullAndDifferential");
                    }

                    PsBackupProviderManager providerManager =
                        new PsBackupProviderManager(providerParameters, ServiceClientAdapter);
                    IPsBackupProvider psBackupProvider =
                        providerManager.GetProviderInstance(Item.ContainerType, Item.BackupManagementType);
                    var rpList = psBackupProvider.ListRecoveryPoints();

                    WriteDebug(string.Format("RPCount in Response = {0}", rpList.Count));
                    WriteObject(rpList, enumerateCollection: true);
                }
                else if (ParameterSetName == RecoveryPointIdParameterSet)
                {
                    //User want details of a particular recovery point
                    WriteDebug(string.Format("ParameterSet = DateTimeFilterParameterSet. \n" +
                        "StartDate = {0} EndDate = {1}, RPId = {2}, KeyFileDownloadLocation = {3}",
                        StartDate, EndDate, RecoveryPointId, KeyFileDownloadLocation));

                    providerParameters.Add(RecoveryPointParams.RecoveryPointId, RecoveryPointId);
                    providerParameters.Add(
                        RecoveryPointParams.KeyFileDownloadLocation, KeyFileDownloadLocation);
                    PsBackupProviderManager providerManager =
                        new PsBackupProviderManager(providerParameters, ServiceClientAdapter);
                    IPsBackupProvider psBackupProvider =
                        providerManager.GetProviderInstance(Item.ContainerType, Item.BackupManagementType);
                    WriteObject(psBackupProvider.GetRecoveryPointDetails());
                }
                else
                {
                    throw new Exception(Resources.RecoveryPointUnsupportedParamet);
                }
            });
        }
    }
}
