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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
// TODO: Remove IfDef
#if NETSTANDARD
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
#endif
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Newtonsoft.Json;
using Microsoft.Rest.Azure;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.Linq;
using Microsoft.Rest;
using SerializationException = Microsoft.Rest.SerializationException;
using Microsoft.Rest.Serialization;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Fabric discovery Http endpoints.
    /// </summary>
    public enum PSAsrFabricDiscoveryEndpoints
    {
        /// <summary>
        ///     Run as accounts endpoint.
        /// </summary>
        runasaccounts,

        /// <summary>
        ///     Discovered machines endpoint.
        /// </summary>
        machines
    }

    /// <summary>
    ///     Recovery services convenience client.
    /// </summary>
    public partial class PSAsrFabricDiscoveryClient
    {
        /// <summary>
        ///     Azure context.
        /// </summary>
        private static AzureContext AzureContext;

        /// <summary>
        ///     End point Uri.
        /// </summary>
        private static Uri endPointUri;

        /// <summary>
        ///     Http client.
        /// </summary>
        private static readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        ///     Api version.
        /// </summary>
        private static readonly string ApiVersion = "2020-01-01";

        /// <summary>
        ///     ARM resource path for VMware sites.
        /// </summary>
        private static readonly string VMwareSitePath =
            "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.OffAzure/VMwareSites/{2}";

        /// <summary>
        ///     Initializes a new instance of the <see cref="PSAsrFabricDiscoveryClient" /> class.
        /// </summary>
        /// <param name="azureProfile">Azure context.</param>
        public PSAsrFabricDiscoveryClient(IAzureContextContainer azureProfile)
        {
            AzureContext = (AzureContext)azureProfile.DefaultContext;
            if (endPointUri == null)
            {
                endPointUri =
                    azureProfile.DefaultContext.Environment.GetEndpointAsUri(
                        AzureEnvironment.Endpoint.ResourceManager);
            }

            this.DeserializationSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter(),
                        new PolymorphicDeserializeJsonConverter<VMwareRunAsAccount>("type"),
                        new PolymorphicDeserializeJsonConverter<VMwareMachine>("type")
                    }

            };
        }

        /// <summary>
        ///     Client request Id.
        /// </summary>
        public string ClientRequestId { get; set; }

        /// <summary>
        ///     Json deserialization settings.
        /// </summary>
        public JsonSerializerSettings DeserializationSettings { get; private set; }

        /// <summary>
        ///     Gets Azure Site Recovery RunAsAccounts.
        /// </summary>
        /// <param name="siteId">Site Id.</param>
        /// <returns>The list of run as accounts.</returns>
        public List<VMwareRunAsAccount> GetAzureSiteRecoveryRunAsAccounts(string siteId)
        {
            var firstPage =
                this.ListWithHttpMessagesAsync<VMwareRunAsAccount>(
                    siteId,
                    nameof(PSAsrFabricDiscoveryEndpoints.runasaccounts))
                .GetAwaiter()
                .GetResult()
                .Body;

            var pages = Utilities.GetNextPages(
                this.ListNextWithHttpMessagesAsync<VMwareRunAsAccount>,
                firstPage.NextPageLink);

            pages.Insert(0, firstPage);
            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Gets Azure Site Recovery discovered machine details.
        /// </summary>
        /// <param name="siteId">Site Id.</param>
        /// <returns>The list of discovered machines.</returns>
        public List<VMwareMachine> GetAzureSiteRecoveryDiscoveredMachines(string siteId)
        {
            var firstPage =
                this.ListWithHttpMessagesAsync<VMwareMachine>(
                    siteId,
                    nameof(PSAsrFabricDiscoveryEndpoints.machines))
                .GetAwaiter()
                .GetResult()
                .Body;

            var pages = Utilities.GetNextPages(
                this.ListNextWithHttpMessagesAsync<VMwareMachine>,
                firstPage.NextPageLink);

            pages.Insert(0, firstPage);
            return Utilities.IpageToList(pages);
        }

        #region private methods

        /// <summary>
        /// Gets the list of items of type T.
        /// </summary>
        /// <typeparam name="T">The input type.</typeparam>
        /// <param name="siteId">The fabric discovery site Id.</param>
        /// <param name="httpMethodUri">The endpoint URI.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The Azure operation response.</returns>
        private async Task<AzureOperationResponse<IPage<T>>> ListWithHttpMessagesAsync<T>(
            string siteId,
            string httpMethodUri,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(siteId))
            {
                throw new InvalidOperationException(Resources.SiteNotFound);
            }

            if (!siteId.IsValidArmId(VMwareSitePath))
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.SiteNotValid,
                        siteId));
            }

            // Construct URL
            var baseUrl = endPointUri.AbsoluteUri;
            var relativeUri = $"{siteId}/{httpMethodUri}?api-version={ApiVersion}";
            var uri = new Uri(
                new Uri(baseUrl.TrimEnd('/')),
                new Uri(relativeUri, UriKind.Relative));

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = uri
            };

            // Set Headers
            this.ClientRequestId =
                Guid.NewGuid() + "-" +
                DateTime.UtcNow.ToString(Constants.UtcDateTimeFormat) + 
                Constants.FabricDiscoveryClientRequestIdSuffix;
            httpRequest.Headers.TryAddWithoutValidation(HttpHeaders.ClientRequestId, this.ClientRequestId);

            if (httpRequest.Headers.Contains(HttpHeaders.AcceptLanguage))
            {
                httpRequest.Headers.Remove(HttpHeaders.AcceptLanguage);
            }
            httpRequest.Headers.TryAddWithoutValidation(HttpHeaders.AcceptLanguage, "en-US");

            // Set Credentials
            var creds =
                AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(AzureContext);
            if (creds != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await creds.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Send Request
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse =
                await httpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            string responseContent =
                await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new CloudException(
                    $"Operation returned an invalid status code '{httpResponse.StatusCode}' " +
                    $"with exception: {responseContent}");
            }

            // Create Result
            var result = new AzureOperationResponse<IPage<T>>
            {
                Request = httpRequest,
                Response = httpResponse
            };

            if (httpResponse.Headers.Contains(HttpHeaders.RequestId))
            {
                result.RequestId = httpResponse.Headers.GetValues(HttpHeaders.RequestId).FirstOrDefault();
            }

            try
            {
                result.Body = SafeJsonConvert.DeserializeObject<Page<T>>(
                    responseContent,
                    this.DeserializationSettings);
            }
            catch (JsonException ex)
            {
                httpRequest.Dispose();
                if (httpResponse != null)
                {
                    httpResponse.Dispose();
                }
                throw new SerializationException(
                    $"Unable to deserialize the response: {responseContent}",
                    ex);
            }

            return result;
        }

        /// <summary>
        /// Gets the list of items of type T.
        /// </summary>
        /// <typeparam name="T">The input type.</typeparam>
        /// <param name="nextPageLink">The next page link.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The Azure operation response.</returns>
        private async Task<AzureOperationResponse<IPage<T>>> ListNextWithHttpMessagesAsync<T>(
            string nextPageLink,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (nextPageLink == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, Constants.NextPageLink);
            }

            // Construct URL
            var uri = new Uri(nextPageLink);

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = uri;

            // Set Headers
            this.ClientRequestId =
                Guid.NewGuid() + "-" +
                DateTime.UtcNow.ToString(Constants.UtcDateTimeFormat) +
                Constants.FabricDiscoveryClientRequestIdSuffix;
            httpRequest.Headers.TryAddWithoutValidation(HttpHeaders.ClientRequestId, this.ClientRequestId);

            if (httpRequest.Headers.Contains(HttpHeaders.AcceptLanguage))
            {
                httpRequest.Headers.Remove(HttpHeaders.AcceptLanguage);
            }
            httpRequest.Headers.TryAddWithoutValidation(HttpHeaders.AcceptLanguage, "en-US");

            // Set Credentials
            var creds =
                AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(AzureContext);
            if (creds != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await creds.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Send Request
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse =
                await httpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            string responseContent =
                await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new CloudException(
                    $"Operation returned an invalid status code '{httpResponse.StatusCode}' " +
                    $"with exception: {responseContent}");
            }

            // Create Result
            var result = new AzureOperationResponse<IPage<T>>
            {
                Request = httpRequest,
                Response = httpResponse
            };

            if (httpResponse.Headers.Contains(HttpHeaders.RequestId))
            {
                result.RequestId = httpResponse.Headers.GetValues(HttpHeaders.RequestId).FirstOrDefault();
            }

            try
            {
                result.Body = SafeJsonConvert.DeserializeObject<Page<T>>(
                    responseContent,
                    this.DeserializationSettings);
            }
            catch (JsonException ex)
            {
                httpRequest.Dispose();
                if (httpResponse != null)
                {
                    httpResponse.Dispose();
                }
                throw new SerializationException(
                    $"Unable to deserialize the response: {responseContent}",
                    ex);
            }

            return result;
        }

        #endregion private methods
    }
}
