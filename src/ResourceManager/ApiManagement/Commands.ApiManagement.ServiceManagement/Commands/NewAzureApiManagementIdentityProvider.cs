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

    [Cmdlet(VerbsCommon.New, Constants.ApiManagementIdentityProvider, SupportsShouldProcess = true)]
    [OutputType(typeof(PsApiManagementIdentityProvider))]
    public class NewAzureApiManagementIdentityProvider : AzureApiManagementCmdletBase
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
            HelpMessage = "Identifier of IdentityProvider Type. This parameter is required.")]
        public PsApiManagementIdentityProviderType Type { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "ClientId. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ClientId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "ClientSecret. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ClientSecret { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Allowed Aad Tenants. This parameter is optional and only required when setting up Aad Authentication.")]
        public string[] AllowedTenants { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            if (ShouldProcess(Type.ToString("g"), "Creates a new Identity Provider"))
            {
                var identityProvider = Client.IdentityProviderCreate(
                    Context,
                    Type.ToString("G"),
                    ClientId,
                    ClientSecret,
                    AllowedTenants);

                WriteObject(identityProvider);
            }
        }
    }
}
