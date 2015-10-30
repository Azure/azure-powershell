// Copyright (c) Microsoft Corporation. All rights reserved.

namespace Microsoft.Azure.Commands.Intune.RestClient
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
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
    using System.Linq;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Microsoft.Intune Resource provider Api features in the swagger-2.0
    /// specification
    /// </summary>
    public partial class IntuneResourceManagementClient : ServiceClient<IntuneResourceManagementClient>, IIntuneResourceManagementClient, IAzureClient
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
        /// The management credentials for Azure.
        /// </summary>
        public ServiceClientCredentials Credentials { get; private set; }

        /// <summary>
        /// Service Api Version.
        /// </summary>
        public string ApiVersion { get; private set; }

        /// <summary>
        /// Gets or sets the preferred language for the response.
        /// </summary>
        public string AcceptLanguage { get; set; }

        /// <summary>
        /// The retry timeout for Long Running Operations.
        /// </summary>
        public int? LongRunningOperationRetryTimeout { get; set; }

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
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
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
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
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
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public IntuneResourceManagementClient(Uri baseUri, params DelegatingHandler[] handlers) : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            this.BaseUri = baseUri;
        }

        /// <summary>
        /// Initializes a new instance of the IntuneResourceManagementClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. The management credentials for Azure.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public IntuneResourceManagementClient(ServiceClientCredentials credentials, params DelegatingHandler[] handlers) : this(handlers)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this.Credentials = credentials;
        }

        /// <summary>
        /// Initializes a new instance of the IntuneResourceManagementClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required. The management credentials for Azure.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public IntuneResourceManagementClient(Uri baseUri, ServiceClientCredentials credentials, params DelegatingHandler[] handlers) : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this.BaseUri = baseUri;
            this.Credentials = credentials;
        }

        /// <summary>
        /// Initializes client properties.
        /// </summary>
        private void Initialize()
        {
            this.BaseUri = new Uri("https://management.azure.com");
            this.ApiVersion = "2015-01-11-alpha";
            this.AcceptLanguage = "en-US";
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
            SerializationSettings.Converters.Add(new ResourceJsonConverter()); 
            DeserializationSettings = new JsonSerializerSettings{
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            DeserializationSettings.Converters.Add(new ResourceJsonConverter()); 
            DeserializationSettings.Converters.Add(new CloudErrorJsonConverter()); 
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
        public async Task<AzureOperationResponse<LocationCollection>> GetLocationsWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                CloudError errorBody = JsonConvert.DeserializeObject<CloudError>(responseContent, this.DeserializationSettings);
                if (errorBody != null)
                {
                    ex = new CloudException(errorBody.Message);
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
            var result = new AzureOperationResponse<LocationCollection>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
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
        public async Task<AzureOperationResponse<Location>> GetLocationByHostNameWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse<Location>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
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
        public async Task<AzureOperationResponse<ApplicationCollection>> GetApplicationsWithHttpMessagesAsync(string hostName, string filter = default(string), int? top = default(int?), string select = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse<ApplicationCollection>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
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
        /// Returns Intune iOSPolicies.
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
        public async Task<AzureOperationResponse<IOSMAMPolicyCollection>> GetiOSMAMPoliciesWithHttpMessagesAsync(string hostName, string filter = default(string), int? top = default(int?), string select = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                ServiceClientTracing.Enter(invocationId, this, "GetiOSMAMPolicies", tracingParameters);
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse<IOSMAMPolicyCollection>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<IOSMAMPolicyCollection>(responseContent, this.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Returns Intune Android policies.
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
        public async Task<AzureOperationResponse<AndroidMAMPolicyCollection>> GetAndroidMAMPoliciesWithHttpMessagesAsync(string hostName, string filter = default(string), int? top = default(int?), string select = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                ServiceClientTracing.Enter(invocationId, this, "GetAndroidMAMPolicies", tracingParameters);
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse<AndroidMAMPolicyCollection>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<AndroidMAMPolicyCollection>(responseContent, this.DeserializationSettings);
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
        public async Task<AzureOperationResponse<IOSMAMPolicy>> GetiOSMAMPolicyByIdWithHttpMessagesAsync(string hostName, string policyId, string select = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                ServiceClientTracing.Enter(invocationId, this, "GetiOSMAMPolicyById", tracingParameters);
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse<IOSMAMPolicy>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<IOSMAMPolicy>(responseContent, this.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Creates or updates iOSMAMPolicy.
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
        public async Task<AzureOperationResponse<IOSMAMPolicy>> CreateOrUpdateiOSMAMPolicyWithHttpMessagesAsync(string hostName, string policyId, IOSMAMPolicyRequestBody parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                ServiceClientTracing.Enter(invocationId, this, "CreateOrUpdateiOSMAMPolicy", tracingParameters);
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse<IOSMAMPolicy>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<IOSMAMPolicy>(responseContent, this.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// patch an iOSMAMPolicy.
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
        public async Task<AzureOperationResponse<IOSMAMPolicy>> PatchiOSMAMPolicyWithHttpMessagesAsync(string hostName, string policyId, IOSMAMPolicyRequestBody parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                ServiceClientTracing.Enter(invocationId, this, "PatchiOSMAMPolicy", tracingParameters);
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse<IOSMAMPolicy>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<IOSMAMPolicy>(responseContent, this.DeserializationSettings);
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
        public async Task<AzureOperationResponse> DeleteiOSMAMPolicyWithHttpMessagesAsync(string hostName, string policyId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                ServiceClientTracing.Enter(invocationId, this, "DeleteiOSMAMPolicy", tracingParameters);
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Returns AndroidMAMPolicy with given Id.
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
        public async Task<AzureOperationResponse<AndroidMAMPolicy>> GetAndroidMAMPolicyByIdWithHttpMessagesAsync(string hostName, string policyId, string select = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                ServiceClientTracing.Enter(invocationId, this, "GetAndroidMAMPolicyById", tracingParameters);
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse<AndroidMAMPolicy>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<AndroidMAMPolicy>(responseContent, this.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Creates or updates AndroidMAMPolicy.
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
        public async Task<AzureOperationResponse<AndroidMAMPolicy>> CreateOrUpdateAndroidMAMPolicyWithHttpMessagesAsync(string hostName, string policyId, AndroidMAMPolicyRequestBody parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                ServiceClientTracing.Enter(invocationId, this, "CreateOrUpdateAndroidMAMPolicy", tracingParameters);
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse<AndroidMAMPolicy>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<AndroidMAMPolicy>(responseContent, this.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Patch AndroidMAMPolicy.
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
        public async Task<AzureOperationResponse<AndroidMAMPolicy>> PatchAndroidMAMPolicyWithHttpMessagesAsync(string hostName, string policyId, AndroidMAMPolicyRequestBody parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                ServiceClientTracing.Enter(invocationId, this, "PatchAndroidMAMPolicy", tracingParameters);
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse<AndroidMAMPolicy>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<AndroidMAMPolicy>(responseContent, this.DeserializationSettings);
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
        public async Task<AzureOperationResponse> DeleteAndroidMAMPolicyWithHttpMessagesAsync(string hostName, string policyId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                ServiceClientTracing.Enter(invocationId, this, "DeleteAndroidMAMPolicy", tracingParameters);
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Get apps for an iOSMAMPolicy.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy unique Id
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
        public async Task<AzureOperationResponse<ApplicationCollection>> GetAppForiOSMAMPolicyWithHttpMessagesAsync(string hostName, string policyId, string filter = default(string), int? top = default(int?), string select = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                tracingParameters.Add("filter", filter);
                tracingParameters.Add("top", top);
                tracingParameters.Add("select", select);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "GetAppForiOSMAMPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/iosPolicies/{policyId}/apps").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse<ApplicationCollection>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
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
        /// Get apps for an AndroidMAMPolicy.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy unique Id
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
        public async Task<AzureOperationResponse<ApplicationCollection>> GetAppForAndroidMAMPolicyWithHttpMessagesAsync(string hostName, string policyId, string filter = default(string), int? top = default(int?), string select = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                tracingParameters.Add("filter", filter);
                tracingParameters.Add("top", top);
                tracingParameters.Add("select", select);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "GetAppForAndroidMAMPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/AndroidPolicies/{policyId}/apps").ToString();
            url = url.Replace("{hostName}", Uri.EscapeDataString(hostName));
            url = url.Replace("{policyId}", Uri.EscapeDataString(policyId));
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse<ApplicationCollection>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
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
        /// Add app to an iOSMAMPolicy.
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
        public async Task<AzureOperationResponse> AddAppForiOSMAMPolicyWithHttpMessagesAsync(string hostName, string policyId, string appId, MAMPolicyAppIdOrGroupIdPayload parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                ServiceClientTracing.Enter(invocationId, this, "AddAppForiOSMAMPolicy", tracingParameters);
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
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
        public async Task<AzureOperationResponse> DeleteAppForiOSMAMPolicyWithHttpMessagesAsync(string hostName, string policyId, string appId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                ServiceClientTracing.Enter(invocationId, this, "DeleteAppForiOSMAMPolicy", tracingParameters);
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Add app to an AndroidMAMPolicy.
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
        public async Task<AzureOperationResponse> AddAppForAndriodPolicyWithHttpMessagesAsync(string hostName, string policyId, string appId, MAMPolicyAppIdOrGroupIdPayload parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/androidPolicies/{policyId}/apps/{appId}").ToString();
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
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
        public async Task<AzureOperationResponse> DeleteAppForAndroidMAMPolicyWithHttpMessagesAsync(string hostName, string policyId, string appId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                ServiceClientTracing.Enter(invocationId, this, "DeleteAppForAndroidMAMPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/androidPolicies/{policyId}/apps/{appId}").ToString();
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Returns groups for a given iOSMAMPolicy.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy name for the tenant
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<GroupsCollection>> GetGroupsForiOSMAMPolicyWithHttpMessagesAsync(string hostName, string policyId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                ServiceClientTracing.Enter(invocationId, this, "GetGroupsForiOSMAMPolicy", tracingParameters);
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse<GroupsCollection>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
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
        /// Returns groups for a given AndroidMAMPolicy.
        /// </summary>
        /// <param name='hostName'>
        /// Location hostName for the tenant
        /// </param>
        /// <param name='policyId'>
        /// policy name for the tenant
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<GroupsCollection>> GetGroupsForAndroidMAMPolicyWithHttpMessagesAsync(string hostName, string policyId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                ServiceClientTracing.Enter(invocationId, this, "GetGroupsForAndroidMAMPolicy", tracingParameters);
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse<GroupsCollection>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
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
        /// Add group to an iOSMAMPolicy.
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
        public async Task<AzureOperationResponse> AddGroupForiOSMAMPolicyWithHttpMessagesAsync(string hostName, string policyId, string groupId, MAMPolicyAppIdOrGroupIdPayload parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                ServiceClientTracing.Enter(invocationId, this, "AddGroupForiOSMAMPolicy", tracingParameters);
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
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
        public async Task<AzureOperationResponse> DeleteGroupForiOSMAMPolicyWithHttpMessagesAsync(string hostName, string policyId, string groupId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                ServiceClientTracing.Enter(invocationId, this, "DeleteGroupForiOSMAMPolicy", tracingParameters);
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Add group to an AndroidMAMPolicy.
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
        public async Task<AzureOperationResponse> AddGroupForAndriodPolicyWithHttpMessagesAsync(string hostName, string policyId, string groupId, MAMPolicyAppIdOrGroupIdPayload parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/androidPolicies/{policyId}/groups/{groupId}").ToString();
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
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
        public async Task<AzureOperationResponse> DeleteGroupForAndroidMAMPolicyWithHttpMessagesAsync(string hostName, string policyId, string groupId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
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
                ServiceClientTracing.Enter(invocationId, this, "DeleteGroupForAndroidMAMPolicy", tracingParameters);
            }
            // Construct URL
            var url = new Uri(this.BaseUri, "/providers/Microsoft.Intune/locations/{hostName}/androidPolicies/{policyId}/groups/{groupId}").ToString();
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
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.AcceptLanguage);
            }
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
            var result = new AzureOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

    }
}
