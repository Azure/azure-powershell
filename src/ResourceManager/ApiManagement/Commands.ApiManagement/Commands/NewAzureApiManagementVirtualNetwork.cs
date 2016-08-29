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
    using ResourceManager.Common;
    using System;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.New, "AzureRmApiManagementVirtualNetwork"), OutputType(typeof(PsApiManagementVirtualNetwork))]
    public class NewAzureApiManagementVirtualNetwork : AzureRMCmdlet
    {
        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = true,
            HelpMessage = "Location of the virtual network.")]

        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = true,
            HelpMessage = "Name of the sub network.")]
        [ValidateNotNullOrEmpty]
        public string SubnetName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = true,
            HelpMessage = "Identifier of the virtual network.")]
        [ValidateNotNullOrEmpty]
        public Guid VnetId { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(
                new PsApiManagementVirtualNetwork
                {
                    Location = Location,
                    SubnetName = SubnetName,
                    VnetId = VnetId
                });
        }
    }
}