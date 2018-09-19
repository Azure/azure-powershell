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
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;

namespace Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.WebClient
{
    internal class WAPackIaaSClient
    {
        private IRequestChannel requestChannel = new WAPackIaaSRequestChannel();

        private Subscription subscription;

        private HttpQueryParameters queryParameters;

        private HttpFilters httpFilters;

        private String uriSuffix;

        private Dictionary<string, string> headers;

        private const string JsonContentType = @"application/json";

        private void Initialize()
        {
            this.queryParameters = new HttpQueryParameters();
            this.httpFilters = new HttpFilters();
            this.uriSuffix = String.Empty;
            this.headers = new Dictionary<string, string>();
        }
        
        internal WAPackIaaSClient(Subscription wapSubscription, IRequestChannel channel = null)
        {
            if (wapSubscription == null)
            {
                throw new ArgumentNullException(Resources.SubscriptionMustNotBeNull);
            }

            this.requestChannel = channel ?? new WAPackIaaSRequestChannel();

            this.subscription = wapSubscription;
            Initialize();
        }

        internal void AddQueryParameters(string name, string value)
        {
            this.queryParameters.Add(name, value);
        }

        internal void AddHttpFilter(string filterName, WebFilterOptions filterOption, string filterValue)
        {
            this.httpFilters.Add(filterName, filterOption, filterValue);
        }

        internal void SetUriSuffix(string uriSuffix)
        {
            this.uriSuffix = uriSuffix;
        }

        internal string GetUriSuffix()
        {
            return this.uriSuffix;
        }

        internal void AddHeaders(string name, string value)
        {
            if (this.headers.ContainsKey(name))
            {
                this.headers[name] = value;
            }
            else
            {
                this.headers.Add(name, value);
            }
        }

        internal List<T> Create<T>(object payload, out WebHeaderCollection responseHeaders)
        {
            string payloadString;
            var webRequest = this.CreateWebRequestObject<T>(HttpMethod.Post, payload, out payloadString);
            return this.requestChannel.IssueRequestAndGetResponse<T>(webRequest, out responseHeaders, payloadString);
        }

        internal List<T> Get<T>(out WebHeaderCollection responseHeaders)
        {
            var webRequest = this.CreateWebRequestObject<T>(HttpMethod.Get);
            return this.requestChannel.IssueRequestAndGetResponse<T>(webRequest, out responseHeaders);
        }

        internal void Delete<T>(out WebHeaderCollection responseHeaders)
        {
            var webRequest = this.CreateWebRequestObject<T>(HttpMethod.Delete);
            this.requestChannel.IssueRequestAndGetResponse<T>(webRequest, out responseHeaders);
        }

        internal List<T> Update<T>(object payload, out WebHeaderCollection responseHeaders)
        {
            string payloadString;
            var webRequest = this.CreateWebRequestObject<T>(HttpMethod.Put, payload, out payloadString);
            return this.requestChannel.IssueRequestAndGetResponse<T>(webRequest, out responseHeaders, payloadString);
        }

        private HttpWebRequest CreateWebRequestObject<T>(HttpMethod method, object payload, out string payloadString)
        {
            if (payload != null && (method != HttpMethod.Get || method != HttpMethod.Delete))
            {
                var jsonHelper = new JsonHelpers<T>();
                string json = jsonHelper.Serialize(payload);

                payloadString = json;
            }
            else
            {
                payloadString = null;
            }


            return CreateWebRequestObject<T>(method);
        }

        private HttpWebRequest CreateWebRequestObject<T>(HttpMethod method)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(this.GetAbsoluteUri());
            
            webRequest.Method = method.ToString();
            webRequest.Accept = JsonContentType;
            webRequest.ContentType = JsonContentType;

            SetCredentialsOnWebRequest(webRequest);
            
            if (this.headers.Count > 0)
            {
                foreach (var header in this.headers)
                {
                    webRequest.Headers.Add(header.Key, header.Value);
                }
            }
                    
            if (method == HttpMethod.Put)
            {
                webRequest.Headers.Add("Prefer", "return-content");
            }

            if (method == HttpMethod.Get || method == HttpMethod.Delete)
            {
                webRequest.ContentLength = 0;
            }

            return webRequest;
        }
        
        internal string GetAbsoluteUri()
        {
            var uri = new StringBuilder();
            
            var baseUri = this.subscription.ServiceEndpoint.AbsoluteUri;

            uri.Append(baseUri);

            if (!String.IsNullOrEmpty(this.uriSuffix))
                uri.Append(uriSuffix);

            var queryString = this.queryParameters.ToString();
            var filterString = this.httpFilters.ToString();

            if (!String.IsNullOrWhiteSpace(queryString) && !String.IsNullOrWhiteSpace(filterString))
            {
                uri.AppendFormat("?{0}&{1}", queryString, filterString);
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(queryString))
                    uri.AppendFormat("?{0}", queryString);
                else if (!String.IsNullOrWhiteSpace(filterString))
                    uri.AppendFormat("?{0}", filterString);
            }

            return uri.ToString();
        }

        private void SetCredentialsOnWebRequest(HttpWebRequest webRequest)
        {
            switch (this.subscription.CredentialType)
            {
                case CredentialType.None:
                    return;
                case CredentialType.DefaultCredentials:
                    webRequest.Credentials = CredentialCache.DefaultCredentials;
                    break;
                case CredentialType.DefaultNetworkCredentials:
                    webRequest.Credentials = CredentialCache.DefaultNetworkCredentials;
                    break;
                case CredentialType.NetworkCredential:
                    webRequest.Credentials = this.subscription.GetNetworkCredentials();
                    break;
                case CredentialType.UseCertificate:
                    webRequest.ClientCertificates.Add(this.subscription.Certificate);
                    break;
            }

        }
    }
}

