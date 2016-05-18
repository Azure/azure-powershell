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
    using System.Linq;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get, "AzureRmApiManagement", DefaultParameterSetName = BaseParameterSetName), OutputType(typeof(List<PsApiManagement>))]
    public class GetAzureApiManagement : AzureApiManagementCmdletBase
    {
        internal const string BaseParameterSetName = "All In Subscription";
        internal const string ResourceGroupParameterSetName = "All In Resource Group";
        internal const string ApiManagementParameterSetName = "Specific API Management Service";

        [Parameter(
            ParameterSetName = ResourceGroupParameterSetName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of resource group under which want to create API Management service.")]
        [Parameter(
            ParameterSetName = ApiManagementParameterSetName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of resource group under which want to create API Management service.")]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ApiManagementParameterSetName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of API Management service.")]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(ResourceGroupName) && !string.IsNullOrEmpty(Name))
            {
                // Get for single API Management service
                var attributes = Client.GetApiManagement(ResourceGroupName, Name);
                WriteObject(attributes);
            }
            else
            {
                // List all services in given resource group if avaliable otherwise all services in given subscription
                var enumeration = Client.ListApiManagements(ResourceGroupName);
                WriteObject(enumeration.ToList(), true);
            }
        }
    }
}