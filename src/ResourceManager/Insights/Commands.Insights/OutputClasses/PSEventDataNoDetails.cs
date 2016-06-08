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

using Microsoft.Azure.Insights.Models;
using System;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the EventData and exposes all the localized strings as invariant/localized properties, but not all the details of the records
    /// </summary>
    public class PSEventDataNoDetails : IPSEventData
    {
        /// <summary>
        /// List of fields to be fetched when no details are needed
        /// </summary>
        public static string SelectedFieldsForQuery = "Authorization,Caller,CorrelationId,Category,EventTimestamp,OperationName,ResourceGroupName,ResourceUri,Status,SubscriptionId,SubStatus";

        /// <summary>
        /// Gets or sets the authorization. This is the authorization used by the user who has performed the operation that led to this event.
        /// </summary>
        public PSEventDataAuthorization Authorization { get; set; }

        /// <summary>
        /// Gets or sets the caller
        /// </summary>
        public string Caller { get; set; }

        /// <summary>
        /// Gets or sets the category Id.
        /// </summary>
        public string CorrelationId { get; set; }

        /// <summary>
        /// Gets or sets the event source. This value indicates the source that generated the event.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the occurrence time of event
        /// </summary>
        public DateTime EventTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the operation name.
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// Gets or sets the resource group name. (see http://msdn.microsoft.com/en-us/library/azure/dn790546.aspx for more information)
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the resource Id (see http://msdn.microsoft.com/en-us/library/azure/dn790569.aspx for more information)
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the event status. Some typical values are: Started, Succeeded, Failed
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the Azure subscription Id
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the event sub status. Most of the time, when included, this captures the HTTP status code.
        /// </summary>
        public string SubStatus { get; set; }

        /// <summary>
        /// Initializes a new instance of the EventData class.
        /// </summary>
        public PSEventDataNoDetails(EventData eventData)
        {
            this.Authorization = eventData.Authorization != null
                ? new PSEventDataAuthorization
                {
                    Action = eventData.Authorization.Action,
                    Condition = eventData.Authorization.Condition,
                    Role = eventData.Authorization.Role,
                    Scope = eventData.Authorization.Scope
                }
                : null;
            this.Caller = eventData.Caller;
            this.CorrelationId = eventData.CorrelationId;
            this.Category = eventData.Category.Value;
            this.EventTimestamp = eventData.EventTimestamp;
            this.OperationName = eventData.OperationName.Value;
            this.ResourceGroupName = eventData.ResourceGroupName;
            this.ResourceId = eventData.ResourceId;
            this.Status = eventData.Status.Value;
            this.SubscriptionId = eventData.SubscriptionId;
            this.SubStatus = eventData.SubStatus.Value;
        }
    }
}
