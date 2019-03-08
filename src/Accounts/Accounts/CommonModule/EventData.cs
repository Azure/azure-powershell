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
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;


namespace Microsoft.Azure.Commands.Common
{
    using EventListenerDelegate = Func<EventData, Task>;
    using GetParameterDelegate = Func<string, System.Management.Automation.InvocationInfo, string, object>;
    using SendAsyncStep = Func<HttpRequestMessage, IEventListener, ISendAsync, Task<HttpResponseMessage>>;
    using PipelineChangeDelegate = Action<EventData>;

    [TypeConverter(typeof(EventDataConverter))]
    ///	<remarks>
    /// In PowerShell, we add on the EventDataConverter to support sending events between modules.
    /// Obviously, this code would need to be duplcated on both modules.
    /// This is preferable to sharing a common library, as versioning makes that problematic.
    /// </remarks>
    public partial class EventData : EventArgs
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
        /// Any extended data for an event should be serialized to JSON and stored here.
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