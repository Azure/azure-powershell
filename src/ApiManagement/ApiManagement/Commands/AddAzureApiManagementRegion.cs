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
//

namespace Microsoft.Azure.Commands.ApiManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.Models;
    using ResourceManager.Common.ArgumentCompleters;
    using System.Management.Automation;

    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementRegion"), OutputType(typeof(PsApiManagement))]
    public class AddAzureApiManagementRegion : AzureApiManagementCmdletBase
    {
        [Parameter(
          ValueFromPipeline = true,
          Mandatory = true,
          HelpMessage = "PsApiManagement instance to add additional deployment region to.")]
        [ValidateNotNull]
        public PsApiManagement ApiManagement { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = true,
            HelpMessage = "Location of the new deployment region.")]
        [LocationCompleter("Microsoft.ApiManagement/service")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = false,
            HelpMessage = "Tier of the deployment region. Valid and Default value is Premium.")]
        public PsApiManagementSku? Sku { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = false,
            HelpMessage = "Sku capacity of the deployment region. Default value is 1.")]
        public int? Capacity { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = false,
            HelpMessage = "Virtual network configuration. Default value is $null.")]
        public PsApiManagementVirtualNetwork VirtualNetwork { get; set; }

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
            " Default behavior is to make the region live immediately. ")]
        public bool? DisableGateway { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Standard SKU PublicIpAddress ResoureId for integration into stv2 Virtual Network Deployments")]
        public string PublicIpAddressId { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecuteCmdLetWrap(
                () =>
                {
                    ApiManagement.AddRegion(
                        Location, 
                        Sku ?? PsApiManagementSku.Premium, 
                        Capacity ?? 1,
                        VirtualNetwork,
                        Zone,
                        DisableGateway,
                        PublicIpAddressId);

                    return ApiManagement;
                },
                passThru: true);
        }
    }
}
