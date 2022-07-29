//
// Copyright (c) Microsoft.  All rights reserved.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.Models;
    using ResourceManager.Common.ArgumentCompleters;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagement"), OutputType(typeof(PsApiManagement))]
    public class NewAzureApiManagement : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of resource group under which you want to create API Management.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of API Management.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Location where want to create API Management.")]
        [LocationCompleter("Microsoft.ApiManagement/service")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "The name of the organization for use in the developer portal in e-mail notifications.")]
        [ValidateNotNullOrEmpty]
        public string Organization { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "The originating e-mail address for all e-mail notifications sent from the API Management system.")]
        [ValidateNotNullOrEmpty]
        [ValidateLength(1, 100)]
        [ValidatePattern(@"^[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)*@([a-zA-Z0-9_]+[a-zA-Z0-9_-]*\.)+[a-zA-Z]{2,63}$")]
        public string AdminEmail { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "The tier of the Azure API Management service. Valid values are Developer, Basic, Standard, Premium and Consumption. The default value is Developer. ")]
        [ValidateSet("Developer", "Basic", "Standard", "Premium", "Consumption"), PSDefaultValue(Value = "Developer")]
        public PsApiManagementSku? Sku { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Sku capacity of the Azure API Management service. This parameter is optional.")]        
        public int? Capacity { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = false,
            HelpMessage = "Virtual Network Type of the ApiManagement Deployment. Valid Values are " +
                     " - None (Default Value. ApiManagement is not part of any Virtual Network)" +
                     " - External (ApiManagement Deployment is setup inside a Virtual Network having an Internet Facing Endpoint) " +
                     " - Internal (ApiManagement Deployment is setup inside a Virtual Network having an Intranet Facing Endpoint)")]
        [ValidateSet("None", "External", "Internal"), PSDefaultValue(Value = "None")]
        public PsApiManagementVpnType VpnType { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Virtual Network Configuration of master Azure API Management deployment region. Default value is $null")]
        public PsApiManagementVirtualNetwork VirtualNetwork { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Tags dictionary.")]
        public Dictionary<string, string> Tag { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Additional deployment regions of Azure API Management.")]
        public PsApiManagementRegion[] AdditionalRegions { get; set; }
        
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Custom hostname configurations. Default value is $null. Passing $null will set the default hostname.")]
        public PsApiManagementCustomHostNameConfiguration[] CustomHostnameConfiguration { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Certificates issued by Internal CA to be installed on the service. Default value is $null.")]
        public PsApiManagementSystemCertificate[] SystemCertificateConfiguration { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "The Ssl Setting of the ApiManagement Service. Default value is $null")]
        public PsApiManagementSslSetting SslSetting { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Generate and assign an Azure Active Directory Identity for this server for use with key management services like Azure KeyVault.")]
        public SwitchParameter SystemAssignedIdentity { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Assign User Identities to this server for use with key management services like Azure KeyVault.")]
        public string[] UserAssignedIdentity { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Flag only meant to be used for Consumption SKU ApiManagement Service. " +
            "This enforces a client certificate to be presented on each request to the gateway." +
            " This also enables the ability to authenticate the certificate in the policy on the gateway.")]
        public SwitchParameter EnableClientCertificate { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A list of availability zones denoting where the api management service is deployed into.")]
        [ValidateNotNullOrEmpty]
        public string[] Zone { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag only meant to be used for Premium SKU ApiManagement Service and Non Internal VNET deployments. " +
            "This is useful in case we want to take a gateway region out of rotation." +
            " This can also be used to standup a new region in Passive mode, test it and then make it Live later." +
            "Default behavior is to make the region live immediately. ")]
        public bool? DisableGateway { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Minimal Control Plane Apis version  to allow for managing the API Management service.")]
        public string MinimalControlPlaneApiVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether or not public endpoint access is allowed for this service.Possible values include: 'Enabled', 'Disabled'")]
        [PSArgumentCompleter("Disabled", "Enabled")]
        public string PublicNetworkAccess { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Standard SKU PublicIpAddress ResoureId for integration into stv2 Virtual Network Deployments")]
        public string PublicIpAddressId { get; set; }

        public override void ExecuteCmdlet()
        {
            var apiManagementService = Client.CreateApiManagementService(
                    ResourceGroupName,
                    Name,
                    Location,
                    Organization,
                    AdminEmail,
                    Tag,
                    EnableClientCertificate.IsPresent,
                    Sku ?? PsApiManagementSku.Developer,
                    Capacity,
                    VpnType,
                    VirtualNetwork,
                    AdditionalRegions,
                    CustomHostnameConfiguration,
                    SystemCertificateConfiguration,
                    SslSetting,
                    SystemAssignedIdentity.IsPresent,
                    UserAssignedIdentity,
                    Zone,
                    DisableGateway,
                    MinimalControlPlaneApiVersion,
                    PublicNetworkAccess,
                    PublicIpAddressId);

            this.WriteObject(apiManagementService);
        }
    }
}
