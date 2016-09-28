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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Gets recovery points created for the provided item protected by the recovery services vault
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmRecoveryServicesBackupRecoveryPoint",
        DefaultParameterSetName = NoFilterParameterSet),
        OutputType(typeof(RecoveryPointBase), typeof(IList<RecoveryPointBase>))]
    public class GetAzureRmRecoveryServicesBackupRecoveryPoint : RecoveryServicesBackupCmdletBase
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

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                //Validate start time < end time
                base.ExecuteCmdlet();

                // initialize values to default
                DateTime rangeEnd = DateTime.UtcNow;
                DateTime rangeStart = rangeEnd.AddDays(-30);
                
                Dictionary<System.Enum, object> parameter = new Dictionary<System.Enum, object>();
                parameter.Add(RecoveryPointParams.Item, Item);

                if (this.ParameterSetName == DateTimeFilterParameterSet ||
                    this.ParameterSetName == NoFilterParameterSet)
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
                    WriteDebug(String.Format("ParameterSet = DateTimeFilterParameterSet. \n" +
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

                    parameter.Add(RecoveryPointParams.StartDate, rangeStart);
                    parameter.Add(RecoveryPointParams.EndDate, rangeEnd);
                    PsBackupProviderManager providerManager = 
                        new PsBackupProviderManager(parameter, ServiceClientAdapter);
                    IPsBackupProvider psBackupProvider = 
                        providerManager.GetProviderInstance(Item.ContainerType, Item.BackupManagementType);
                    var rpList = psBackupProvider.ListRecoveryPoints();

                    WriteDebug(String.Format("RPCount in Response = {0}", rpList.Count));
                    WriteObject(rpList, enumerateCollection: true);
                }
                else if (this.ParameterSetName == RecoveryPointIdParameterSet)
                {
                    //User want details of a particular recovery point
                    WriteDebug(String.Format("ParameterSet = DateTimeFilterParameterSet. \n" +
                        "StartDate = {0} EndDate = {1}, RPId = {2}, KeyFileDownloadLocation = {3}",
                        StartDate, EndDate, RecoveryPointId, KeyFileDownloadLocation));

                    parameter.Add(RecoveryPointParams.RecoveryPointId, RecoveryPointId);
                    parameter.Add(
                        RecoveryPointParams.KeyFileDownloadLocation, KeyFileDownloadLocation);
                    PsBackupProviderManager providerManager = 
                        new PsBackupProviderManager(parameter, ServiceClientAdapter);
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
