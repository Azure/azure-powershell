/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime
{
    using System.Net.Http;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections;
    using System.Linq;

    using GetEventData = System.Func<EventData>;
    using NextDelegate = System.Func<System.Net.Http.HttpRequestMessage, System.Threading.CancellationToken, System.Action, System.Func<string, System.Threading.CancellationToken, System.Func<System.EventArgs>, System.Threading.Tasks.Task>, System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>;

    using SignalDelegate = System.Func<string, System.Threading.CancellationToken, System.Func<System.EventArgs>, System.Threading.Tasks.Task>;
    using GetParameterDelegate = System.Func<string, System.Collections.Generic.Dictionary<string,object>, string, object>;
    using SendAsyncStepDelegate  = System.Func<System.Net.Http.HttpRequestMessage, System.Threading.CancellationToken, System.Action, System.Func<string, System.Threading.CancellationToken, System.Func<System.EventArgs>, System.Threading.Tasks.Task>, System.Func<System.Net.Http.HttpRequestMessage, System.Threading.CancellationToken, System.Action, System.Func<string, System.Threading.CancellationToken, System.Func<System.EventArgs>, System.Threading.Tasks.Task>, System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>, System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>;
    using PipelineChangeDelegate = System.Action<System.Func<System.Net.Http.HttpRequestMessage, System.Threading.CancellationToken, System.Action, System.Func<string, System.Threading.CancellationToken, System.Func<System.EventArgs>, System.Threading.Tasks.Task>, System.Func<System.Net.Http.HttpRequestMessage, System.Threading.CancellationToken, System.Action, System.Func<string, System.Threading.CancellationToken, System.Func<System.EventArgs>, System.Threading.Tasks.Task>, System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>, System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>>;
    using ModuleLoadPipelineDelegate = System.Action<string, System.Action<System.Func<System.Net.Http.HttpRequestMessage, System.Threading.CancellationToken, System.Action, System.Func<string, System.Threading.CancellationToken, System.Func<System.EventArgs>, System.Threading.Tasks.Task>, System.Func<System.Net.Http.HttpRequestMessage, System.Threading.CancellationToken, System.Action, System.Func<string, System.Threading.CancellationToken, System.Func<System.EventArgs>, System.Threading.Tasks.Task>, System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>, System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>>, System.Action<System.Func<System.Net.Http.HttpRequestMessage, System.Threading.CancellationToken, System.Action, System.Func<string, System.Threading.CancellationToken, System.Func<System.EventArgs>, System.Threading.Tasks.Task>, System.Func<System.Net.Http.HttpRequestMessage, System.Threading.CancellationToken, System.Action, System.Func<string, System.Threading.CancellationToken, System.Func<System.EventArgs>, System.Threading.Tasks.Task>, System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>, System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>>>;
    using NewRequestPipelineDelegate = System.Action<System.Collections.Generic.Dictionary<string,object>, System.Action<System.Func<System.Net.Http.HttpRequestMessage, System.Threading.CancellationToken, System.Action, System.Func<string, System.Threading.CancellationToken, System.Func<System.EventArgs>, System.Threading.Tasks.Task>, System.Func<System.Net.Http.HttpRequestMessage, System.Threading.CancellationToken, System.Action, System.Func<string, System.Threading.CancellationToken, System.Func<System.EventArgs>, System.Threading.Tasks.Task>, System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>, System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>>, System.Action<System.Func<System.Net.Http.HttpRequestMessage, System.Threading.CancellationToken, System.Action, System.Func<string, System.Threading.CancellationToken, System.Func<System.EventArgs>, System.Threading.Tasks.Task>, System.Func<System.Net.Http.HttpRequestMessage, System.Threading.CancellationToken, System.Action, System.Func<string, System.Threading.CancellationToken, System.Func<System.EventArgs>, System.Threading.Tasks.Task>, System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>, System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage>>>>;

/*
    public class DelegateBasedEventListener : IEventListener
    {
        private EventListenerDelegate _listener;
        public DelegateBasedEventListener(EventListenerDelegate listener)
        {
            _listener = listener;
        }
        public CancellationToken Token => CancellationToken.None;
        public System.Action Cancel => () => { };


        public Task Signal(string id, CancellationToken token, GetEventData createMessage)
        {
            return _listener(id, token, () => createMessage());
        }
    }
*/
    /// <summary>
    /// This is a necessary extension to the SendAsyncFactory to support the 'generic' delegate format.
    /// </summary>
    public partial class SendAsyncFactory
    {
        /// <summary>
        /// This translates a generic-defined delegate for a listener into one that fits our ISendAsync pattern.
        /// (Provided to support out-of-module delegation for Azure Cmdlets)
        /// </summary>
        /// <param name="step">The Pipeline Step as a delegate</param>
        public SendAsyncFactory(SendAsyncStepDelegate step) => this.implementation = (request, listener, next) => 
            step(
                request,
                listener.Token, 
                listener.Cancel, 
                (id, token, getEventData) => listener.Signal(id, token, () => { 
                    var data = EventDataConverter.ConvertFrom( getEventData() ) as EventData;
                    data.Id = id;
                    data.Cancel = listener.Cancel;
                    data.RequestMessage = request;
                    return data;
                 }),
                (req, token, cancel, listenerDelegate) => next.SendAsync(req, listener));
    }

    public partial class HttpPipeline : ISendAsync
    {
        public HttpPipeline Append(SendAsyncStepDelegate item)
        {
            if (item != null)
            {
                Append(new SendAsyncFactory(item));
            }
            return this;
        }

        public HttpPipeline Prepend(SendAsyncStepDelegate item)
        {
            if (item != null)
            {
                Prepend(new SendAsyncFactory(item));
            }
            return this;
        }
    }
}
