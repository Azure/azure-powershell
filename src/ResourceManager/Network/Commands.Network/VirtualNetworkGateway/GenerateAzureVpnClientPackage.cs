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
using System.Management.Automation;
using AutoMapper;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Resources.Models;
using MNM = Microsoft.Azure.Management.Network.Models;
using System.Collections;
using Microsoft.Azure.Commands.Tags.Model;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest;
using Microsoft.Azure.Common.Authentication;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Azure.Management.Internal.Resources.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmVpnClientPackage"), OutputType(typeof(string))]
    public class GetAzureVpnClientPackage : VirtualNetworkGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "ResourceGroup name")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "VirtualNetworkGateway name")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkGatewayName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "ProcessorArchitecture")]
        [ValidateSet(
        MNM.ProcessorArchitecture.Amd64,
        MNM.ProcessorArchitecture.X86,
        IgnoreCase = true)]
        public string ProcessorArchitecture { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!this.IsVirtualNetworkGatewayPresent(ResourceGroupName, VirtualNetworkGatewayName))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            PSVpnClientParameters vpnClientParams = new PSVpnClientParameters();
            vpnClientParams.ProcessorArchitecture = this.ProcessorArchitecture;
            var vnetVpnClientParametersModel = Mapper.Map<MNM.VpnClientParameters>(vpnClientParams);

            //TODO:- This code is added just for current release of P2S feature as Generatevpnclientpackage API is broken & need to be fixed on server side as well as in overall Poweshell flow
            //string packageUrl = this.VirtualNetworkGatewayClient.Generatevpnclientpackage(ResourceGroupName, VirtualNetworkGatewayName, vnetVpnClientParametersModel);
            string packageUrl = Generatevpnclientpackage(ResourceGroupName, VirtualNetworkGatewayName, vnetVpnClientParametersModel);

            WriteObject(packageUrl);
        }

        public string Generatevpnclientpackage(string resourceGroupName, string virtualNetworkGatewayName, VpnClientParameters parameters)
        {
            return Task.Factory.StartNew(() => GeneratevpnclientpackageAsync(resourceGroupName, virtualNetworkGatewayName, parameters)).Unwrap().GetAwaiter().GetResult();
        }

        public async Task<string> GeneratevpnclientpackageAsync(string resourceGroupName, string virtualNetworkGatewayName, VpnClientParameters parameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<string> result = await this.GeneratevpnclientpackageWithHttpMessagesAsync(resourceGroupName, virtualNetworkGatewayName, parameters, null, cancellationToken).ConfigureAwait(false);
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
        public async Task<AzureOperationResponse<string>> GeneratevpnclientpackageWithHttpMessagesAsync(string resourceGroupName, string virtualNetworkGatewayName, VpnClientParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            #region 1. Send Async request to generate vpn client package

            // 1. Send Async request to generate vpn client package          
            string baseUrl = this.NetworkClient.NetworkManagementClient.BaseUri.ToString();
            string apiVersion = this.NetworkClient.NetworkManagementClient.ApiVersion;

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
            var url = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualnetworkgateways/{virtualNetworkGatewayName}/generatevpnclientpackage").ToString();
            url = url.Replace("{resourceGroupName}", Uri.EscapeDataString(resourceGroupName));
            url = url.Replace("{virtualNetworkGatewayName}", Uri.EscapeDataString(virtualNetworkGatewayName));
            url = url.Replace("{subscriptionId}", Uri.EscapeDataString(this.NetworkClient.NetworkManagementClient.SubscriptionId));
            url += "?" + string.Join("&", string.Format("api-version={0}", Uri.EscapeDataString(apiVersion)));

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("POST");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());

            // Serialize Request
            string requestContent = JsonConvert.SerializeObject(parameters, this.NetworkClient.NetworkManagementClient.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");

            // Set Credentials
            if (this.NetworkClient.NetworkManagementClient.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.NetworkClient.NetworkManagementClient.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            cancellationToken.ThrowIfCancellationRequested();
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);

            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if ((int)statusCode != 202)
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                throw new Exception(string.Format("Get-AzureRmVpnClientPackage Operation returned an invalid status code '{0}' with Exception:{1}",
                    statusCode, string.IsNullOrEmpty(responseContent) ? "NotAvailable" : responseContent));
            }

            // Create Result
            var result = new AzureOperationResponse<string>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            else
            {
                throw new Exception(string.Format("Get-AzureRmVpnClientPackage Operation Failed as no valid status code received in response!"));
            }

            string operationId = result.RequestId;
            #endregion

            #region 2. Wait for Async operation to succeed 

            Thread.Sleep(TimeSpan.FromSeconds(60));

            // 2. Wait for Async operation to succeed           
            var locationResultsUrl = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")), "subscriptions/{subscriptionId}/providers/Microsoft.Network/locations/westus.validation/operationResults/{operationId}").ToString();
            locationResultsUrl = locationResultsUrl.Replace("{operationId}", Uri.EscapeDataString(operationId));
            locationResultsUrl = locationResultsUrl.Replace("{subscriptionId}", Uri.EscapeDataString(this.NetworkClient.NetworkManagementClient.SubscriptionId));
            locationResultsUrl += "?" + string.Join("&", string.Format("api-version={0}", Uri.EscapeDataString(apiVersion)));
            HttpRequestMessage newHttpRequest = new HttpRequestMessage();
            newHttpRequest.Method = new HttpMethod("GET");
            newHttpRequest.RequestUri = new Uri(locationResultsUrl);

            if (this.NetworkClient.NetworkManagementClient.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.NetworkClient.NetworkManagementClient.Credentials.ProcessHttpRequestAsync(newHttpRequest, cancellationToken).ConfigureAwait(false);
            }
            HttpResponseMessage newHttpResponse = await httpClient.SendAsync(newHttpRequest, cancellationToken).ConfigureAwait(false);

            if ((int)newHttpResponse.StatusCode != 200)
            {
                if (!string.IsNullOrEmpty(newHttpResponse.Content.ReadAsStringAsync().Result))
                {
                    result.Body = newHttpResponse.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    string newResponseContent = await newHttpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    throw new Exception(string.Format("Get-AzureRmVpnClientPackage Operation returned an invalid status code '{0}' with Exception:{1} while retrieving the Vpnclient PackageUrl!",
                        newHttpResponse.StatusCode, string.IsNullOrEmpty(newResponseContent) ? "NotAvailable" : newResponseContent));
                }
            }
            #endregion

            #region 3. Get the content i.e. VPN Client package Url from locationResults

            // 3. Get the content i.e. VPN Client package Url from locationResults
            result.Body = newHttpResponse.Content.ReadAsStringAsync().Result;
            return result;
            #endregion

        }
    }
}

