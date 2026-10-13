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

        /// <summary>
        /// Filter Recovery Points based on Tier
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = DateTimeFilterParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.Tier)]
        [Parameter(Mandatory = false, ParameterSetName = NoFilterParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.Tier)]
        [ValidateNotNullOrEmpty]
        public RecoveryPointTier Tier { get; set; }

        /// <summary>
        /// checks whether the RP is Ready to move to target tier
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = DateTimeFilterParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.IsReadyForMove)]
        [Parameter(Mandatory = false, ParameterSetName = NoFilterParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.IsReadyForMove)]
        [ValidateNotNullOrEmpty]
        public bool IsReadyForMove { get; set; }

        /// <summary>
        /// Target tier to check move readiness
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = DateTimeFilterParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.TargetTier)]
        [Parameter(Mandatory = false, ParameterSetName = NoFilterParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.TargetTier)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("VaultArchive")]
        public RecoveryPointTier TargetTier { get; set; }

        /// <summary>
        /// When set, only the latest recovery point for the item is fetched.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = DateTimeFilterParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.GetLatestRecoveryPointOnly)]
        [Parameter(Mandatory = false, ParameterSetName = NoFilterParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.GetLatestRecoveryPointOnly)]
        public SwitchParameter GetLatestRecoveryPointOnly { get; set; }

        /// <summary>
        /// Id of the base snapshot recovery point.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = DateTimeFilterParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.BaseSnapshotRecoveryPointId)]
        [Parameter(Mandatory = false, ParameterSetName = NoFilterParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.BaseSnapshotRecoveryPointId)]
        [ValidateNotNullOrEmpty]
        public string BaseSnapshotRecoveryPointId { get; set; }

        /// <summary>
        /// Id of the datasource of the base snapshot recovery point.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = DateTimeFilterParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.BaseRecoveryPointDatasourceId)]
        [Parameter(Mandatory = false, ParameterSetName = NoFilterParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.BaseRecoveryPointDatasourceId)]
        [ValidateNotNullOrEmpty]
        public string BaseRecoveryPointDatasourceId { get; set; }

        /// <summary>
        /// Restore point query type to filter the recovery points to fetch (SQL/MSSQL items).
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = DateTimeFilterParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.RestorePointQueryType)]
        [Parameter(Mandatory = false, ParameterSetName = NoFilterParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.RestorePointQueryType)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Full", "Log", "Differential", "FullAndDifferential", "All", "Incremental", "SnapshotFull", "SnapshotCopyOnlyFull", "Snapshot", "FullDifferentialAndSnapshot")]
        public string RestorePointQueryType { get; set; }

        /// <summary>
        /// Recovery mode to filter the recovery points (e.g. SnapshotAttachAndRecover) for SQL (MSSQL) items.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = DateTimeFilterParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.RecoveryMode)]
        [Parameter(Mandatory = false, ParameterSetName = NoFilterParameterSet, HelpMessage = ParamHelpMsgs.RecoveryPoint.RecoveryMode)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("SnapshotAttachAndRecover", "SnapshotAttach", "RecoveryUsingSnapshot")]
        public string RecoveryMode { get; set; }

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
                providerParameters.Add(RecoveryPointParams.TargetTier, TargetTier);
                providerParameters.Add(RecoveryPointParams.IsReadyForMove, IsReadyForMove);
                providerParameters.Add(RecoveryPointParams.Tier, Tier);

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
                    providerParameters.Add(RecoveryPointParams.GetLatestRPOnly, GetLatestRecoveryPointOnly.IsPresent);
                    if (!string.IsNullOrEmpty(BaseSnapshotRecoveryPointId))
                    {
                        providerParameters.Add(RecoveryPointParams.BaseSnapshotRPId, BaseSnapshotRecoveryPointId);
                    }
                    if (!string.IsNullOrEmpty(BaseRecoveryPointDatasourceId))
                    {
                        providerParameters.Add(RecoveryPointParams.BaseRPDatasourceId, BaseRecoveryPointDatasourceId);
                    }
                    if (!string.IsNullOrEmpty(RecoveryMode))
                    {
                        providerParameters.Add(RecoveryPointParams.RecoveryMode, RecoveryMode);
                    }
                    if (string.Compare(Item.BackupManagementType.ToString(),
                        BackupManagementType.AzureWorkload.ToString()) == 0)
                    {
                        string workloadQueryType = !string.IsNullOrEmpty(RestorePointQueryType) ?
                            RestorePointQueryType : "FullAndDifferential";
                        providerParameters.Add(RecoveryPointParams.RestorePointQueryType, workloadQueryType);
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
