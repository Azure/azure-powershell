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
        /// <param name="eventName"></param>
        /// <returns></returns>
        public EventModel GetAzureRmSiteRecoveryEvent(string eventName)
        {
            return this.GetSiteRecoveryClient()
                .ReplicationEvents
                .GetWithHttpMessagesAsync(eventName, this.GetRequestHeaders(true))
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
            var odataQuery = new ODataQuery<EventQueryParameter>(parameters.ToQueryString());
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationEvents
                .ListWithHttpMessagesAsync(odataQuery, this.GetRequestHeaders(true))
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
}
