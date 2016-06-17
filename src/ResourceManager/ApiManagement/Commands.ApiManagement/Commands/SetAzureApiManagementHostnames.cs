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
    using System;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Set, "AzureRmApiManagementHostnames", DefaultParameterSetName = DefaultParameterSetName), OutputType(typeof(PsApiManagement))]
    public class SetAzureApiManagementHostnames : AzureApiManagementCmdletBase
    {
        internal const string FromPsApiManagementInstanceSetName = "Set from provided PsApiManagement instance";
        internal const string DefaultParameterSetName = "Specific API Management service";

        [Parameter(
            ParameterSetName = FromPsApiManagementInstanceSetName,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "PsApiManagement instance to get PortalHostnameConfiguration and ProxyHostnameConfiguration from.")]
        [ValidateNotNull]
        public PsApiManagement ApiManagement { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSetName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of resource group under which API Management exists.")]
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
            Mandatory = false,
            HelpMessage = "Custom portal hostname configuration. Default value is $null. Passing $null will set the default hostname.")]
        public PsApiManagementHostnameConfiguration PortalHostnameConfiguration { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSetName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Custom proxy hostname configuration. Default value is $null. Passing $null will set the default hostname.")]
        public PsApiManagementHostnameConfiguration ProxyHostnameConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Sends updated PsApiManagement to pipeline if operation succeeds.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceGroupName, name;
            PsApiManagementHostnameConfiguration portalHostName, proxyHostName;

            if (ParameterSetName.Equals(DefaultParameterSetName, StringComparison.OrdinalIgnoreCase))
            {
                resourceGroupName = ResourceGroupName;
                name = Name;
                portalHostName = PortalHostnameConfiguration;
                proxyHostName = ProxyHostnameConfiguration;
            }
            else if (ParameterSetName.Equals(FromPsApiManagementInstanceSetName, StringComparison.OrdinalIgnoreCase))
            {
                resourceGroupName = ApiManagement.ResourceGroupName;
                name = ApiManagement.Name;
                portalHostName = ApiManagement.PortalHostnameConfiguration;
                proxyHostName = ApiManagement.ProxyHostnameConfiguration;
            }
            else
            {
                throw new Exception(string.Format("Unrecongnized parameter set: {0}", ParameterSetName));
            }

            ExecuteLongRunningCmdletWrap(
                () => Client.BeginSetHostnames(resourceGroupName, name, portalHostName, proxyHostName),
                PassThru.IsPresent);
        }
    }
}