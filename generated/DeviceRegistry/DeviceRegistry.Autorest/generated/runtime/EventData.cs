/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime
{

    using System;
    using System.Threading;

    ///<summary>Represents the data in signaled event.</summary>
    public partial class EventData
    {
        /// <summary>
        /// The type of the event being signaled
        /// </summary>
        public string Id;

        /// <summary>
        /// The user-ready message from the event.
        /// </summary>
        public string Message;

        /// <summary>
        /// When the event is about a parameter, this is the parameter name.
        /// Used in Validation Events
        /// </summary>
        public string Parameter;

        /// <summary>
        /// This represents a numeric value associated with the event. 
        /// Use for progress-style events
        /// </summary>
        public double Value;

        /// <summary>
        /// Any extended data for an event should be serialized and stored here.
        /// </summary>
        public string ExtendedData;

        /// <summary>
        /// If the event triggers after the request message has been created, this will contain the Request Message (which in HTTP calls would be HttpRequestMessage)
        /// 
        /// Typically you'd cast this to the expected type to use it:
        /// <code>
        /// if(eventData.RequestMessgae is HttpRequestMessage httpRequest) 
        /// {
        ///   httpRequest.Headers.Add("x-request-flavor", "vanilla");
        /// }
        /// </code>
        /// </summary>
        public object RequestMessage;

        /// <summary>
        /// If the event triggers after the response is back, this will contain the Response Message (which in HTTP calls would be HttpResponseMessage)
        /// 
        /// Typically you'd cast this to the expected type to use it:
        /// <code>
        /// if(eventData.ResponseMessage is HttpResponseMessage httpResponse){
        ///   var flavor = httpResponse.Headers.GetValue("x-request-flavor");
        /// }
        /// </code>
        /// </summary>
        public object ResponseMessage;

        /// <summary>
        /// Cancellation method for this event. 
        /// 
        /// If the event consumer wishes to cancel the request that initiated this event, call <c>Cancel()</c>
        /// </summary>
        /// <remarks>
        /// The original initiator of the request must provide the implementation of this.
        /// </remarks>
        public System.Action Cancel;
    }

}