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

using Microsoft.Azure.Batch.Protocol;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Interfaces;
using Microsoft.Azure.Commands.TestFx.Mocks;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HttpClientTransport = Azure.Core.Pipeline.HttpClientTransport;
using Track2BatchClientOptions = Azure.Compute.Batch.BatchClientOptions;

namespace Microsoft.Azure.Commands.Batch.Test.Track2
{
    /// <summary>
    /// A BatchAccountContext whose Track 1 and Track 2 clients send their requests to a test handler instead of the
    /// network.
    /// </summary>
    internal class Track2TestContext : BatchAccountContext
    {
        private readonly HttpMessageHandler handler;

        public Track2TestContext(IAzureContext azureContext, string accountName, string accountUrl, HttpMessageHandler handler, string primaryKey = null)
            : base(azureContext)
        {
            this.AccountName = accountName;
            this.TaskTenantUrl = accountUrl;
            this.PrimaryAccountKey = primaryKey;
            this.handler = handler;
        }

        protected override Track2BatchClientOptions CreateTrack2ClientOptions()
        {
            Track2BatchClientOptions options = base.CreateTrack2ClientOptions();
            options.Transport = new HttpClientTransport(new HttpClient(this.handler));
            options.Retry.MaxRetries = 0;
            return options;
        }

        protected override BatchServiceClient CreateBatchRestClient(string url, ServiceClientCredentials creds, DelegatingHandler handler = default(DelegatingHandler))
        {
            return base.CreateBatchRestClient(url, creds, new ForwardingHandler(this.handler));
        }
    }

    /// <summary>
    /// Sends the Track 1 client's requests to the test handler.
    /// </summary>
    internal class ForwardingHandler : DelegatingHandler
    {
        private readonly HttpMessageInvoker target;

        public ForwardingHandler(HttpMessageHandler target)
        {
            this.target = new HttpMessageInvoker(target, disposeHandler: false);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return this.target.SendAsync(request, cancellationToken);
        }
    }

    /// <summary>
    /// Records every request and answers with canned responses (first match on "METHOD path" wins, else the default).
    /// </summary>
    internal class RecordingHandler : HttpMessageHandler
    {
        private readonly List<KeyValuePair<string, Func<HttpRequestMessage, HttpResponseMessage>>> routes =
            new List<KeyValuePair<string, Func<HttpRequestMessage, HttpResponseMessage>>>();

        public List<RecordedRequest> Requests { get; } = new List<RecordedRequest>();

        public RecordingHandler On(string methodAndPathPrefix, HttpStatusCode status, string json = null, IDictionary<string, string> headers = null, string reasonPhrase = null)
        {
            this.routes.Add(new KeyValuePair<string, Func<HttpRequestMessage, HttpResponseMessage>>(methodAndPathPrefix, request =>
            {
                HttpResponseMessage response = new HttpResponseMessage(status) { RequestMessage = request };
                if (reasonPhrase != null)
                {
                    response.ReasonPhrase = reasonPhrase;
                }
                response.Content = new StringContent(json ?? string.Empty, Encoding.UTF8, "application/json");
                if (headers != null)
                {
                    foreach (KeyValuePair<string, string> h in headers)
                    {
                        response.Headers.TryAddWithoutValidation(h.Key, h.Value);
                    }
                }
                return response;
            }));
            return this;
        }

        /// <summary>
        /// Answers the requests that match with the given pages, one after another (the last page keeps answering).
        /// </summary>
        public RecordingHandler OnPages(string methodAndPathPrefix, params string[] pages)
        {
            int next = 0;
            this.routes.Add(new KeyValuePair<string, Func<HttpRequestMessage, HttpResponseMessage>>(methodAndPathPrefix, request =>
            {
                string page = pages[Math.Min(next++, pages.Length - 1)];
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(page, Encoding.UTF8, "application/json")
                };
            }));
            return this;
        }

        protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return SendAsync(request, cancellationToken).GetAwaiter().GetResult();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            RecordedRequest recorded = new RecordedRequest
            {
                Method = request.Method.Method,
                Uri = request.RequestUri,
                Authorization = request.Headers.Authorization?.ToString(),
                UserAgent = request.Headers.TryGetValues("User-Agent", out IEnumerable<string> ua) ? string.Join(" ", ua) : null,
                Body = request.Content == null ? null : await request.Content.ReadAsStringAsync().ConfigureAwait(false),
            };
            this.Requests.Add(recorded);

            string key = recorded.Method + " " + request.RequestUri.AbsolutePath;
            foreach (KeyValuePair<string, Func<HttpRequestMessage, HttpResponseMessage>> route in this.routes)
            {
                if (key.StartsWith(route.Key, StringComparison.OrdinalIgnoreCase))
                {
                    return route.Value(request);
                }
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound) { RequestMessage = request, Content = new StringContent("{\"code\":\"NotRouted\",\"message\":{\"lang\":\"en-US\",\"value\":\"No canned response for " + key + "\"}}", Encoding.UTF8, "application/json") };
        }
    }

    internal class RecordedRequest
    {
        public string Method { get; set; }
        public Uri Uri { get; set; }
        public string Authorization { get; set; }
        public string UserAgent { get; set; }
        public string Body { get; set; }
    }

    /// <summary>
    /// Az.Accounts sign-in stand-in: records which environment and resource were asked for and returns
    /// "token-for-{resource}" so the test can see which resource the token was issued for.
    /// </summary>
    internal class RecordingAuthenticationFactory : IAuthenticationFactory
    {
        private readonly MockTokenAuthenticationFactory inner = new MockTokenAuthenticationFactory();

        public IAzureEnvironment Environment { get; private set; }

        public string ResourceId { get; private set; }

        public int Calls { get; private set; }

        public IAccessToken Authenticate(IAzureAccount account, IAzureEnvironment environment, string tenant, SecureString password, string promptBehavior, Action<string> promptAction, IAzureTokenCache tokenCache, string resourceId = "ActiveDirectoryServiceEndpointResourceId")
        {
            return Record(account, environment, tenant, resourceId);
        }

        public IAccessToken Authenticate(IAzureAccount account, IAzureEnvironment environment, string tenant, SecureString password, string promptBehavior, Action<string> promptAction, string resourceId = "ActiveDirectoryServiceEndpointResourceId")
        {
            return Record(account, environment, tenant, resourceId);
        }

        public IAccessToken Authenticate(IAzureAccount account, IAzureEnvironment environment, string tenant, SecureString password, string promptBehavior, Action<string> promptAction, IDictionary<string, object> optionalParameters)
        {
            object resourceId = null;
            optionalParameters?.TryGetValue("resourceId", out resourceId);
            return Record(account, environment, tenant, resourceId as string);
        }

        private IAccessToken Record(IAzureAccount account, IAzureEnvironment environment, string tenant, string resourceId)
        {
            this.Calls++;
            this.Environment = environment;
            this.ResourceId = resourceId;
            string resource = environment.GetEndpoint(resourceId) ?? resourceId;
            return new MockAccessToken { AccessToken = "token-for-" + resource, UserId = account?.Id, TenantId = tenant, LoginType = LoginType.OrgId };
        }

        public ServiceClientCredentials GetServiceClientCredentials(IAzureContext context) => this.inner.GetServiceClientCredentials(context);

        public ServiceClientCredentials GetServiceClientCredentials(IAzureContext context, string targetEndpoint) => this.inner.GetServiceClientCredentials(context, targetEndpoint);

        public ServiceClientCredentials GetServiceClientCredentials(IAzureContext context, ICmdletContext cmdletContext) => this.inner.GetServiceClientCredentials(context, cmdletContext);

        public ServiceClientCredentials GetServiceClientCredentials(IAzureContext context, string targetEndpoint, ICmdletContext cmdletContext) => this.inner.GetServiceClientCredentials(context, targetEndpoint, cmdletContext);

        public ServiceClientCredentials GetServiceClientCredentials(string accessToken, Func<string> renew = null) => this.inner.GetServiceClientCredentials(accessToken, renew);

        public void RemoveUser(IAzureAccount account, IAzureTokenCache tokenCache) => this.inner.RemoveUser(account, tokenCache);

        public void RemoveUser(IAzureAccount account, IAzureEnvironment environment) => this.inner.RemoveUser(account, environment);

        public SubscriptionCloudCredentials GetSubscriptionCloudCredentials(IAzureContext context) => this.inner.GetSubscriptionCloudCredentials(context);

        public SubscriptionCloudCredentials GetSubscriptionCloudCredentials(IAzureContext context, string targetEndpoint) => this.inner.GetSubscriptionCloudCredentials(context, targetEndpoint);
    }
}
