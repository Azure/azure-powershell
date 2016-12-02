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
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get, Constants.ApiManagementIdentityProvider, DefaultParameterSetName = GetAll)]
    [OutputType(typeof(IList<PsApiManagementIdentityProvider>), ParameterSetName = new[] { GetAll })]
    [OutputType(typeof(PsApiManagementIdentityProvider), ParameterSetName = new[] { GetByType })]
    public class GetAzureApiManagementIdentityProvider : AzureApiManagementCmdletBase
    {
        private const string GetAll = "Get all identity Providers";
        private const string GetByType = "Get by identity provider type";

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = GetByType,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of a Identity Provider. If specified will try to find identity provider configuration by the identifier. This parameter is optional.")]
        public PsApiManagementIdentityProviderType Type { get; set; }
        
        public override void ExecuteApiManagementCmdlet()
        {
            if (ParameterSetName.Equals(GetAll))
            {
                var identityProviders = Client.IdentityProviderList(Context);
                WriteObject(identityProviders, true);
            }
            else if (ParameterSetName.Equals(GetByType))
            {
                var identityProvider = Client.IdentityProviderByName(Context, Type.ToString("g"));
                WriteObject(identityProvider);
            }
            else
            {
                throw new InvalidOperationException(string.Format("Parameter set name '{0}' is not supported.", ParameterSetName));
            }
        }
    }
}
