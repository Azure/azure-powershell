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
    using Helpers;
    using Management.Internal.Resources.Models;
    using Microsoft.Azure.Commands.ApiManagement.Models;
    using ResourceManager.Common.ArgumentCompleters;
    using ResourceManager.Common.Tags;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Set, "AzureRmApiManagement"), OutputType(typeof(PsApiManagement))]
    public class SetAzureApiManagement : AzureApiManagementCmdletBase
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
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "The ApiManagement instance.")]
        [ValidateNotNull]
        public PsApiManagement ApiManagement { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            var apiManagementResource = Client.UpdateService(ResourceGroupName, Name, ApiManagement);           

            this.WriteObject(apiManagementResource);
        }
    }
}