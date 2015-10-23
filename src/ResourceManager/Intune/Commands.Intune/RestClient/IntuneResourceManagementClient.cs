// Copyright (c) Microsoft Corporation. All rights reserved.

namespace Commands.Intune.RestClient
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using Models;

    /// <summary>
    /// Microsoft.Intune Resource provider Api features in the swagger-2.0
    /// specification
    /// </summary>
    public partial class IntuneResourceManagementClient : ServiceClient<IntuneResourceManagementClient>, IIntuneResourceManagementClient
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        public JsonSerializerSettings SerializationSettings { get; private set; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        public JsonSerializerSettings DeserializationSettings { get; private set; }        

        /// <summary>
        /// Service Api Version.
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Subscription credentials which uniquely identify client
        /// subscription.
        /// </summary>
        public ServiceClientCredentials Credentials { get; set; }

        /// <summary>
        /// Initializes a new instance of the IntuneResourceManagementClient class.
        /// </summary>
        public IntuneResourceManagementClient() : base()
        {
            this.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the IntuneResourceManagementClient class.
        /// </summary>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public IntuneResourceManagementClient(params DelegatingHandler[] handlers) : base(handlers)
        {
            this.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the IntuneResourceManagementClient class.
        /// </summary>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public IntuneResourceManagementClient(HttpClientHandler rootHandler, params DelegatingHandler[] handlers) : base(rootHandler, handlers)
        {
            this.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the IntuneResourceManagementClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public IntuneResourceManagementClient(Uri baseUri, params DelegatingHandler[] handlers) : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            this.Initialize();
            this.BaseUri = baseUri;
        }

        /// <summary>
        /// Initializes client properties.
        /// </summary>
        private void Initialize()
        {
            this.BaseUri = new Uri("https://management.azure.com");
            if (this.Credentials != null) 
            {
                this.Credentials.InitializeServiceClient(this);
            }
            SerializationSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            DeserializationSettings = new JsonSerializerSettings{
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
        }    
        /// <summary>
        /// Returns location for user tenant.
        /// </summary>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<LocationCollection>> GetLocationsWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "GetLocations", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations").ToString();
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse<LocationCollection>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<LocationCollection>(responseContent, this.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Returns location for given tenant.
        /// </summary>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<Location>> GetLocationByHostNameWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "GetLocationByHostName", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/hostName").ToString();
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse<Location>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<Location>(responseContent, this.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Returns Intune Manageable apps.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='filter'>
        /// The filter to apply on the operation.
        /// </param>
        /// <param name='top'>
        /// </param>
        /// <param name='select'>
        /// select specific fields in entity.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<ApplicationCollection>> GetApplicationsWithHttpMessagesAsync(string hostName, string filter = default(string), int? top = default(int?), string select = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("filter", filter);
                tracingParameters.Add("top", top);
                tracingParameters.Add("select", select);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "GetApplications", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/apps").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (filter != null)
            {
                queryParameters.Add(string.Format("$filter={0}", Uri.EscapeDataString(filter)));
            }
            if (top != null)
            {
                queryParameters.Add(string.Format("$top={0}", Uri.EscapeDataString(JsonConvert.SerializeObject(top, this.SerializationSettings).Trim('"'))));
            }
            if (select != null)
            {
                queryParameters.Add(string.Format("$select={0}", Uri.EscapeDataString(select)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse<ApplicationCollection>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<ApplicationCollection>(responseContent, this.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Returns Intune iosPolicies.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='filter'>
        /// The filter to apply on the operation.
        /// </param>
        /// <param name='top'>
        /// </param>
        /// <param name='select'>
        /// select specific fields in entity.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<IOSPolicyCollection>> GetiOSPoliciesWithHttpMessagesAsync(string hostName, string filter = default(string), int? top = default(int?), string select = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("filter", filter);
                tracingParameters.Add("top", top);
                tracingParameters.Add("select", select);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "GetiOSPolicies", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/iosPolicies").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (filter != null)
            {
                queryParameters.Add(string.Format("$filter={0}", Uri.EscapeDataString(filter)));
            }
            if (top != null)
            {
                queryParameters.Add(string.Format("$top={0}", Uri.EscapeDataString(JsonConvert.SerializeObject(top, this.SerializationSettings).Trim('"'))));
            }
            if (select != null)
            {
                queryParameters.Add(string.Format("$select={0}", Uri.EscapeDataString(select)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse<IOSPolicyCollection>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<IOSPolicyCollection>(responseContent, this.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Returns Intune android Policies.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='filter'>
        /// The filter to apply on the operation.
        /// </param>
        /// <param name='top'>
        /// </param>
        /// <param name='select'>
        /// select specific fields in entity.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<AndroidPolicyCollection>> GetAndroidPoliciesWithHttpMessagesAsync(string hostName, string filter = default(string), int? top = default(int?), string select = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("filter", filter);
                tracingParameters.Add("top", top);
                tracingParameters.Add("select", select);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "GetAndroidPolicies", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/androidPolicies").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (filter != null)
            {
                queryParameters.Add(string.Format("$filter={0}", Uri.EscapeDataString(filter)));
            }
            if (top != null)
            {
                queryParameters.Add(string.Format("$top={0}", Uri.EscapeDataString(JsonConvert.SerializeObject(top, this.SerializationSettings).Trim('"'))));
            }
            if (select != null)
            {
                queryParameters.Add(string.Format("$select={0}", Uri.EscapeDataString(select)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse<AndroidPolicyCollection>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<AndroidPolicyCollection>(responseContent, this.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Returns Intune iOS policies.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy unique Id
        /// </param>
        /// <param name='select'>
        /// select specific fields in entity.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<IOSPolicy>> GetiOSPolicyByIdWithHttpMessagesAsync(string hostName, string policyId, string select = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (policyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "policyId");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("policyId", policyId);
                tracingParameters.Add("select", select);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "GetiOSPolicyById", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/iosPolicies/{policyId}").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (select != null)
            {
                queryParameters.Add(string.Format("$select={0}", Uri.EscapeDataString(select)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse<IOSPolicy>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<IOSPolicy>(responseContent, this.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Creates or updates iosPolicy.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy unique Id
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Create or update an android policy operation.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<IOSPolicy>> CreateOrUpdateIOSPolicyWithHttpMessagesAsync(string hostName, string policyId, IOSPolicyRequestBody parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (policyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "policyId");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            if (parameters == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "parameters");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("policyId", policyId);
                tracingParameters.Add("parameters", parameters);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "CreateOrUpdateIOSPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/iosPolicies/{policyId}").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("PUT");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Serialize Request
            string requestContent = JsonConvert.SerializeObject(parameters, this.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse<IOSPolicy>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<IOSPolicy>(responseContent, this.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// patch an iosPolicy.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy unique Id
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Create or update an android policy operation.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<IOSPolicy>> PatchIOSPolicyWithHttpMessagesAsync(string hostName, string policyId, IOSPolicyRequestBody parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (policyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "policyId");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            if (parameters == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "parameters");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("policyId", policyId);
                tracingParameters.Add("parameters", parameters);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "PatchIOSPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/iosPolicies/{policyId}").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("PATCH");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Serialize Request
            string requestContent = JsonConvert.SerializeObject(parameters, this.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse<IOSPolicy>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<IOSPolicy>(responseContent, this.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Delete Ios Policy
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy unique Id
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse> DeleteIosPolicyWithHttpMessagesAsync(string hostName, string policyId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (policyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "policyId");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("policyId", policyId);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "DeleteIosPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/iosPolicies/{policyId}").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("DELETE");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK") || statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "NoContent")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Returns androidPolicy with given Id.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy unique Id
        /// </param>
        /// <param name='select'>
        /// select specific fields in entity.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<AndroidPolicy>> GetAndroidPolicyByIdWithHttpMessagesAsync(string hostName, string policyId, string select = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (policyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "policyId");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("policyId", policyId);
                tracingParameters.Add("select", select);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "GetAndroidPolicyById", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/androidPolicies/{policyId}").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (select != null)
            {
                queryParameters.Add(string.Format("$select={0}", Uri.EscapeDataString(select)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse<AndroidPolicy>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<AndroidPolicy>(responseContent, this.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Creates or updates androidPolicy.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy unique Id
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Create or update an android policy operation.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<AndroidPolicy>> CreateOrUpdateAndroidPolicyWithHttpMessagesAsync(string hostName, string policyId, AndroidPolicyRequestBody parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (policyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "policyId");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            if (parameters == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "parameters");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("policyId", policyId);
                tracingParameters.Add("parameters", parameters);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "CreateOrUpdateAndroidPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/androidPolicies/{policyId}").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("PUT");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Serialize Request
            string requestContent = JsonConvert.SerializeObject(parameters, this.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse<AndroidPolicy>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<AndroidPolicy>(responseContent, this.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Patch androidPolicy.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy unique Id
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Create or update an android policy operation.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<AndroidPolicy>> PatchAndroidPolicyWithHttpMessagesAsync(string hostName, string policyId, AndroidPolicyRequestBody parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (policyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "policyId");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            if (parameters == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "parameters");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("policyId", policyId);
                tracingParameters.Add("parameters", parameters);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "PatchAndroidPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/androidPolicies/{policyId}").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("PATCH");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Serialize Request
            string requestContent = JsonConvert.SerializeObject(parameters, this.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse<AndroidPolicy>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<AndroidPolicy>(responseContent, this.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Delete Android Policy
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy unique Id
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse> DeleteAndroidPolicyWithHttpMessagesAsync(string hostName, string policyId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (policyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "policyId");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("policyId", policyId);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "DeleteAndroidPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/androidPolicies/{policyId}").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("DELETE");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK") || statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "NoContent")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Add app to an iosPolicy.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy unique Id
        /// </param>
        /// <param name='appId'>
        /// application unique Id
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to add an app to an ios policy.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse> AddAppForIOSPolicyWithHttpMessagesAsync(string hostName, string policyId, string appId, MAMPolicyAppIdOrGroupIdPayload parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (policyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "policyId");
            }
            if (appId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "appId");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            if (parameters == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "parameters");
            }
            if (parameters != null)
            {
                parameters.Validate();
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("policyId", policyId);
                tracingParameters.Add("appId", appId);
                tracingParameters.Add("parameters", parameters);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "AddAppForIOSPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/iosPolicies/{policyId}/apps/{appId}").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
            url = url.Replace("{appId}", Uri.EscapeDataString(appId));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("PUT");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Serialize Request
            string requestContent = JsonConvert.SerializeObject(parameters, this.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK") || statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "NoContent")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Delete App for Ios Policy
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy unique Id
        /// </param>
        /// <param name='appId'>
        /// application unique Id
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse> DeleteAppForIosPolicyWithHttpMessagesAsync(string hostName, string policyId, string appId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (policyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "policyId");
            }
            if (appId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "appId");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("policyId", policyId);
                tracingParameters.Add("appId", appId);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "DeleteAppForIosPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/iosPolicies/{policyId}/apps/{appId}").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
            url = url.Replace("{appId}", Uri.EscapeDataString(appId));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("DELETE");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK") || statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "NoContent")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Add app to an androidPolicy.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy unique Id
        /// </param>
        /// <param name='appId'>
        /// application unique Id
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Create or update app to an android policy
        /// operation.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse> AddAppForAndriodPolicyWithHttpMessagesAsync(string hostName, string policyId, string appId, MAMPolicyAppIdOrGroupIdPayload parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (policyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "policyId");
            }
            if (appId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "appId");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            if (parameters == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "parameters");
            }
            if (parameters != null)
            {
                parameters.Validate();
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("policyId", policyId);
                tracingParameters.Add("appId", appId);
                tracingParameters.Add("parameters", parameters);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "AddAppForAndriodPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/andriodPolicies/{policyId}/apps/{appId}").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
            url = url.Replace("{appId}", Uri.EscapeDataString(appId));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("PUT");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Serialize Request
            string requestContent = JsonConvert.SerializeObject(parameters, this.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK") || statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "NoContent")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Delete App for Android Policy
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy unique Id
        /// </param>
        /// <param name='appId'>
        /// application unique Id
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse> DeleteAppForAndroidPolicyWithHttpMessagesAsync(string hostName, string policyId, string appId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (policyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "policyId");
            }
            if (appId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "appId");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("policyId", policyId);
                tracingParameters.Add("appId", appId);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "DeleteAppForAndroidPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/andriodPolicies/{policyId}/apps/{appId}").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
            url = url.Replace("{appId}", Uri.EscapeDataString(appId));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("DELETE");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK") || statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "NoContent")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Returns groups for a given ioSPolicy.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy id for the tenant
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<GroupsCollection>> GetGroupsForiOSPolicyWithHttpMessagesAsync(string hostName, string policyId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (policyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "policyId");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("policyId", policyId);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "GetGroupsForiOSPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/iosPolicies/{policyId}/groups").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse<GroupsCollection>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<GroupsCollection>(responseContent, this.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Returns groups for a given androidPolicy.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy id for the tenant
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<GroupsCollection>> GetGroupsForAndroidPolicyWithHttpMessagesAsync(string hostName, string policyId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (policyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "policyId");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("policyId", policyId);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "GetGroupsForAndroidPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/androidPolicies/{policyId}/groups").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse<GroupsCollection>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<GroupsCollection>(responseContent, this.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Add group to an iosPolicy.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy unique Id
        /// </param>
        /// <param name='groupId'>
        /// group Id
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Create or update app to an android policy
        /// operation.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse> AddGroupForiOSPolicyWithHttpMessagesAsync(string hostName, string policyId, string groupId, MAMPolicyAppIdOrGroupIdPayload parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (policyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "policyId");
            }
            if (groupId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "groupId");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            if (parameters == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "parameters");
            }
            if (parameters != null)
            {
                parameters.Validate();
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("policyId", policyId);
                tracingParameters.Add("groupId", groupId);
                tracingParameters.Add("parameters", parameters);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "AddGroupForiOSPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/iosPolicies/{policyId}/groups/{groupId}").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
            url = url.Replace("{groupId}", Uri.EscapeDataString(groupId));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("PUT");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Serialize Request
            string requestContent = JsonConvert.SerializeObject(parameters, this.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK") || statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "NoContent")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Delete Group for iOS Policy
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy unique Id
        /// </param>
        /// <param name='groupId'>
        /// application unique Id
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse> DeleteGroupForiOSPolicyWithHttpMessagesAsync(string hostName, string policyId, string groupId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (policyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "policyId");
            }
            if (groupId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "groupId");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("policyId", policyId);
                tracingParameters.Add("groupId", groupId);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "DeleteGroupForiOSPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/iosPolicies/{policyId}/groups/{groupId}").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
            url = url.Replace("{groupId}", Uri.EscapeDataString(groupId));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("DELETE");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK") || statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "NoContent")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Add group to an androidPolicy.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy unique Id
        /// </param>
        /// <param name='groupId'>
        /// group Id
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Create or update app to an android policy
        /// operation.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse> AddGroupForAndriodPolicyWithHttpMessagesAsync(string hostName, string policyId, string groupId, MAMPolicyAppIdOrGroupIdPayload parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (policyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "policyId");
            }
            if (groupId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "groupId");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            if (parameters == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "parameters");
            }
            if (parameters != null)
            {
                parameters.Validate();
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("policyId", policyId);
                tracingParameters.Add("groupId", groupId);
                tracingParameters.Add("parameters", parameters);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "AddGroupForAndriodPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/andriodPolicies/{policyId}/groups/{groupId}").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
            url = url.Replace("{groupId}", Uri.EscapeDataString(groupId));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("PUT");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Serialize Request
            string requestContent = JsonConvert.SerializeObject(parameters, this.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK") || statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "NoContent")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Delete Group for Android Policy
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy unique Id
        /// </param>
        /// <param name='groupId'>
        /// application unique Id
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<HttpOperationResponse> DeleteGroupForAndroidPolicyWithHttpMessagesAsync(string hostName, string policyId, string groupId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (hostName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "hostName");
            }
            if (policyId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "policyId");
            }
            if (groupId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "groupId");
            }
            if (this.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.ApiVersion");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("hostName", hostName);
                tracingParameters.Add("policyId", policyId);
                tracingParameters.Add("groupId", groupId);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "DeleteGroupForAndroidPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/andriodPolicies/{policyId}/groups/{groupId}").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
            url = url.Replace("{groupId}", Uri.EscapeDataString(groupId));
            List<string> queryParameters = new List<string>();
            if (this.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("DELETE");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK") || statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "NoContent")))
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                Error errorBody = JsonConvert.DeserializeObject<Error>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new HttpOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

    }
}
