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
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupRecoveryLogChain", DefaultParameterSetName = NoFilterParameterSet), OutputType(typeof(PointInTimeBase))]
    public class GetAzureRmRecoveryServicesBackupRecoveryLogChain : RSBackupVaultCmdletBase
    {
        internal const string DateTimeFilterParameterSet = "DateTimeFilter";
        internal const string NoFilterParameterSet = "NoFilterParameterSet";

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
            ParameterSetName = NoFilterParameterSet,
            ValueFromPipeline = true,
            Position = 0,
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
                    providerParameters.Add(RecoveryPointParams.RestorePointQueryType, "Log");

                    PsBackupProviderManager providerManager =
                        new PsBackupProviderManager(providerParameters, ServiceClientAdapter);
                    IPsBackupProvider psBackupProvider =
                        providerManager.GetProviderInstance(Item.ContainerType, Item.BackupManagementType);
                    var rpList = psBackupProvider.GetLogChains();

                    WriteObject(rpList, enumerateCollection: true);
                }
                else
                {
                    throw new Exception(Resources.RecoveryPointUnsupportedParamet);
                }
            });
        }
    }
}
