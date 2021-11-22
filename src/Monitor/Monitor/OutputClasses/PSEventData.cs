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
        /// Gets or sets the Level of the event
        /// </summary>
        public new EventLevel Level { get; set; }

        /// <summary>
        /// Gets or sets the SubmissionTimestamp of the event
        /// </summary>
        public new DateTime SubmissionTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the EventTimestamp of the event
        /// </summary>
        public new DateTime EventTimestamp { get; set; }

        /// <summary>
        /// Hide EventName property in base class for output
        /// </summary>
        public new string EventName { get; set; }

        /// <summary>
        /// Hide Category property in base class for output
        /// </summary>
        public new string Category { get; set; }

        /// <summary>
        /// Hide ResourceProviderName property in base class for output
        /// </summary>
        public new string ResourceProviderName { get; set; }

        /// <summary>
        /// Hide OperationName property in base class for output
        /// </summary>
        public new string OperationName { get; set; }

        /// <summary>
        /// Hide Status property in base class for output
        /// </summary>
        public new string Status { get; set; }

        /// <summary>
        /// Hide SubStatus property in base class for output
        /// </summary>
        public new string SubStatus { get; set; }

        /// <summary>
        /// Initializes a new instance of the EventData class.
        /// </summary>
        public PSEventData(EventData eventData)
            : base(caller: eventData?.Caller, correlationId: eventData?.CorrelationId, description: eventData?.Description, eventDataId: eventData?.EventDataId,
                  eventName: eventData?.EventName, category: eventData?.Category, eventTimestamp: eventData?.EventTimestamp,
                  id: eventData?.Id, level: eventData?.Level, operationId: eventData?.OperationId, operationName: eventData?.OperationName,
                  resourceGroupName: eventData?.ResourceGroupName, resourceProviderName: eventData?.ResourceProviderName, resourceId: eventData?.ResourceId,
                  status: eventData?.Status, submissionTimestamp: eventData?.SubmissionTimestamp, subscriptionId: eventData?.SubscriptionId, subStatus: eventData?.SubStatus)
        {
            if (eventData != null)
            {
                this.Authorization = eventData.Authorization != null
                    ? new PSEventDataAuthorization
                    {
                        Action = eventData.Authorization.Action,
                        Role = eventData.Authorization.Role,
                        Scope = eventData.Authorization.Scope
                    }
                    : null;

                this.Claims = new PSDictionaryElement(eventData.Claims);

                this.HttpRequest = eventData.HttpRequest != null
                    ? new PSEventDataHttpRequest
                    {
                        ClientId = eventData.HttpRequest.ClientRequestId,
                        ClientIpAddress = eventData.HttpRequest.ClientIpAddress,
                        Method = eventData.HttpRequest.Method,
                        Url = eventData.HttpRequest.Uri
                    }
                    : null;
                this.Properties = new PSDictionaryElement(eventData.Properties);
                this.Level = eventData.Level ?? default(EventLevel);
                this.SubmissionTimestamp = eventData.SubmissionTimestamp ?? default(DateTime);
                this.EventTimestamp = eventData.EventTimestamp ?? default(DateTime);

                // Copy values for LocalizableStrings from the EventData object
                this.EventName = eventData.EventName?.LocalizedValue;
                this.Category = eventData.Category?.LocalizedValue;
                this.ResourceProviderName = eventData.ResourceProviderName?.LocalizedValue;
                this.OperationName = eventData.OperationName?.LocalizedValue;
                this.Status = eventData.Status?.LocalizedValue;
                this.SubStatus = eventData.SubStatus?.LocalizedValue;
            }
        }
    }
}
