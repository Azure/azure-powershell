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
    using Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ApiManagement.Models;
    using System.Management.Automation;
    using ResourceManager.Common.ArgumentCompleters;
    using Microsoft.WindowsAzure.Storage;

    [Cmdlet("Undo", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementRemoval"), OutputType(typeof(PsApiManagement))]
    public class UndoAzureApiManagementRemoval : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of resource group under which API Management exists.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of API Management.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Location where want to create API Management.")]
        [LocationCompleter("Microsoft.ApiManagement/service")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            var apiManagementService = Client.CreateApiManagementService(
                resourceGroupName : ResourceGroupName,
                serviceName : Name,
                location : Location,
                organization : "foo",
                administratorEmail : "foo@mictosoft.com",
                tags : null,
                enableClientCertificate : false,
                restore: true);

            this.WriteObject(apiManagementService);
        }
    }
}
