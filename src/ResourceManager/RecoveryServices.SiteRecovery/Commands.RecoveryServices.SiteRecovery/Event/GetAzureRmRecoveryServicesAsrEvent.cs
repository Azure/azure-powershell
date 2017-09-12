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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Retrieves Azure Site Recovery alert and nofification settings.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        "AzureRmRecoveryServicesAsrEvent",
        DefaultParameterSetName = ASRParameterSets.ByParam)]
    [Alias("Get-ASREvent")]
    [OutputType(typeof(IEnumerable<ASREvent>))]
    public class GetAzureRmRecoveryServicesAsrEvents : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets Event name.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName)]
        public string EventName { get; set; }

        /// <summary>
        ///     Gets or sets server name.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByParam)]
        [ValidateNotNullOrEmpty]
        public string AffectedObjectFriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets the Endtime.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByParam)]
        [ValidateNotNullOrEmpty]
        public DateTime EndTime { get; set; }

        /// <summary>
        ///     Gets or sets the fabric.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByParam)]
        [ValidateNotNullOrEmpty]
        public ASRFabric Fabric { get; set; }

        /// <summary>
        ///     Gets or sets the Severity.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByParam)]
        [ValidateSet(
            ASRHealthEventServerity.Critical,
            ASRHealthEventServerity.Warning,
            ASRHealthEventServerity.OK,
            ASRHealthEventServerity.Unknown)]
        public string Severity { get; set; }

        /// <summary>
        ///     Gets or sets the Start time.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByParam)]
        [ValidateNotNullOrEmpty]
        public DateTime StartTime { get; set; }

        /// <summary>
        ///     Gets or sets switch parameter. On passing, command waits till completion.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByParam)]
        [ValidateSet(
            Constants.VmHealth,
            Constants.ServerHealth,
            Constants.AgentHealth)]
        public string EventType { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByName:
                    this.GetByName();
                    break;
                default:
                    this.GetEvents();
                    break;
            }
        }

        /// <summary>
        ///     Gets the Event by Name.
        /// </summary>
        private void GetByName()
        {
            var eventsResponse =
                this.RecoveryServicesClient.GetAzureRmSiteRecoveryEvent(this.EventName);
            this.WriteEvent(eventsResponse);
        }

        /// <summary>
        ///     Gets the alert and notification settings.
        /// </summary>
        private void GetEvents()
        {
            var parameters = new EventQueryParameter();

            if (!string.IsNullOrEmpty(this.EventType))
            {
                parameters.EventType = this.EventType;
            }

            if (!string.IsNullOrEmpty(this.Severity))
            {
                parameters.Severity = this.Severity;
            }

            if (this.Fabric != null)
            {
                parameters.FabricName = this.Fabric.Name;
            }

            if (!string.IsNullOrEmpty(this.AffectedObjectFriendlyName))
            {
                parameters.AffectedObjectFriendlyName = this.AffectedObjectFriendlyName;
            }

            if (this.StartTime != DateTime.MinValue)
            {
                parameters.StartTime = this.StartTime;
            }

            if (this.EndTime != DateTime.MinValue)
            {
                parameters.EndTime = this.EndTime;
            }

            var eventsResponse =
                this.RecoveryServicesClient.ListAzureRmSiteRecoveryEvents(parameters);

            this.WriteEvent(eventsResponse);
        }

        /// <summary>
        ///     Writes Job.
        /// </summary>
        /// <param name="job">JOB object</param>
        private void WriteEvent(
            EventModel asrEvent)
        {
            this.WriteObject(new ASREvent(asrEvent));
        }

        /// <summary>
        ///     Write events.
        /// </summary>
        /// <param name="asrEvent">List of events.</param>
        private void WriteEvent(List<EventModel> asrEvent)
        {
            this.WriteObject(asrEvent.Select(p => new ASREvent(p)), true);
        }
    }
}