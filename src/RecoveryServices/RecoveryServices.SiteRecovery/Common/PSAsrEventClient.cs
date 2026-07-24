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

using System.Collections.Generic;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Microsoft.Rest.Azure.OData;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        ///     Gets the events.
        /// </summary>
        /// <param name="eventName">The name of the Azure Site Recovery event.</param>
        /// <returns></returns>
        public EventModel GetAzureRmSiteRecoveryEvent(string eventName)
        {
            return this.GetSiteRecoveryClient()
                .ReplicationEvents
                .GetWithHttpMessagesAsync(
                 asrVaultCreds.ResourceGroupName,
                 asrVaultCreds.ResourceName,
                 eventName, this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }

        /// <summary>
        ///     Gets all the Events with Event Query Params.
        /// </summary>
        /// <param name="parameters">Event Query parameters.</param>
        /// <returns>Events list response.</returns>
        public List<EventModel> ListAzureRmSiteRecoveryEvents(EventQueryParameter parameters)
        {
            var filter = parameters.ToQueryString();
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationEvents
                .ListWithHttpMessagesAsync(
                 asrVaultCreds.ResourceGroupName,
                 asrVaultCreds.ResourceName,
                 filter, this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;

            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient().ReplicationEvents.ListNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));

            pages.Insert(0, firstPage);

            return Utilities.IpageToList(pages);
        }
    }

    /// <summary>
    /// Implements the event query parameter used to build the OData $filter string for the
    /// replication events list operation. Replaces the generated SDK type that was removed when
    /// the 2026-02-01 API dropped the x-ms-odata annotation on the list operation (the $filter is
    /// now passed as a plain string). The property names are used by ToQueryString() to build the
    /// filter, so they must match the original schema property names.
    /// </summary>
    public class EventQueryParameter
    {
        /// <summary>Gets or sets the source id of the events to be queried.</summary>
        public string EventCode { get; set; }

        /// <summary>Gets or sets the severity of the events to be queried.</summary>
        public string Severity { get; set; }

        /// <summary>Gets or sets the type of the events to be queried.</summary>
        public string EventType { get; set; }

        /// <summary>Gets or sets the affected object server id of the events to be queried.</summary>
        public string FabricName { get; set; }

        /// <summary>Gets or sets the affected object name of the events to be queried.</summary>
        public string AffectedObjectFriendlyName { get; set; }

        /// <summary>Gets or sets the affected object correlationId for the events to be queried.</summary>
        public string AffectedObjectCorrelationId { get; set; }

        /// <summary>Gets or sets the start time of the range within which the events are queried.</summary>
        public System.DateTime? StartTime { get; set; }

        /// <summary>Gets or sets the end time of the range within which the events are queried.</summary>
        public System.DateTime? EndTime { get; set; }
    }
}
