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

using Microsoft.Azure.Management.Monitor.Models;
using System;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the EventData and exposes all the localized strings as invariant/localized properties
    /// </summary>
    public class PSEventData : EventData
    {
        /// <summary>
        /// Gets or sets the authorization. This is the authorization used by the user who has performed the operation that led to this event.
        /// </summary>
        public new PSEventDataAuthorization Authorization { get; set; }

        /// <summary>
        /// Gets or sets the claims
        /// </summary>
        public new PSDictionaryElement Claims { get; set; }

        /// <summary>
        /// Gets or sets the HTTP request info. The client IP address of the user who initiated the event is captured as part of the HTTP request info.
        /// </summary>
        public new PSEventDataHttpRequest HttpRequest { get; set; }

        /// <summary>
        /// Gets or sets the property bag
        /// </summary>
        public new PSDictionaryElement Properties { get; set; }

        /// <summary>
        /// Initializes a new instance of the EventData class.
        /// </summary>
        public PSEventData(EventData eventData)
        {
            this.Authorization = eventData.Authorization != null
                ? new PSEventDataAuthorization
                {
                    Action = eventData.Authorization.Action,
                    Role = eventData.Authorization.Role,
                    Scope = eventData.Authorization.Scope
                }
                : null;
            this.Caller = eventData.Caller;
            this.Claims = new PSDictionaryElement(eventData.Claims);
            this.CorrelationId = eventData.CorrelationId;
            this.Description = eventData.Description;

            this.EventDataId = eventData.EventDataId;
            this.EventName = eventData.EventName;
            this.Category = eventData.Category;
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
            this.OperationName = eventData.OperationName;
            this.Properties = new PSDictionaryElement(eventData.Properties);
            this.ResourceGroupName = eventData.ResourceGroupName;
            this.ResourceProviderName = eventData.ResourceProviderName;
            this.ResourceId = eventData.ResourceId;
            this.Status = eventData.Status;
            this.SubmissionTimestamp = eventData.SubmissionTimestamp;
            this.SubscriptionId = eventData.SubscriptionId;
            this.SubStatus = eventData.SubStatus;
        }
    }
}
