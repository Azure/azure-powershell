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

    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementIdentityProvider", SupportsShouldProcess = true, DefaultParameterSetName = ExpandedParameterSet)]
    [OutputType(typeof(PsApiManagementIdentityProvider), ParameterSetName = new[] { ExpandedParameterSet, ByInputObjectParameterSet })]
    public class SetAzureApiManagementIdentityProvider : AzureApiManagementCmdletBase
    {
        #region Parameter Set Names

        protected const string ExpandedParameterSet = "ExpandedParameter";
        protected const string ByInputObjectParameterSet = "ByInputObject";

        #endregion

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing identity provider. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementIdentityProviderType Type { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementIdentityProvider. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementIdentityProvider InputObject { get; set; }

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
            HelpMessage = "OpenID Connect discovery endpoint hostname for AAD or AAD B2C. This parameter is optional.")]
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
            HelpMessage = "If specified then instance of " +
                          "Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementIdentityProvider type " +
                          "representing the modified identity provider.")]
        public SwitchParameter PassThru { get; set; }
        
        public override void ExecuteApiManagementCmdlet()
        {
            string resourcegroupName;
            string serviceName;
            string identityProviderType;

            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                resourcegroupName = InputObject.ResourceGroupName;
                serviceName = InputObject.ServiceName;
                identityProviderType = InputObject.Type.ToString("g");
            }
            else
            {
                resourcegroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                identityProviderType = Type.ToString("g");
            }

            if (ShouldProcess(Type.ToString("G"), "Set Identity Provider"))
            {
                Client.IdentityProviderSet(
                    resourcegroupName,
                    serviceName,
                    identityProviderType,
                    ClientId,
                    ClientSecret, 
                    AllowedTenants,
                    Authority,
                    SigninPolicyName,
                    SignupPolicyName,
                    PasswordResetPolicyName,
                    ProfileEditingPolicyName,
                    InputObject);

                if (PassThru)
                {
                    var idenityProvider = Client.IdentityProviderByName(resourcegroupName, serviceName, identityProviderType);
                    WriteObject(idenityProvider);
                }
            }
        }
    }
}
