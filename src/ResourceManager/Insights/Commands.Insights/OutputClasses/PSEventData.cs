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
    /// Wrapps around the EventData and exposes all the localized strings as invariant/localized properties
    /// </summary>
    public class PSEventData : IPSEventData
    {
        /// <summary>
        /// Gets or sets the authorization. This is the authorization used by the user who has performed the operation that led to this event.
        /// </summary>
        public PSEventDataAuthorization Authorization { get; set; }

        /// <summary>
        /// Gets or sets the caller
        /// </summary>
        public string Caller { get; set; }

        /// <summary>
        /// Gets or sets the claims
        /// </summary>
        public PSDictionaryElement Claims { get; set; }

        /// <summary>
        /// Gets or sets the correlation Id. The correlation Id is shared among the events that belong to the same deployment.
        /// </summary>
        public string CorrelationId { get; set; }

        /// <summary>
        /// Gets or sets the description of the event.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the event channels. The regular event logs, that you see in the Azure Management Portals, flow through the 'Operation' channel.
        /// </summary>
        public EventChannels EventChannels { get; set; }

        /// <summary>
        /// Gets or sets the event data Id. This is a unique identifier for an event.
        /// </summary>
        public string EventDataId { get; set; }

        /// <summary>
        /// Gets or sets the event name. This value should not be confused with OperationName.For practical purposes, OperationName might be more appealing to end users.
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the occurrence time of event
        /// </summary>
        public DateTime EventTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the HTTP request info. The client IP address of the user who initiated the event is captured as part of the HTTP request info.
        /// </summary>
        public PSEventDataHttpRequest HttpRequest { get; set; }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the event level
        /// </summary>
        public EventLevel Level { get; set; }

        /// <summary>
        /// Gets or sets the operation id. This value should not be confused with EventName.
        /// </summary>
        public string OperationId { get; set; }

        /// <summary>
        /// Gets or sets the operation name.
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// Gets or sets the property bag
        /// </summary>
        public PSDictionaryElement Properties { get; set; }

        /// <summary>
        /// Gets or sets the resource group name. (see http://msdn.microsoft.com/en-us/library/azure/dn790546.aspx for more information)
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the resource provider name. (see http://msdn.microsoft.com/en-us/library/azure/dn790572.aspx for more information)
        /// </summary>
        public string ResourceProviderName { get; set; }

        /// <summary>
        /// Gets or sets the resource Id (see http://msdn.microsoft.com/en-us/library/azure/dn790569.aspx for more information)
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the event status. Some typical values are: Started, Succeeded, Failed
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the event submission time. This value should not be confused eventTimestamp. As there might be a delay between
        /// the occurence time of the event, and the time that the event is submitted to the Azure logging infrastructure.
        /// </summary>
        public DateTime SubmissionTimestamp { get; set; }

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
        public PSEventData(EventData eventData)
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
            this.Claims = new PSDictionaryElement(eventData.Claims);
            this.CorrelationId = eventData.CorrelationId;
            this.Description = eventData.Description;
            this.EventChannels = eventData.EventChannels;
            this.EventDataId = eventData.EventDataId;
            this.EventName = eventData.EventName.Value;
            this.Category = eventData.Category.Value;
            this.EventTimestamp = eventData.EventTimestamp;
            this.HttpRequest = eventData.HttpRequest != null
                ? new PSEventDataHttpRequest
                {
                    ClientId = eventData.HttpRequest.ClientRequestId,
                    ClientIpAddress = eventData.HttpRequest.ClientIpAddress,
                    Method = eventData.HttpRequest.Method,
                    Url = eventData.HttpRequest.Uri
                }
                : null;
            this.Id = eventData.Id;
            this.Level = eventData.Level;
            this.OperationId = eventData.OperationId;
            this.OperationName = eventData.OperationName.Value;
            this.Properties = new PSDictionaryElement(eventData.Properties);
            this.ResourceGroupName = eventData.ResourceGroupName;
            this.ResourceProviderName = eventData.ResourceProviderName.Value;
            this.ResourceId = eventData.ResourceId;
            this.Status = eventData.Status.Value;
            this.SubmissionTimestamp = eventData.SubmissionTimestamp;
            this.SubscriptionId = eventData.SubscriptionId;
            this.SubStatus = eventData.SubStatus.Value;
        }
    }
}
