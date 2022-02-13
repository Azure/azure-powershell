/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime
{

    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using GetEventData = System.Func<EventData>;
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    public interface IValidates
    {
        Task Validate(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IEventListener listener);
    }

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

    internal static partial class Extensions
    {
        public static Task Signal(this IEventListener instance, string id, CancellationToken token, Func<EventData> createMessage) => instance.Signal(id, token, createMessage);
        public static Task Signal(this IEventListener instance, string id, CancellationToken token) => instance.Signal(id, token, () => new EventData { Id = id, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, CancellationToken token, string messageText) => instance.Signal(id, token, () => new EventData { Id = id, Message = messageText, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, CancellationToken token, string messageText, HttpRequestMessage request) => instance.Signal(id, token, () => new EventData { Id = id, Message = messageText, RequestMessage = request, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, CancellationToken token, string messageText, HttpResponseMessage response) => instance.Signal(id, token, () => new EventData { Id = id, Message = messageText, RequestMessage = response.RequestMessage, ResponseMessage = response, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, CancellationToken token, string messageText, double magnitude) => instance.Signal(id, token, () => new EventData { Id = id, Message = messageText, Value = magnitude, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, CancellationToken token, string messageText, double magnitude, HttpRequestMessage request) => instance.Signal(id, token, () => new EventData { Id = id, Message = messageText, RequestMessage = request, Value = magnitude, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, CancellationToken token, string messageText, double magnitude, HttpResponseMessage response) => instance.Signal(id, token, () => new EventData { Id = id, Message = messageText, RequestMessage = response.RequestMessage, ResponseMessage = response, Value = magnitude, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, CancellationToken token, HttpRequestMessage request) => instance.Signal(id, token, () => new EventData { Id = id, RequestMessage = request, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, CancellationToken token, HttpRequestMessage request, HttpResponseMessage response) => instance.Signal(id, token, () => new EventData { Id = id, RequestMessage = request, ResponseMessage = response, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, CancellationToken token, HttpResponseMessage response) => instance.Signal(id, token, () => new EventData { Id = id, RequestMessage = response.RequestMessage, ResponseMessage = response, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, CancellationToken token, EventData message) => instance.Signal(id, token, () => { message.Id = id; message.Cancel = instance.Cancel; return message; });

        public static Task Signal(this IEventListener instance, string id, Func<EventData> createMessage) => instance.Signal(id, instance.Token, createMessage);
        public static Task Signal(this IEventListener instance, string id) => instance.Signal(id, instance.Token, () => new EventData { Id = id, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, string messageText) => instance.Signal(id, instance.Token, () => new EventData { Id = id, Message = messageText, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, string messageText, HttpRequestMessage request) => instance.Signal(id, instance.Token, () => new EventData { Id = id, Message = messageText, RequestMessage = request, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, string messageText, HttpResponseMessage response) => instance.Signal(id, instance.Token, () => new EventData { Id = id, Message = messageText, RequestMessage = response.RequestMessage, ResponseMessage = response, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, string messageText, double magnitude) => instance.Signal(id, instance.Token, () => new EventData { Id = id, Message = messageText, Value = magnitude, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, string messageText, double magnitude, HttpRequestMessage request) => instance.Signal(id, instance.Token, () => new EventData { Id = id, Message = messageText, RequestMessage = request, Value = magnitude, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, string messageText, double magnitude, HttpResponseMessage response) => instance.Signal(id, instance.Token, () => new EventData { Id = id, Message = messageText, RequestMessage = response.RequestMessage, ResponseMessage = response, Value = magnitude, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, HttpRequestMessage request) => instance.Signal(id, instance.Token, () => new EventData { Id = id, RequestMessage = request, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, HttpRequestMessage request, HttpResponseMessage response) => instance.Signal(id, instance.Token, () => new EventData { Id = id, RequestMessage = request, ResponseMessage = response, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, HttpResponseMessage response) => instance.Signal(id, instance.Token, () => new EventData { Id = id, RequestMessage = response.RequestMessage, ResponseMessage = response, Cancel = instance.Cancel });
        public static Task Signal(this IEventListener instance, string id, EventData message) => instance.Signal(id, instance.Token, () => { message.Id = id; message.Cancel = instance.Cancel; return message; });

        public static Task Signal(this IEventListener instance, string id, System.Uri uri) => instance.Signal(id, instance.Token, () => new EventData { Id = id, Message = uri.ToString(), Cancel = instance.Cancel });

        public static async Task AssertNotNull(this IEventListener instance, string parameterName, object value)
        {
            if (value == null)
            {
                await instance.Signal(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, instance.Token, () => new EventData { Id = Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, Message = $"'{parameterName}' should not be null", Parameter = parameterName, Cancel = instance.Cancel });
            }
        }
        public static async Task AssertMinimumLength(this IEventListener instance, string parameterName, string value, int length)
        {
            if (value != null && value.Length < length)
            {
                await instance.Signal(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, instance.Token, () => new EventData { Id = Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, Message = $"Length of '{parameterName}' is less than {length}", Parameter = parameterName, Cancel = instance.Cancel });
            }
        }
        public static async Task AssertMaximumLength(this IEventListener instance, string parameterName, string value, int length)
        {
            if (value != null && value.Length > length)
            {
                await instance.Signal(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, instance.Token, () => new EventData { Id = Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, Message = $"Length of '{parameterName}' is greater than {length}", Parameter = parameterName, Cancel = instance.Cancel });
            }
        }

        public static async Task AssertRegEx(this IEventListener instance, string parameterName, string value, string regularExpression)
        {
            if (value != null && !System.Text.RegularExpressions.Regex.Match(value, regularExpression).Success)
            {
                await instance.Signal(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, instance.Token, () => new EventData { Id = Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, Message = $"'{parameterName}' does not validate against pattern /{regularExpression}/", Parameter = parameterName, Cancel = instance.Cancel });
            }
        }
        public static async Task AssertEnum(this IEventListener instance, string parameterName, string value, params string[] values)
        {
            if (!values.Any(each => each.Equals(value)))
            {
                await instance.Signal(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, instance.Token, () => new EventData { Id = Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, Message = $"'{parameterName}' is not one of ({values.Aggregate((c, e) => $"'{e}',{c}")}", Parameter = parameterName, Cancel = instance.Cancel });
            }
        }
        public static async Task AssertObjectIsValid(this IEventListener instance, string parameterName, object inst)
        {
            await (inst as Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IValidates)?.Validate(instance);
        }

        public static async Task AssertIsLessThan<T>(this IEventListener instance, string parameterName, T? value, T max) where T : struct, System.IComparable<T>
        {
            if (null != value && ((T)value).CompareTo(max) >= 0)
            {
                await instance.Signal(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, instance.Token, () => new EventData { Id = Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, Message = $"Value of '{parameterName}' must be less than {max} (value is {value})", Parameter = parameterName, Cancel = instance.Cancel });
            }
        }
        public static async Task AssertIsGreaterThan<T>(this IEventListener instance, string parameterName, T? value, T max) where T : struct, System.IComparable<T>
        {
            if (null != value && ((T)value).CompareTo(max) <= 0)
            {
                await instance.Signal(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, instance.Token, () => new EventData { Id = Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, Message = $"Value of '{parameterName}' must be greater than {max} (value is {value})", Parameter = parameterName, Cancel = instance.Cancel });
            }
        }
        public static async Task AssertIsLessThanOrEqual<T>(this IEventListener instance, string parameterName, T? value, T max) where T : struct, System.IComparable<T>
        {
            if (null != value && ((T)value).CompareTo(max) > 0)
            {
                await instance.Signal(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, instance.Token, () => new EventData { Id = Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, Message = $"Value of '{parameterName}' must be less than or equal to {max} (value is {value})", Parameter = parameterName, Cancel = instance.Cancel });
            }
        }
        public static async Task AssertIsGreaterThanOrEqual<T>(this IEventListener instance, string parameterName, T? value, T max) where T : struct, System.IComparable<T>
        {
            if (null != value && ((T)value).CompareTo(max) < 0)
            {
                await instance.Signal(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, instance.Token, () => new EventData { Id = Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, Message = $"Value of '{parameterName}' must be greater than or equal to {max} (value is {value})", Parameter = parameterName, Cancel = instance.Cancel });
            }
        }
        public static async Task AssertIsMultipleOf(this IEventListener instance, string parameterName, Int64? value, Int64 multiple)
        {
            if (null != value && value % multiple != 0)
            {
                await instance.Signal(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, instance.Token, () => new EventData { Id = Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, Message = $"Value of '{parameterName}' must be multiple of {multiple} (value is {value})", Parameter = parameterName, Cancel = instance.Cancel });
            }
        }
        public static async Task AssertIsMultipleOf(this IEventListener instance, string parameterName, double? value, double multiple)
        {
            if (null != value)
            {
                var i = (Int64)(value / multiple);
                if (i != value / multiple)
                {
                    await instance.Signal(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, instance.Token, () => new EventData { Id = Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, Message = $"Value of '{parameterName}' must be multiple of {multiple} (value is {value})", Parameter = parameterName, Cancel = instance.Cancel });
                }
            }
        }
        public static async Task AssertIsMultipleOf(this IEventListener instance, string parameterName, decimal? value, decimal multiple)
        {
            if (null != value)
            {
                var i = (Int64)(value / multiple);
                if (i != value / multiple)
                {
                    await instance.Signal(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, instance.Token, () => new EventData { Id = Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Events.ValidationWarning, Message = $"Value of '{parameterName}' must be multiple of {multiple} (value is {value})", Parameter = parameterName, Cancel = instance.Cancel });
                }
            }
        }
    }

    /// <summary>
    /// An Implementation of the IEventListener that supports subscribing to events and dispatching them
    /// (used for manually using the lowlevel interface)
    /// </summary>
    public class EventListener : CancellationTokenSource, IEnumerable<KeyValuePair<string, Event>>, IEventListener
    {
        private Dictionary<string, Event> calls = new Dictionary<string, Event>();
        public IEnumerator<KeyValuePair<string, Event>> GetEnumerator() => calls.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => calls.GetEnumerator();
        public EventListener()
        {
        }

        public new Action Cancel => base.Cancel;
        private Event tracer;

        public EventListener(params (string name, Event callback)[] initializer)
        {
            foreach (var each in initializer)
            {
                Add(each.name, each.callback);
            }
        }

        public void Add(string name, SynchEvent callback)
        {
            Add(name, (message) => { callback(message); return Task.CompletedTask; });
        }

        public void Add(string name, Event callback)
        {
            if (callback != null)
            {
                if (string.IsNullOrEmpty(name))
                {
                    if (calls.ContainsKey(name))
                    {
                        tracer += callback;
                    }
                    else
                    {
                        tracer = callback;
                    }
                }
                else
                {
                    if (calls.ContainsKey(name))
                    {
                        calls[name ?? System.String.Empty] += callback;
                    }
                    else
                    {
                        calls[name ?? System.String.Empty] = callback;
                    }
                }
            }
        }


        public async Task Signal(string id, CancellationToken token, GetEventData createMessage)
        {
            using (NoSynchronizationContext)
            {
                if (!string.IsNullOrEmpty(id) && (calls.TryGetValue(id, out Event listener) || tracer != null))
                {
                    var message = createMessage();
                    message.Id = id;

                    await listener?.Invoke(message);
                    await tracer?.Invoke(message);

                    if (token.IsCancellationRequested)
                    {
                        throw new OperationCanceledException($"Canceled by event {id} ", this.Token);
                    }
                }
            }
        }
    }
}