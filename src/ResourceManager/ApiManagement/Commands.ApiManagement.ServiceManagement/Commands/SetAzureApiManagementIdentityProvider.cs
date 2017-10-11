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

    [Cmdlet(VerbsCommon.Set, Constants.ApiManagementIdentityProvider, SupportsShouldProcess = true)]
    [OutputType(typeof(PsApiManagementIdentityProvider))]
    public class SetAzureApiManagementIdentityProvider : AzureApiManagementCmdletBase
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
            HelpMessage = "Identifier of existing identity provider. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementIdentityProviderType Type { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Client Id of the Application in the external Identity Provider. This parameter is optional.")]
        public String ClientId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Client secret of the Application in external Identity Provider, used to authenticate login request. This parameter is optional.")]
        public String ClientSecret { get; set; }
        
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Allowed Azure Active Directory Tenants. This parameter is optional and only required when setting up Aad Identity Provider.")]
        public string[] AllowedTenants { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified then instance of " +
                          "Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementIdentityProvider type " +
                          "representing the modified identity provider.")]
        public SwitchParameter PassThru { get; set; }
        
        public override void ExecuteApiManagementCmdlet()
        {
            if (ShouldProcess(Type.ToString("G"), "Set Identity Provider"))
            {
                Client.IdentityProviderSet(Context, Type.ToString("g"), ClientId, ClientSecret, AllowedTenants);

                if (PassThru)
                {
                    var @group = Client.IdentityProviderByName(Context, Type.ToString("g"));
                    WriteObject(@group);
                }
            }
        }
    }
}
