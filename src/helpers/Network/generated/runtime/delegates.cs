
namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using GetEventData=System.Func<EventData>;

    public delegate Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, IEventListener callback);
    public delegate Task<HttpResponseMessage> SendAsyncStep(HttpRequestMessage request, IEventListener callback, ISendAsync next);
    public delegate Task SignalEvent(string id, CancellationToken token, GetEventData getEventData);
    public delegate Task Event(EventData message);
    public delegate void SynchEvent(EventData message);
    public delegate Task OnResponse(Response message);
    public delegate Task OnResponse<T>(Response<T> message);
}