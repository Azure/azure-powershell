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
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsData.Update, "AzureRmApiManagementDeployment", DefaultParameterSetName = DefaultParameterSetName), OutputType(typeof(PsApiManagement))]
    [Obsolete("This cmdlet has been marked for deprecation in an upcoming release. Please use the " +
        "Set-AzureRmApiManagement cmdlet from the AzureRM.ApiManagement module instead.",
        false)]
    public class UpdateAzureApiManagementDeployment : AzureApiManagementCmdletBase
    {
        internal const string FromPsApiManagementInstanceSetName = "UpdateFromPsApiManagementInstance";
        internal const string DefaultParameterSetName = "UpdateSpecificService";

        [Parameter(
            ParameterSetName = FromPsApiManagementInstanceSetName,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "PsApiManagement instance to get deployment configuration from.")]
        [ValidateNotNull]
        public PsApiManagement ApiManagement { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSetName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of resource group under which API Management exists.")]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSetName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of API Management.")]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSetName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Location of master API Management deployment region.")]
        [LocationCompleter("Microsoft.ApiManagement/service")]
        public string Location { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSetName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "The tier of master Azure API Management deployment region. Valid values are Developer, Standard and Premium.")]
        public PsApiManagementSku Sku { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSetName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Sku capacity of master Azure API Management deployment region.")]
        public int Capacity { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSetName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Virtual Network Configuration of master Azure API Management deployment region.")]
        public PsApiManagementVirtualNetwork VirtualNetwork { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSetName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Vpn Type of service Azure API Management. Valid values are None, External and Internal. Default value is None.")]
        public PsApiManagementVpnType VpnType { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSetName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Additional deployment regions of Azure API Management.")]
        public IList<PsApiManagementRegion> AdditionalRegions { get; set; }
        
        [Parameter(
            Mandatory = false,
            HelpMessage = "Sends updated PsApiManagement to pipeline if operation succeeds.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            var apiManagementResource = this.Client.UpdateDeployment(
                    ResourceGroupName,
                    Name,
                    Location,
                    Sku,
                    Capacity,
                    VirtualNetwork,
                    VpnType,
                    AdditionalRegions,
                    ApiManagement);

            if (PassThru.IsPresent)
            {
                this.WriteObject(apiManagementResource);
            }
        }
    }
}