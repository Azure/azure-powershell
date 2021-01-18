/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime
{
    using System.Net.Http;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections;
    using System.Linq;

    /// <summary>
    /// The interface for sending an HTTP request across the wire.
    /// </summary>
    public interface ISendAsync
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, IEventListener callback);
    }

    public class SendAsyncTerminalFactory : ISendAsyncTerminalFactory, ISendAsync
    {
        SendAsync implementation;

        public SendAsyncTerminalFactory(SendAsync implementation) => this.implementation = implementation;
        public SendAsyncTerminalFactory(ISendAsync implementation) => this.implementation = implementation.SendAsync;
        public ISendAsync Create() => this;
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, IEventListener callback) => implementation(request, callback);
    }

    public partial class SendAsyncFactory : ISendAsyncFactory
    {
        public class Sender : ISendAsync
        {
            internal ISendAsync next;
            internal SendAsyncStep implementation;

            public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, IEventListener callback) => implementation(request, callback, next);
        }
        SendAsyncStep implementation;

        public SendAsyncFactory(SendAsyncStep implementation) => this.implementation = implementation;
        public ISendAsync Create(ISendAsync next) => new Sender { next = next, implementation = implementation };

    }

    public class HttpClientFactory : ISendAsyncTerminalFactory, ISendAsync
    {
        HttpClient client;
        public HttpClientFactory() : this(new HttpClient())
        {
        }
        public HttpClientFactory(HttpClient client) => this.client = client;
        public ISendAsync Create() => this;

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, IEventListener callback) => client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, callback.Token);
    }

    public interface ISendAsyncFactory
    {
        ISendAsync Create(ISendAsync next);
    }

    public interface ISendAsyncTerminalFactory
    {
        ISendAsync Create();
    }

    public partial class HttpPipeline : ISendAsync
    {
        private ISendAsync pipeline;
        private ISendAsyncTerminalFactory terminal;
        private List<ISendAsyncFactory> steps = new List<ISendAsyncFactory>();

        public HttpPipeline() : this(new HttpClientFactory())
        {
        }

        public HttpPipeline(ISendAsyncTerminalFactory terminalStep)
        {
            if (terminalStep == null)
            {
                throw new System.ArgumentNullException(nameof(terminalStep), "Terminal Step Factory in HttpPipeline may not be null");
            }
            TerminalFactory = terminalStep;
        }

        /// <summary>
        /// Returns an HttpPipeline with the current state of this pipeline.
        /// </summary>
        public HttpPipeline Clone() => new HttpPipeline(terminal) { steps = this.steps.ToList(), pipeline = this.pipeline };

        public ISendAsyncTerminalFactory TerminalFactory
        {
            get => terminal;
            set
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException("TerminalFactory in HttpPipeline may not be null");
                }
                terminal = value;
            }
        }

        public ISendAsync Pipeline
        {
            get
            {
                // if the pipeline has been created and not invalidated, return it. 
                if (this.pipeline != null)
                {
                    return this.pipeline;
                }

                // create the pipeline from scratch.
                var next = terminal.Create();
                foreach (var factory in steps)
                {
                    // skip factories that return null.
                    next = factory.Create(next) ?? next;
                }
                return this.pipeline = next;
            }
        }

        public int Count => steps.Count;

        public HttpPipeline Prepend(ISendAsyncFactory item)
        {
            if (item != null)
            {
                steps.Add(item);
                pipeline = null;
            }
            return this;
        }

        public HttpPipeline Append(SendAsyncStep item)
        {
            if (item != null)
            {
                Append(new SendAsyncFactory(item));
            }
            return this;
        }

        public HttpPipeline Prepend(SendAsyncStep item)
        {
            if (item != null)
            {
                Prepend(new SendAsyncFactory(item));
            }
            return this;
        }
        public HttpPipeline Append(IEnumerable<SendAsyncStep> items)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    Append(new SendAsyncFactory(item));
                }
            }
            return this;
        }

        public HttpPipeline Prepend(IEnumerable<SendAsyncStep> items)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    Prepend(new SendAsyncFactory(item));
                }
            }
            return this;
        }

        public HttpPipeline Append(ISendAsyncFactory item)
        {
            if (item != null)
            {
                steps.Insert(0, item);
                pipeline = null;
            }
            return this;
        }
        public HttpPipeline Prepend(IEnumerable<ISendAsyncFactory> items)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    Prepend(item);
                }
            }
            return this;
        }

        public HttpPipeline Append(IEnumerable<ISendAsyncFactory> items)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    Append(item);
                }
            }
            return this;
        }

        // you can use this as the ISendAsync Implementation
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, IEventListener callback) => Pipeline.SendAsync(request, callback);
    }

    internal static partial class Extensions
    {
        internal static HttpRequestMessage CloneAndDispose(this HttpRequestMessage original, System.Uri requestUri = null, System.Net.Http.HttpMethod method = null)
        {
            using (original)
            {
                return original.Clone(requestUri, method);
            }
        }

        internal static Task<HttpRequestMessage> CloneWithContentAndDispose(this HttpRequestMessage original, System.Uri requestUri = null, System.Net.Http.HttpMethod method = null)
        {
            using (original)
            {
                return original.CloneWithContent(requestUri, method);
            }
        }

        /// <summary>
        /// Clones an HttpRequestMessage (without the content)
        /// </summary>
        /// <param name="original">Original HttpRequestMessage (Will be diposed before returning)</param>
        /// <returns>A clone of the HttpRequestMessage</returns>
        internal static HttpRequestMessage Clone(this HttpRequestMessage original, System.Uri requestUri = null, System.Net.Http.HttpMethod method = null)
        {
            var clone = new HttpRequestMessage
            {
                Method = method ?? original.Method,
                RequestUri = requestUri ?? original.RequestUri,
                Version = original.Version,
            };

            foreach (KeyValuePair<string, object> prop in original.Properties)
            {
                clone.Properties.Add(prop);
            }
            
            foreach (KeyValuePair<string, IEnumerable<string>> header in original.Headers)
            {   
                /*
                **temporarily skip cloning telemetry related headers**
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
                */
                if (!"x-ms-unique-id".Equals(header.Key) && !"x-ms-client-request-id".Equals(header.Key) && !"CommandName".Equals(header.Key) && !"FullCommandName".Equals(header.Key) && !"ParameterSetName".Equals(header.Key) && !"User-Agent".Equals(header.Key))
                {
                    clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }
            
            return clone;
        }

        /// <summary>
        /// Clones an HttpRequestMessage (including the content stream and content headers) 
        /// </summary>
        /// <param name="original">Original HttpRequestMessage (Will be diposed before returning)</param>
        /// <returns>A clone of the HttpRequestMessage</returns>
        internal static async Task<HttpRequestMessage> CloneWithContent(this HttpRequestMessage original, System.Uri requestUri = null, System.Net.Http.HttpMethod method = null)
        {
            var clone = original.Clone(requestUri, method);
            var stream = new System.IO.MemoryStream();
            if (original.Content != null)
            {
                await original.Content.CopyToAsync(stream).ConfigureAwait(false);
                stream.Position = 0;
                clone.Content = new StreamContent(stream);
                if (original.Content.Headers != null)
                {
                    foreach (var h in original.Content.Headers)
                    {
                        clone.Content.Headers.Add(h.Key, h.Value);
                    }
                }
            }
            return clone;
        }
    }
}
