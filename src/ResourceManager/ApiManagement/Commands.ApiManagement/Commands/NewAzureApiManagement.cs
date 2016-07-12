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
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.New, "AzureRmApiManagement"), OutputType(typeof(PsApiManagement))]
    public class NewAzureApiManagement : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of resource group under which you want to create API Management.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of API Management.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Location where want to create API Management.")]
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
        public string AdminEmail { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "The tier of the Azure API Management service. Valid values are Developer, Standard and Premium . Default value is Developer")]
        public PsApiManagementSku? Sku { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Sku capacity of the Azure API Management service. Default value is 1.")]
        public int? Capacity { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Tags dictionary.")]
        public Dictionary<string, string> Tags { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecuteLongRunningCmdletWrap(
                () => Client.BeginCreateApiManagementService(
                    ResourceGroupName,
                    Name,
                    Location,
                    Organization,
                    AdminEmail,
                    Sku ?? PsApiManagementSku.Developer,
                    Capacity ?? 1,
                    Tags),
                passThru: true);
        }
    }
}