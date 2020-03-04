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
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementIdentityProvider", SupportsShouldProcess = true)]
    [OutputType(typeof(PsApiManagementIdentityProvider))]
    public class NewAzureApiManagementIdentityProvider : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true,
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

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "OpenID Connect discovery endpoint hostname for AAD or AAD B2C. This parameter is optional.")]
        [PSArgumentCompleter("login.microsoftonline.com")]
        public String Authority { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Signup Policy Name. Only applies to AAD B2C Identity Provider. This parameter is optional.")]
        public String SignupPolicyName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Signin Policy Name. Only applies to AAD B2C Identity Provider. This parameter is optional.")]
        public String SigninPolicyName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Profile Editing Policy Name. Only applies to AAD B2C Identity Provider. This parameter is optional.")]
        public String ProfileEditingPolicyName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Password Reset Policy Name. Only applies to AAD B2C Identity Provider. This parameter is optional.")]
        public String PasswordResetPolicyName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Signin Tenant to use for AAD Authentication. Only applies to AAD B2C Identity Provider. This parameter is optional.")]
        public String SigninTenant { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            if (ShouldProcess(Type.ToString("g"), "Creates a new Identity Provider"))
            {
                var identityProvider = Client.IdentityProviderCreate(
                    Context,
                    Type.ToString("G"),
                    ClientId,
                    ClientSecret,
                    AllowedTenants,
                    Authority,
                    SigninPolicyName,
                    SignupPolicyName,
                    PasswordResetPolicyName,
                    ProfileEditingPolicyName,
                    SigninTenant);

                WriteObject(identityProvider);
            }
        }
    }
}
