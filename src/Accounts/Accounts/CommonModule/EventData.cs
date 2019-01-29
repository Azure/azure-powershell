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
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GetEventData = System.Func<Microsoft.Azure.Commands.Common.EventData>;


namespace Microsoft.Azure.Commands.Common
{


    using EventListenerDelegate = Func<EventData, Task>;
    using GetParameterDelegate = Func<string, Dictionary<string, object>, string, object>;
    using SendAsyncStep = Func<HttpRequestMessage, IEventListener, ISendAsync, Task<HttpResponseMessage>>;
    using PipelineChangeDelegate = Action<EventData>;

    /// <summary>
    /// The IEventListener Interface defines the communication mechanism for Signaling events during a remote call.
    /// </summary>
    /// <remarks>
    /// The interface is designed to be as minimal as possible, allow for quick peeking of the event type (<c>id</c>) 
    /// and the cancellation status and provides a delegate for retrieving the event details themselves.
    /// </remarks>
    public interface IEventListener
    {
        Task Signal(string id, CancellationToken token, GetEventData createMessage);
        CancellationToken Token { get; }
        System.Action Cancel { get; }
    }

    public class Response : EventData
    {
        public Response() : base()
        {
        }
    }

    public class Response<T> : Response
    {
        private Func<Task<T>> _resultDelegate;
        private Task<T> _resultValue;

        public Response(T value) : base() => _resultValue = Task.FromResult(value);
        public Response(Func<T> value) : base() => _resultDelegate = () => Task.FromResult(value());
        public Response(Func<Task<T>> value) : base() => _resultDelegate = value;
        public Task<T> Result => _resultValue ?? (_resultValue = this._resultDelegate());
    }


    /// <summary>
    /// The interface for sending an HTTP request across the wire.
    /// </summary>
    public interface ISendAsync
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, IEventListener callback);
    }



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

    /// <summary>
    /// A PowerShell PSTypeConverter to adapt an <c>EventData</c> object that has been passed.
    /// Usually used between modules.
    /// </summary>
    public class EventDataConverter : System.Management.Automation.PSTypeConverter
    {
        public override bool CanConvertTo(object sourceValue, Type destinationType) => false;
        public override object ConvertTo(object sourceValue, Type destinationType, IFormatProvider formatProvider, bool ignoreCase) => null;
        public override bool CanConvertFrom(dynamic sourceValue, Type destinationType) => destinationType == typeof(EventData) && CanConvertFrom(sourceValue);
        public override object ConvertFrom(dynamic sourceValue, Type destinationType, IFormatProvider formatProvider, bool ignoreCase) => ConvertFrom(sourceValue);

        public static bool CanConvertFrom(dynamic sv)
        {
            var result = true;
            try
            {
                // check if this has required parameters...
                sv?.Id?.GetType();
                sv?.Message?.GetType();
                sv?.Parameter?.GetType();
                sv?.Value?.GetType();
                sv?.RequestMessage?.GetType();
                sv?.ResponseMessage?.GetType();
                sv?.Cancel?.GetType();
            }
            catch
            {
                return false;
            }
            return result;
        }

        public static EventData ConvertFrom(dynamic sv)
        {
            try
            {
                return new EventData
                {
                    Id = sv.Id,
                    Message = sv.Message,
                    Parameter = sv.Parameter,
                    Value = sv.Value,
                    RequestMessage = sv.RequestMessage,
                    ResponseMessage = sv.ResponseMessage,
                    Cancel = sv.Cancel
                };
            }
            catch
            {
            }
            return null;
        }
    }
    public static class Events
    {
        public const string Log = nameof(Log);
        public const string Validation = nameof(Validation);
        public const string ValidationWarning = nameof(ValidationWarning);
        public const string AfterValidation = nameof(AfterValidation);
        public const string RequestCreated = nameof(RequestCreated);
        public const string ResponseCreated = nameof(ResponseCreated);
        public const string URLCreated = nameof(URLCreated);
        public const string Finally = nameof(Finally);
        public const string HeaderParametersAdded = nameof( HeaderParametersAdded);
        public const string BodyContentSet = nameof( BodyContentSet);
        public const string BeforeCall = nameof( BeforeCall);
        public const string BeforeResponseDispatch = nameof( BeforeResponseDispatch);
        public const string CmdletProcessRecordStart = nameof(CmdletProcessRecordStart);
        public const string CmdletException = nameof(CmdletException);
        public const string CmdletGetPipeline = nameof(CmdletGetPipeline);
        public const string CmdletBeforeAPICall = nameof(CmdletBeforeAPICall);
        public const string CmdletAfterAPICall =  nameof(CmdletAfterAPICall);
        public const string FollowingNextLink = nameof(FollowingNextLink);
        public const string DelayBeforePolling = nameof(DelayBeforePolling);
        public const string Polling = nameof(Polling);
    }

}