/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime
{
    using System.Linq;
    using System;

    internal static partial class Extensions
    {
        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            return new ArraySegment<T>(array, offset, length)
                        .ToArray();
        }

        public static T ReadHeaders<T>(this T instance, global::System.Net.Http.Headers.HttpResponseHeaders headers) where T : class
        {
            (instance as IHeaderSerializable)?.ReadHeaders(headers);
            return instance;
        }

        internal static bool If<T>(T input, out T output)
        {
            if (null == input)
            {
                output = default(T);
                return false;
            }
            output = input;
            return true;
        }

        internal static void AddIf<T>(T value, System.Action<T> addMethod)
        {
            // if value is present (and it's not just an empty JSON Object)
            if (null != value && (value as Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.Json.JsonObject)?.Keys.Count != 0)
            {
                addMethod(value);
            }
        }

        internal static void AddIf<T>(T value, string serializedName, System.Action<string, T> addMethod)
        {
            // if value is present (and it's not just an empty JSON Object)
            if (null != value && (value as Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.Json.JsonObject)?.Keys.Count != 0)
            {
                addMethod(serializedName, value);
            }
        }

        /// <summary>
        /// Returns the first header value as a string from an HttpReponseMessage. 
        /// </summary>
        /// <param name="response">the HttpResponseMessage to fetch a header from</param>
        /// <param name="headerName">the header name</param>
        /// <returns>the first header value as a string from an HttpReponseMessage. string.empty if there is no header value matching</returns>
        internal static string GetFirstHeader(this System.Net.Http.HttpResponseMessage response, string headerName) => response.Headers.FirstOrDefault(each => string.Equals(headerName, each.Key, System.StringComparison.OrdinalIgnoreCase)).Value?.FirstOrDefault() ?? string.Empty;

        /// <summary>
        /// Sets the Synchronization Context to null, and returns an IDisposable that when disposed, 
        /// will restore the synchonization context to the original value.
        /// 
        /// This is used a less-invasive means to ensure that code in the library that doesn't 
        /// need to be continued in the original context doesn't have to have <c>ConfigureAwait(false)</c> 
        /// on every single <c>await</c>
        /// 
        /// If the <c>SynchronizationContext</c> is <c>null</c> when this is used, the resulting IDisposable
        /// will not do anything (this prevents excessive re-setting of the <c>SynchronizationContext</c>)
        /// <example>
        /// Usage:
        /// <code>
        /// using(NoSynchronizationContext) {
        ///     await SomeAsyncOperation();
        ///     await SomeOtherOperation();
        /// }
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>An IDisposable that will return the SynchronizationContext to original state</returns>
        internal static System.IDisposable NoSynchronizationContext => System.Threading.SynchronizationContext.Current == null ? Dummy : new NoSyncContext();

        /// <summary>
        /// An instance of the Dummy IDispoable.
        /// </summary>
        /// <returns></returns>
        internal static System.IDisposable Dummy = new DummyDisposable();

        /// <summary>
        /// An IDisposable that does absolutely nothing. 
        /// </summary>
        internal class DummyDisposable : System.IDisposable
        {
            public void Dispose()
            {
            }
        }
        /// <summary>
        /// An IDisposable that saves the SynchronizationContext,sets it to <c>null</c> and 
        /// restores it to the original upon <c>Dispose()</c>. 
        /// 
        /// NOTE: This is designed to be less invasive than using <c>.ConfigureAwait(false)</c> 
        /// on every single <c>await</c> in library code (ie, places where we know we don't need
        /// to continue in the same context as we went async)
        /// </summary>
        internal class NoSyncContext : System.IDisposable
        {
            private System.Threading.SynchronizationContext original = System.Threading.SynchronizationContext.Current;
            internal NoSyncContext()
            {
                System.Threading.SynchronizationContext.SetSynchronizationContext(null);
            }
            public void Dispose() => System.Threading.SynchronizationContext.SetSynchronizationContext(original);
        }
    }
}