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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Network
{
    public partial class NetworkClient
    {
        public INetworkManagementClient NetworkManagementClient { get; set; }

        private IAzureContext azureContext;

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        public NetworkClient(IAzureContext context)
            : this(AzureSession.Instance.ClientFactory.CreateArmClient<NetworkManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {
            azureContext = context;
        }

        public NetworkClient(INetworkManagementClient NetworkManagementClient)
        {
            this.NetworkManagementClient = NetworkManagementClient;
        }

        public NetworkClient()
        {
        }
        public string Generatevpnclientpackage(string resourceGroupName, string virtualNetworkGatewayName, VpnClientParameters parameters)
        {
            return Task.Factory.StartNew(() => GeneratevpnclientpackageAsync(resourceGroupName, virtualNetworkGatewayName, parameters)).Unwrap().GetAwaiter().GetResult();
        }

        public string GenerateVpnProfile(string resourceGroupName, string virtualNetworkGatewayName, VpnClientParameters parameters)
        {
            return Task.Factory.StartNew(() => GenerateVpnProfileAsync(resourceGroupName, virtualNetworkGatewayName, parameters)).Unwrap().GetAwaiter().GetResult();
        }

        public string GetVpnProfilePackageUrl(string resourceGroupName, string virtualNetworkGatewayName)
        {
            return Task.Factory.StartNew(() => GetVpnProfilePackageUrlAsync(resourceGroupName, virtualNetworkGatewayName)).Unwrap().GetAwaiter().GetResult();
        }

        public async Task<string> GeneratevpnclientpackageAsync(string resourceGroupName, string virtualNetworkGatewayName, VpnClientParameters parameters,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<string> result = await this.GeneratevpnclientpackageWithHttpMessagesAsync(resourceGroupName, virtualNetworkGatewayName,
                parameters, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        public async Task<string> GenerateVpnProfileAsync(string resourceGroupName, string virtualNetworkGatewayName, VpnClientParameters parameters,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<string> result = await this.GenerateVpnProfileWithHttpMessagesAsync(resourceGroupName, virtualNetworkGatewayName,
                parameters, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        public async Task<string> GetVpnProfilePackageUrlAsync(string resourceGroupName, string virtualNetworkGatewayName, CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<string> result = await this.GetVpnProfilePackageUrlWithHttpMessagesAsync(resourceGroupName,
                virtualNetworkGatewayName,
                null,
                cancellationToken).ConfigureAwait(false);

            return result.Body;
        }

        /// <summary>
        /// The Generatevpnclientpackage operation generates Vpn client package for
        /// P2S client of the virtual network gateway in the specified resource group
        /// through Network resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkGatewayName'>
        /// The name of the virtual network gateway.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Begin Generating  Virtual Network Gateway Vpn
        /// client package operation through Network resource provider.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<string>> GeneratevpnclientpackageWithHttpMessagesAsync(string resourceGroupName, string virtualNetworkGatewayName,
            VpnClientParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            #region 1. Send Async request to generate vpn client package

            // 1. Send Async request to generate vpn client package          
            string baseUrl = NetworkManagementClient.BaseUri.ToString();
            string apiVersion = "2016-12-01";

            if (resourceGroupName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "resourceGroupName");
            }
            if (virtualNetworkGatewayName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "virtualNetworkGatewayName");
            }
            if (parameters == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "parameters");
            }

            // Construct URL
            var url = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/" +
                "providers/Microsoft.Network/virtualnetworkgateways/{virtualNetworkGatewayName}/generatevpnclientpackage").ToString();
            url = url.Replace("{resourceGroupName}", Uri.EscapeDataString(resourceGroupName));
            url = url.Replace("{virtualNetworkGatewayName}", Uri.EscapeDataString(virtualNetworkGatewayName));
            url = url.Replace("{subscriptionId}", Uri.EscapeDataString(NetworkManagementClient.SubscriptionId));
            url += "?" + string.Join("&", string.Format("api-version={0}", Uri.EscapeDataString(apiVersion)));

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("POST");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());

            // Serialize Request
            string requestContent = JsonConvert.SerializeObject(parameters, NetworkManagementClient.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");

            // Set Credentials
            if (NetworkManagementClient.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await NetworkManagementClient.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            cancellationToken.ThrowIfCancellationRequested();

            var client = this.NetworkManagementClient as NetworkManagementClient;
            HttpClient httpClient = client.HttpClient;
            HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);

            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if ((int)statusCode != 202)
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                throw new Exception(string.Format("Get-AzVpnClientPackage Operation returned an invalid status code '{0}' with Exception:{1}",
                    statusCode, string.IsNullOrEmpty(responseContent) ? "NotAvailable" : responseContent));
            }

            // Create Result
            var result = new AzureOperationResponse<string>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            string locationResultsUrl = string.Empty;

            // Retrieve the location from LocationUri
            if (httpResponse.Headers.Contains("Location"))
            {
                locationResultsUrl = httpResponse.Headers.GetValues("Location").FirstOrDefault();
            }
            else
            {
                throw new Exception(string.Format("Get-AzVpnClientPackage Operation Failed as no valid Location header received in response!"));
            }

            if (string.IsNullOrEmpty(locationResultsUrl))
            {
                throw new Exception(string.Format("Get-AzVpnClientPackage Operation Failed as no valid Location header value received in response!"));
            }
            #endregion

            #region 2. Wait for Async operation to succeed and then Get the content i.e. VPN Client package Url from locationResults
            //Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport.Delay(60000);

            // 2. Wait for Async operation to succeed           
            DateTime startTime = DateTime.UtcNow;
            DateTime giveUpAt = DateTime.UtcNow.AddMinutes(3);

            // Send the Get locationResults request for operaitonId till either we get StatusCode 200 or it time outs (3 minutes in this case)
            while (true)
            {
                HttpRequestMessage newHttpRequest = new HttpRequestMessage();
                newHttpRequest.Method = new HttpMethod("GET");
                newHttpRequest.RequestUri = new Uri(locationResultsUrl);

                if (NetworkManagementClient.Credentials != null)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await NetworkManagementClient.Credentials.ProcessHttpRequestAsync(newHttpRequest, cancellationToken).ConfigureAwait(false);
                }

                HttpResponseMessage newHttpResponse = await httpClient.SendAsync(newHttpRequest, cancellationToken).ConfigureAwait(false);

                if ((int)newHttpResponse.StatusCode != 200)
                {
                    if (DateTime.UtcNow > giveUpAt)
                    {
                        string newResponseContent = await newHttpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                        throw new Exception(string.Format("Get-AzVpnClientPackage Operation returned an invalid status code '{0}' with Exception:{1} while retrieving " +
                            "the VpnClient PackageUrl!", newHttpResponse.StatusCode, string.IsNullOrEmpty(newResponseContent) ? "NotAvailable" : newResponseContent));
                    }
                    else
                    {
                        // Wait for 15 seconds before retrying
                        Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport.Delay(15000);
                    }
                }
                else
                {
                    // Get the content i.e.VPN Client package Url from locationResults
                    result.Body = newHttpResponse.Content.ReadAsStringAsync().Result;
                    return result;
                }
            }
            #endregion
        }

        /// <summary>
        /// The Generatevpnclientpackage operation generates Vpn client package for
        /// P2S client of the virtual network gateway in the specified resource group
        /// through Network resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualNetworkGatewayName'>
        /// The name of the virtual network gateway.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Begin Generating  Virtual Network Gateway Vpn
        /// client package operation through Network resource provider.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<string>> GenerateVpnProfileWithHttpMessagesAsync(string resourceGroupName, string virtualNetworkGatewayName,
            VpnClientParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            #region Send Async request to generate vpn profile

            // 1. Send Async request to generate vpn client package          
            string baseUrl = NetworkManagementClient.BaseUri.ToString();
            string apiVersion = "2017-06-01";

            if (resourceGroupName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "resourceGroupName");
            }
            if (virtualNetworkGatewayName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "virtualNetworkGatewayName");
            }
            if (parameters == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "parameters");
            }

            // Construct URL
            var url = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/" +
                                                                                     "providers/Microsoft.Network/virtualnetworkgateways/{virtualNetworkGatewayName}/generatevpnprofile").ToString();
            url = url.Replace("{resourceGroupName}", Uri.EscapeDataString(resourceGroupName));
            url = url.Replace("{virtualNetworkGatewayName}", Uri.EscapeDataString(virtualNetworkGatewayName));
            url = url.Replace("{subscriptionId}", Uri.EscapeDataString(NetworkManagementClient.SubscriptionId));
            url += "?" + string.Join("&", string.Format("api-version={0}", Uri.EscapeDataString(apiVersion)));

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("POST");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());

            // Serialize Request
            string requestContent = JsonConvert.SerializeObject(parameters, NetworkManagementClient.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");

            // Set Credentials
            if (NetworkManagementClient.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await NetworkManagementClient.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            cancellationToken.ThrowIfCancellationRequested();

            var client = this.NetworkManagementClient as NetworkManagementClient;
            HttpClient httpClient = client.HttpClient;
            HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);

            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if ((int)statusCode != 202)
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                throw new Exception(string.Format("Get-AzVpnClientPackage Operation returned an invalid status code '{0}' with Exception:{1}",
                    statusCode, string.IsNullOrEmpty(responseContent) ? "NotAvailable" : responseContent));
            }

            // Create Result
            var result = new AzureOperationResponse<string>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            string locationResultsUrl = string.Empty;

            // Retrieve the location from LocationUri
            if (httpResponse.Headers.Contains("Location"))
            {
                locationResultsUrl = httpResponse.Headers.GetValues("Location").FirstOrDefault();
            }
            else
            {
                throw new Exception(string.Format("Get-AzVpnClientConfiguration Operation Failed as no valid Location header received in response!"));
            }

            if (string.IsNullOrEmpty(locationResultsUrl))
            {
                throw new Exception(string.Format("Get-AzVpnClientConfiguration Operation Failed as no valid Location header value received in response!"));
            }
            #endregion

            #region Wait for Async operation to succeed and then Get the content i.e. VPN Client package Url from locationResults
            //Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport.Delay(60000);
            DateTime startTime = DateTime.UtcNow;
            DateTime giveUpAt = DateTime.UtcNow.AddMinutes(3);

            // Send the Get locationResults request for operaitonId till either we get StatusCode 200 or it time outs (3 minutes in this case)
            while (true)
            {
                HttpRequestMessage newHttpRequest = new HttpRequestMessage();
                newHttpRequest.Method = new HttpMethod("GET");
                newHttpRequest.RequestUri = new Uri(locationResultsUrl);

                if (NetworkManagementClient.Credentials != null)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await NetworkManagementClient.Credentials.ProcessHttpRequestAsync(newHttpRequest, cancellationToken).ConfigureAwait(false);
                }

                HttpResponseMessage newHttpResponse = await httpClient.SendAsync(newHttpRequest, cancellationToken).ConfigureAwait(false);

                if ((int)newHttpResponse.StatusCode != 200)
                {
                    if (DateTime.UtcNow > giveUpAt)
                    {
                        string newResponseContent = await newHttpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                        throw new Exception(string.Format("Get-AzVpnClientPackage Operation returned an invalid status code '{0}' with Exception:{1} while retrieving " +
                                                          "the VpnClient PackageUrl!", newHttpResponse.StatusCode, string.IsNullOrEmpty(newResponseContent) ? "NotAvailable" : newResponseContent));
                    }
                    else
                    {
                        // Wait for 30 seconds before retrying
                        Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport.Delay(30000);
                    }
                }
                else
                {
                    // Get the content i.e.VPN Client package Url from locationResults
                    result.Body = newHttpResponse.Content.ReadAsStringAsync().Result;
                    return result;
                }
            }
            #endregion
        }

        /// <summary>
        /// Gets pre-generated vpn profile package SAS URL
        /// </summary>
        /// <param name="resourceGroupName">
        /// Resource Group Name
        /// </param>
        /// <param name="virtualNetworkGatewayName">
        /// Virtual Network Gateway Name
        /// </param>
        /// <param name="customHeaders">
        /// Custom Headers
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation Token
        /// </param>
        /// <returns></returns>
        public async Task<AzureOperationResponse<string>> GetVpnProfilePackageUrlWithHttpMessagesAsync(string resourceGroupName, string virtualNetworkGatewayName,
            Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            #region Send Async request to get vpn profile package url

            // 1. Send Async request to generate vpn client package          
            string baseUrl = NetworkManagementClient.BaseUri.ToString();
            string apiVersion = "2017-06-01";

            if (resourceGroupName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "resourceGroupName");
            }
            if (virtualNetworkGatewayName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "virtualNetworkGatewayName");
            }

            // Construct URL
            var url = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/" +
                                                                                     "providers/Microsoft.Network/virtualnetworkgateways/{virtualNetworkGatewayName}/getvpnprofilepackageurl").ToString();
            url = url.Replace("{resourceGroupName}", Uri.EscapeDataString(resourceGroupName));
            url = url.Replace("{virtualNetworkGatewayName}", Uri.EscapeDataString(virtualNetworkGatewayName));
            url = url.Replace("{subscriptionId}", Uri.EscapeDataString(NetworkManagementClient.SubscriptionId));
            url += "?" + string.Join("&", string.Format("api-version={0}", Uri.EscapeDataString(apiVersion)));

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("POST");
            httpRequest.RequestUri = new Uri(url);

            // Set Headers
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());

            // Set Credentials
            if (NetworkManagementClient.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await NetworkManagementClient.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            cancellationToken.ThrowIfCancellationRequested();

            var client = this.NetworkManagementClient as NetworkManagementClient;
            HttpClient httpClient = client.HttpClient;
            HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);

            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if ((int)statusCode != 202)
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                throw new Exception(string.Format("Get-AzVpnClientPackage Operation returned an invalid status code '{0}' with Exception:{1}",
                    statusCode, string.IsNullOrEmpty(responseContent) ? "NotAvailable" : responseContent));
            }

            // Create Result
            var result = new AzureOperationResponse<string>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            string locationResultsUrl = string.Empty;

            // Retrieve the location from LocationUri
            if (httpResponse.Headers.Contains("Location"))
            {
                locationResultsUrl = httpResponse.Headers.GetValues("Location").FirstOrDefault();
            }
            else
            {
                throw new Exception(string.Format("Get-AzVpnClientConfiguration Operation Failed as no valid Location header received in response!"));
            }

            if (string.IsNullOrEmpty(locationResultsUrl))
            {
                throw new Exception(string.Format("Get-AzVpnClientConfiguration Operation Failed as no valid Location header value received in response!"));
            }
            #endregion

            #region Wait for Async operation to succeed and then Get the content i.e. VPN Client package Url from locationResults
            //Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport.Delay(60000);
            DateTime startTime = DateTime.UtcNow;
            DateTime giveUpAt = DateTime.UtcNow.AddMinutes(3);

            // Send the Get locationResults request for operaitonId till either we get StatusCode 200 or it time outs (3 minutes in this case)
            while (true)
            {
                HttpRequestMessage newHttpRequest = new HttpRequestMessage();
                newHttpRequest.Method = new HttpMethod("GET");
                newHttpRequest.RequestUri = new Uri(locationResultsUrl);

                if (NetworkManagementClient.Credentials != null)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await NetworkManagementClient.Credentials.ProcessHttpRequestAsync(newHttpRequest, cancellationToken).ConfigureAwait(false);
                }

                HttpResponseMessage newHttpResponse = await httpClient.SendAsync(newHttpRequest, cancellationToken).ConfigureAwait(false);

                if ((int)newHttpResponse.StatusCode != 200)
                {
                    if (DateTime.UtcNow > giveUpAt)
                    {
                        string newResponseContent = await newHttpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                        throw new Exception(string.Format("Get-AzVpnClientPackage Operation returned an invalid status code '{0}' with Exception:{1} while retrieving " +
                                                          "the VpnClient PackageUrl!", newHttpResponse.StatusCode, string.IsNullOrEmpty(newResponseContent) ? "NotAvailable" : newResponseContent));
                    }
                    else
                    {
                        // Wait for 30 seconds before retrying
                        Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport.Delay(30000);
                    }
                }
                else
                {
                    // Get the content i.e.VPN Client package Url from locationResults
                    result.Body = newHttpResponse.Content.ReadAsStringAsync().Result;
                    return result;
                }
            }
            #endregion
        }

        #region Virtual Wan APIs

        public string GetVirtualWanVpnServerConfigurations(string resourceGroupName, string virtualWanName)
        {
            return Task.Factory.StartNew(() => GetVirtualWanVpnServerConfigurationsAsync(resourceGroupName, virtualWanName)).Unwrap().GetAwaiter().GetResult();
        }

        public async Task<string> GetVirtualWanVpnServerConfigurationsAsync(string resourceGroupName, string virtualWanName,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            string baseUrl = NetworkManagementClient.BaseUri.ToString();
            string apiVersion = "2019-08-01";

            // Construct URL
            var url = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/" +
                                                                                     "providers/Microsoft.Network/virtualWans/{virtualWanName}/vpnServerConfigurations").ToString();
            url = url.Replace("{resourceGroupName}", Uri.EscapeDataString(resourceGroupName));
            url = url.Replace("{virtualWanName}", Uri.EscapeDataString(virtualWanName));
            url = url.Replace("{subscriptionId}", Uri.EscapeDataString(NetworkManagementClient.SubscriptionId));
            url += "?" + string.Join("&", string.Format("api-version={0}", Uri.EscapeDataString(apiVersion)));

            AzureOperationResponse<string> result = await this.ExecuteOperationWithHttpMessagesAsync(resourceGroupName, virtualWanName, null, url, apiVersion, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        public string GenerateVirtualWanVpnProfile(string resourceGroupName, string virtualWanName, VirtualWanVpnProfileParameters parameters)
        {
            return Task.Factory.StartNew(() => GenerateVirtualWanVpnProfileAsync(resourceGroupName, virtualWanName, parameters)).Unwrap().GetAwaiter().GetResult();
        }

        public async Task<string> GenerateVirtualWanVpnProfileAsync(string resourceGroupName, string virtualWanName, VirtualWanVpnProfileParameters parameters,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            string baseUrl = NetworkManagementClient.BaseUri.ToString();
            string apiVersion = "2019-08-01";

            // Construct URL
            var url = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/" +
                                                                                     "providers/Microsoft.Network/virtualWans/{virtualWanName}/generatevpnprofile").ToString();
            url = url.Replace("{resourceGroupName}", Uri.EscapeDataString(resourceGroupName));
            url = url.Replace("{virtualWanName}", Uri.EscapeDataString(virtualWanName));
            url = url.Replace("{subscriptionId}", Uri.EscapeDataString(NetworkManagementClient.SubscriptionId));
            url += "?" + string.Join("&", string.Format("api-version={0}", Uri.EscapeDataString(apiVersion)));

            if (parameters == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "parameters");
            }

            AzureOperationResponse<string> result = await this.ExecuteOperationWithHttpMessagesAsync(resourceGroupName, virtualWanName, parameters, url, apiVersion, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        public string GetP2SVpnGatewayConnectionHealth(string resourceGroupName, string p2sVpnGatewayName)
        {            
            string result =  Task.Factory.StartNew(() => GetP2SVpnGatewayConnectionHealthAsync(resourceGroupName, p2sVpnGatewayName)).Unwrap().GetAwaiter().GetResult();
            return result;
        }

        public async Task<string> GetP2SVpnGatewayConnectionHealthAsync(string resourceGroupName, string p2sVpnGatewayName,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            string baseUrl = NetworkManagementClient.BaseUri.ToString();
            string apiVersion = "2019-08-01";

            // Construct URL
            var url = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/" +
                                                                                     "providers/Microsoft.Network/p2sVpnGateways/{p2sVpnGatewayName}/getp2svpnconnectionhealth").ToString();
            url = url.Replace("{resourceGroupName}", Uri.EscapeDataString(resourceGroupName));
            url = url.Replace("{p2sVpnGatewayName}", Uri.EscapeDataString(p2sVpnGatewayName));
            url = url.Replace("{subscriptionId}", Uri.EscapeDataString(NetworkManagementClient.SubscriptionId));
            url += "?" + string.Join("&", string.Format("api-version={0}", Uri.EscapeDataString(apiVersion)));

            AzureOperationResponse<string> result = await this.ExecuteOperationWithHttpMessagesAsync(resourceGroupName, p2sVpnGatewayName, null, url, apiVersion, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        public string GetP2SVpnGatewayDetailedConnectionHealth(string resourceGroupName, string p2sVpnGatewayName, P2SVpnConnectionHealthRequest parameters)
        {
            return Task.Factory.StartNew(() => GetP2SVpnGatewayDetailedConnectionHealthAsync(resourceGroupName, p2sVpnGatewayName, parameters)).Unwrap().GetAwaiter().GetResult();
        }

        public async Task<string> GetP2SVpnGatewayDetailedConnectionHealthAsync(string resourceGroupName, string p2sVpnGatewayName, P2SVpnConnectionHealthRequest parameters,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            string baseUrl = NetworkManagementClient.BaseUri.ToString();
            string apiVersion = "2019-08-01";

            // Construct URL
            var url = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/" +
                                                                                     "providers/Microsoft.Network/p2sVpnGateways/{p2sVpnGatewayName}/getp2svpnconnectionhealthdetailed").ToString();
            url = url.Replace("{resourceGroupName}", Uri.EscapeDataString(resourceGroupName));
            url = url.Replace("{p2sVpnGatewayName}", Uri.EscapeDataString(p2sVpnGatewayName));
            url = url.Replace("{subscriptionId}", Uri.EscapeDataString(NetworkManagementClient.SubscriptionId));
            url += "?" + string.Join("&", string.Format("api-version={0}", Uri.EscapeDataString(apiVersion)));

            if (parameters == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "parameters");
            }

            AzureOperationResponse<string> result = await this.ExecuteOperationWithHttpMessagesAsync(resourceGroupName, p2sVpnGatewayName, parameters, url, apiVersion, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        public string GenerateP2SVpnGatewayVpnProfile(string resourceGroupName, string p2sVpnGatewayName, P2SVpnProfileParameters parameters)
        {
            return Task.Factory.StartNew(() => GenerateP2SVpnGatewayVpnProfileAsync(resourceGroupName, p2sVpnGatewayName, parameters)).Unwrap().GetAwaiter().GetResult();
        }

        public async Task<string> GenerateP2SVpnGatewayVpnProfileAsync(string resourceGroupName, string p2sVpnGatewayName, P2SVpnProfileParameters parameters,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            string baseUrl = NetworkManagementClient.BaseUri.ToString();
            string apiVersion = "2019-08-01";

            // Construct URL
            var url = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/" +
                                                                                     "providers/Microsoft.Network/p2sVpnGateways/{p2sVpnGatewayName}/generatevpnprofile").ToString();
            url = url.Replace("{resourceGroupName}", Uri.EscapeDataString(resourceGroupName));
            url = url.Replace("{p2sVpnGatewayName}", Uri.EscapeDataString(p2sVpnGatewayName));
            url = url.Replace("{subscriptionId}", Uri.EscapeDataString(NetworkManagementClient.SubscriptionId));
            url += "?" + string.Join("&", string.Format("api-version={0}", Uri.EscapeDataString(apiVersion)));

            if (parameters == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "parameters");
            }

            AzureOperationResponse<string> result = await this.ExecuteOperationWithHttpMessagesAsync(resourceGroupName, p2sVpnGatewayName, parameters, url, apiVersion, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// The network operation in the specified resource group through Network resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='resourceName'>
        /// The name of the resource.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Begin the operation through Network resource provider.
        /// </param>
        /// <param name="apiUrl">
        /// The api URL of the resource.
        /// </param>
        /// <param name="apiVersion">
        /// The api version of the resource.
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<string>> ExecuteOperationWithHttpMessagesAsync(string resourceGroupName, string resourceName,
            object parameters, string apiUrl, string apiVersion, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            #region Send Async request to generate p2s vpn gateway vpn profile

            // 1. Send Async request to generate virtual wan vpn profile        
            if (string.IsNullOrWhiteSpace(apiUrl))
            {
                apiVersion = "2019-08-01";
            }
            if (resourceGroupName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "resourceGroupName");
            }
            if (resourceName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "resourceName");
            }
            if (string.IsNullOrWhiteSpace(apiUrl))
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "apiUrl");
            }

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("POST");
            httpRequest.RequestUri = new Uri(apiUrl);
            // Set Headers
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());

            // Serialize Request
            string requestContent = JsonConvert.SerializeObject(parameters, NetworkManagementClient.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");

            // Set Credentials
            if (NetworkManagementClient.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await NetworkManagementClient.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            cancellationToken.ThrowIfCancellationRequested();

            var client = this.NetworkManagementClient as NetworkManagementClient;
            HttpClient httpClient = client.HttpClient;
            HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);

            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if ((int)statusCode != 202)
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                throw new Exception(string.Format("Operation returned an invalid status code '{0}' with Exception:{1}",
                    statusCode, string.IsNullOrEmpty(responseContent) ? "NotAvailable" : responseContent));
            }

            // Create Result
            var result = new AzureOperationResponse<string>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            string locationResultsUrl = string.Empty;

            // Retrieve the location from LocationUri
            if (httpResponse.Headers.Contains("Location"))
            {
                locationResultsUrl = httpResponse.Headers.GetValues("Location").FirstOrDefault();
            }
            else
            {
                throw new Exception(string.Format("Operation Failed as no valid Location header received in response!"));
            }

            if (string.IsNullOrEmpty(locationResultsUrl))
            {
                throw new Exception(string.Format("Operation Failed as no valid Location header value received in response!"));
            }

            #endregion

            #region Wait for Async operation to succeed and then Get the content from locationResults
            //Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport.Delay(60000);
            DateTime startTime = DateTime.UtcNow;
            DateTime giveUpAt = DateTime.UtcNow.AddMinutes(3);

            // Send the Get locationResults request for operaitonId till either we get StatusCode 200 or it time outs (3 minutes in this case)
            while (true)
            {
                HttpRequestMessage newHttpRequest = new HttpRequestMessage();
                newHttpRequest.Method = new HttpMethod("GET");
                newHttpRequest.RequestUri = new Uri(locationResultsUrl);

                if (NetworkManagementClient.Credentials != null)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await NetworkManagementClient.Credentials.ProcessHttpRequestAsync(newHttpRequest, cancellationToken).ConfigureAwait(false);
                }

                HttpResponseMessage newHttpResponse = await httpClient.SendAsync(newHttpRequest, cancellationToken).ConfigureAwait(false);

                if ((int)newHttpResponse.StatusCode != 200)
                {
                    if (DateTime.UtcNow > giveUpAt)
                    {
                        string newResponseContent = await newHttpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new Exception(string.Format("Operation returned an invalid status code '{0}' with Exception:'{1}' while retrieving " +
                                                          " the content '{2}'!", newHttpResponse.StatusCode, string.IsNullOrEmpty(newResponseContent) ? "NotAvailable" : newResponseContent));
                    }
                    else
                    {
                        // Wait for 30 seconds before retrying
                        Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport.Delay(30000);
                    }
                }
                else
                {
                    // Get the content from locationResults
                    result.Body = newHttpResponse.Content.ReadAsStringAsync().Result;
                    return result;
                }
            }
            #endregion
        }

        #endregion
    }
}