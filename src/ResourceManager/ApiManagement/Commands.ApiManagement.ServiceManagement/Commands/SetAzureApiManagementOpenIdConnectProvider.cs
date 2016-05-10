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

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using System;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Set, Constants.ApiManagementOpenIdConnectProvider)]
    [OutputType(typeof(PsApiManagementOpenIdConnectProvider))]
    public class SetAzureApiManagementOpenIdConnectProvider : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of OpenId Connect Provider Id to update. This parameter is mandatory.")]
        [ValidateNotNullOrEmpty]
        public String OpenIdConnectProviderId { get; set; }

        [Parameter(
           ValueFromPipelineByPropertyName = true,
           Mandatory = false,
           HelpMessage = "OpenId Connect Provider User friendly name. This parameter is optional.")]
        public String Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Metadata Endpoint URI of the OpenID Connect Provider. This parameter is optional.")]
        public String MetadataEndpointUri { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "ClientID of the developer console. This parameter is optional.")]
        public String ClientId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "ClientSecret of the developer Console. This parameter is optional.")]
        public String ClientSecret { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "OpenId Connect Provider user friendly description. This parameter is optional.")]
        public String Description { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified then instance of " +
                          "Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementOpenIdConnectProvider type" +
                          " representing the modified OpenId Connect Provider will be written to output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            Client.OpenIdConnectProviderSet(
                Context,
                OpenIdConnectProviderId,
                Name,
                Description,
                ClientId,
                ClientSecret,
                MetadataEndpointUri);

            if (PassThru)
            {
                var @openIdConnectProvider = Client.OpenIdConnectProviderById(Context, OpenIdConnectProviderId);
                WriteObject(@openIdConnectProvider);
            }
        }
    }
}