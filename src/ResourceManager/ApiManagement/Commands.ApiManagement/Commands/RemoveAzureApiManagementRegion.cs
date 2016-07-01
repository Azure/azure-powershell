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
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Remove, "AzureRmApiManagementRegion"), OutputType(typeof(PsApiManagement))]
    public class RemoveAzureApiManagementRegion : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "PsApiManagement instance to remove the deployment region from.")]
        [ValidateNotNull]
        public PsApiManagement ApiManagement { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Location of the deployment region to remove.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecuteCmdLetWrap(
                () =>
                {
                    ApiManagement.RemoveRegion(Location);

                    return ApiManagement;
                },
                passThru: true);
        }
    }
}